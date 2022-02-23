using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Stickers
{
    public partial class CheckShortName : IMethod
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => 676017721;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(bool);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonProperty("short_name")]
        public string ShortName { get; set; }


    #nullable enable
        public CheckShortName(string shortName)
        {
            ShortName = shortName;
        }
    #nullable disable

        internal CheckShortName()
        {
        }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(ShortName);
        }

        public void Deserialize(Reader reader)
        {
            ShortName = reader.Read<string>();
        }

        public override string ToString()
        {
            return "stickers.checkShortName";
        }
    }
}