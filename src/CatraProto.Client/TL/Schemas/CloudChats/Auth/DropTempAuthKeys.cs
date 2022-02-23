using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class DropTempAuthKeys : IMethod
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => -1907842680;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(bool);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonProperty("except_auth_keys")]
        public IList<long> ExceptAuthKeys { get; set; }


    #nullable enable
        public DropTempAuthKeys(IList<long> exceptAuthKeys)
        {
            ExceptAuthKeys = exceptAuthKeys;
        }
    #nullable disable

        internal DropTempAuthKeys()
        {
        }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(ExceptAuthKeys);
        }

        public void Deserialize(Reader reader)
        {
            ExceptAuthKeys = reader.ReadVector<long>();
        }

        public override string ToString()
        {
            return "auth.dropTempAuthKeys";
        }
    }
}