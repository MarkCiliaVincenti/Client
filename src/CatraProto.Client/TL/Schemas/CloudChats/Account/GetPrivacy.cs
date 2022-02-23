using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class GetPrivacy : IMethod
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => -623130288;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Account.PrivacyRulesBase);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonProperty("key")] public CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyKeyBase Key { get; set; }


    #nullable enable
        public GetPrivacy(CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyKeyBase key)
        {
            Key = key;
        }
    #nullable disable

        internal GetPrivacy()
        {
        }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Key);
        }

        public void Deserialize(Reader reader)
        {
            Key = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPrivacyKeyBase>();
        }

        public override string ToString()
        {
            return "account.getPrivacy";
        }
    }
}