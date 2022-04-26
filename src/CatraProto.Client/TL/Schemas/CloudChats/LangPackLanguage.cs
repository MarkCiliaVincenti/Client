using System;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class LangPackLanguage : CatraProto.Client.TL.Schemas.CloudChats.LangPackLanguageBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Official = 1 << 0,
            Rtl = 1 << 2,
            Beta = 1 << 3,
            BaseLangCode = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -288727837; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("official")]
        public sealed override bool Official { get; set; }

        [Newtonsoft.Json.JsonProperty("rtl")]
        public sealed override bool Rtl { get; set; }

        [Newtonsoft.Json.JsonProperty("beta")]
        public sealed override bool Beta { get; set; }

        [Newtonsoft.Json.JsonProperty("name")]
        public sealed override string Name { get; set; }

        [Newtonsoft.Json.JsonProperty("native_name")]
        public sealed override string NativeName { get; set; }

        [Newtonsoft.Json.JsonProperty("lang_code")]
        public sealed override string LangCode { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("base_lang_code")]
        public sealed override string BaseLangCode { get; set; }

        [Newtonsoft.Json.JsonProperty("plural_code")]
        public sealed override string PluralCode { get; set; }

        [Newtonsoft.Json.JsonProperty("strings_count")]
        public sealed override int StringsCount { get; set; }

        [Newtonsoft.Json.JsonProperty("translated_count")]
        public sealed override int TranslatedCount { get; set; }

        [Newtonsoft.Json.JsonProperty("translations_url")]
        public sealed override string TranslationsUrl { get; set; }


#nullable enable
        public LangPackLanguage(string name, string nativeName, string langCode, string pluralCode, int stringsCount, int translatedCount, string translationsUrl)
        {
            Name = name;
            NativeName = nativeName;
            LangCode = langCode;
            PluralCode = pluralCode;
            StringsCount = stringsCount;
            TranslatedCount = translatedCount;
            TranslationsUrl = translationsUrl;

        }
#nullable disable
        internal LangPackLanguage()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Official ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Rtl ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
            Flags = Beta ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
            Flags = BaseLangCode == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);

            writer.WriteString(Name);

            writer.WriteString(NativeName);

            writer.WriteString(LangCode);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {

                writer.WriteString(BaseLangCode);
            }


            writer.WriteString(PluralCode);
            writer.WriteInt32(StringsCount);
            writer.WriteInt32(TranslatedCount);

            writer.WriteString(TranslationsUrl);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }
            Flags = tryflags.Value;
            Official = FlagsHelper.IsFlagSet(Flags, 0);
            Rtl = FlagsHelper.IsFlagSet(Flags, 2);
            Beta = FlagsHelper.IsFlagSet(Flags, 3);
            var tryname = reader.ReadString();
            if (tryname.IsError)
            {
                return ReadResult<IObject>.Move(tryname);
            }
            Name = tryname.Value;
            var trynativeName = reader.ReadString();
            if (trynativeName.IsError)
            {
                return ReadResult<IObject>.Move(trynativeName);
            }
            NativeName = trynativeName.Value;
            var trylangCode = reader.ReadString();
            if (trylangCode.IsError)
            {
                return ReadResult<IObject>.Move(trylangCode);
            }
            LangCode = trylangCode.Value;
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var trybaseLangCode = reader.ReadString();
                if (trybaseLangCode.IsError)
                {
                    return ReadResult<IObject>.Move(trybaseLangCode);
                }
                BaseLangCode = trybaseLangCode.Value;
            }

            var trypluralCode = reader.ReadString();
            if (trypluralCode.IsError)
            {
                return ReadResult<IObject>.Move(trypluralCode);
            }
            PluralCode = trypluralCode.Value;
            var trystringsCount = reader.ReadInt32();
            if (trystringsCount.IsError)
            {
                return ReadResult<IObject>.Move(trystringsCount);
            }
            StringsCount = trystringsCount.Value;
            var trytranslatedCount = reader.ReadInt32();
            if (trytranslatedCount.IsError)
            {
                return ReadResult<IObject>.Move(trytranslatedCount);
            }
            TranslatedCount = trytranslatedCount.Value;
            var trytranslationsUrl = reader.ReadString();
            if (trytranslationsUrl.IsError)
            {
                return ReadResult<IObject>.Move(trytranslationsUrl);
            }
            TranslationsUrl = trytranslationsUrl.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "langPackLanguage";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new LangPackLanguage
            {
                Flags = Flags,
                Official = Official,
                Rtl = Rtl,
                Beta = Beta,
                Name = Name,
                NativeName = NativeName,
                LangCode = LangCode,
                BaseLangCode = BaseLangCode,
                PluralCode = PluralCode,
                StringsCount = StringsCount,
                TranslatedCount = TranslatedCount,
                TranslationsUrl = TranslationsUrl
            };
            return newClonedObject;

        }
#nullable disable
    }
}