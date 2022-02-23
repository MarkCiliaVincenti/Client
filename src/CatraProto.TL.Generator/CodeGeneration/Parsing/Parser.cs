using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CatraProto.TL.Generator.DeclarationInfo;
using CatraProto.TL.Generator.Objects;
using CatraProto.TL.Generator.Settings;
using Object = CatraProto.TL.Generator.Objects.Interfaces.Object;

namespace CatraProto.TL.Generator.CodeGeneration.Parsing
{
    class Parser
    {
        private string _line;

        public Parser(string line)
        {
            _line = line;
        }

        public static async Task<List<Object>> StartAnalyzing(string[] schemaString = null)
        {
            var schema = schemaString ?? await File.ReadAllLinesAsync("schema.tl");
            var objects = new List<Object>();
            var readType = ReadType.ReadingConstructor;
            var methodType = MethodCompletionType.ReturnsEncryptedRPCResult;
            for (var index = 0; index < schema.Length; index++)
            {
                var line = schema[index];
                if (line == "\n")
                {
                    continue;
                }

                if (line.StartsWith("//"))
                {
                    continue;
                }

                if (line.Length < 1)
                {
                    continue;
                }

                switch (line)
                {
                    case "-/-namespace-/-":
                    {
                        if (index + 1 >= 0 && schema.Length > index + 1)
                        {
                            Configuration.Namespace = schema[index + 1];
                            index++;
                        }

                        continue;
                    }
                    case "-/-returnsRPCEncrypted-/-":
                        methodType = MethodCompletionType.ReturnsEncryptedRPCResult;
                        continue;
                    case "-/-returnsUnencrypted-/-":
                        methodType = MethodCompletionType.ReturnsUnencrypted;
                        continue;
                    case "---functions---":
                        readType = ReadType.ReadingMethod;
                        continue;
                    case "---constructors---":
                        readType = ReadType.ReadingConstructor;
                        continue;
                }

                Object constructor = readType switch
                {
                    ReadType.ReadingConstructor => new Constructor(),
                    ReadType.ReadingMethod => new Method(methodType),
                    _ => throw new Exception("Unrecognized type")
                };

                var analyzer = new Parser(line);
                var id = analyzer.FindId();
                if (id != null)
                {
                    constructor.Id = id.Value;
                }

                var parameters = analyzer.FindParameters().Select(Parameter.Create).ToList();
                constructor.Parameters = parameters;
                var name = analyzer.FindName(out var naked);
                constructor.Namespace = new Namespace(name);

                var foundType = analyzer.FindType();
                var isVector = FindVector(foundType, out foundType);
                constructor.NamingInfo = name.Split('.')[^1];
                constructor.NamingInfo.OriginalNamespacedName = name;
                constructor.Type = Tools.CreateType(foundType, new TypeInfo
                {
                    IsNaked = naked,
                });

                if (constructor is Method method)
                {
                    method.ReturnsVector = isVector;
                }

                objects.Add(constructor);
            }

            return objects;
        }


        public static bool FindVector(string type, out string vectorType)
        {
            var found = Regex.IsMatch(type, @"\w+<.+>") ? type.Split("<") : new[] { type };
            if (found.Length == 2)
            {
                found[^1] = found[^1].TrimEnd('>');
            }

            vectorType = found.Length == 2 ? found[1] : found[0];
            return found.Length == 2;
        }

        public string FindName(out bool naked)
        {
            var separator = " ";
            var isMatch = Regex.IsMatch(_line, @".+\w+\#[a-zA-Z0-9]+");
            if (isMatch)
            {
                separator = "#";
            }

            var split = _line.Split(separator);
            naked = split[0].Contains('_');
            return split[0];
        }

        public int? FindId()
        {
            var match = Regex.Match(_line, @".+\w+\#[a-zA-Z0-9]+");
            if (match.Success)
            {
                return int.Parse(match.Groups[0].Value.Split("#")[1], NumberStyles.HexNumber);
            }

            return null;
        }

        public string[] FindParameters()
        {
            var split = _line.Split(" ");
            var list = new List<string>();
            foreach (var param in split)
            {
                if (param[0] == '{')
                {
                    continue;
                }

                if (param == "=")
                {
                    break;
                }

                var match = Regex.Match(param, @"\w+:(.+)? ", RegexOptions.IgnorePatternWhitespace);
                if (match.Success)
                {
                    var found = match.Groups[0].Value;
                    list.Add(found);
                }
            }

            return list.ToArray();
        }

        //Obviously there is a better way to do this (aka making a new regex)
        //TODO
        public string[] FindPolymorphicTypes()
        {
            var split = _line.Split(" ");
            var list = new List<string>();
            foreach (var param in split)
            {
                if (param[0] != '{')
                {
                    continue;
                }

                if (param == "=")
                {
                    break;
                }

                var match = Regex.Match(param, @"\w+:(.+)? ", RegexOptions.IgnorePatternWhitespace);
                if (match.Success)
                {
                    var found = match.Groups[0].Value.Replace("}", "");
                    list.Add(found);
                }
            }

            return list.ToArray();
        }

        public string FindType()
        {
            var match = Regex.Match(_line, @"= (.*?);");
            if (match.Success)
            {
                return match.Groups[0].Value.Replace(";", string.Empty).Replace("=", string.Empty).Replace(" ", string.Empty);
            }

            return null;
        }
    }
}