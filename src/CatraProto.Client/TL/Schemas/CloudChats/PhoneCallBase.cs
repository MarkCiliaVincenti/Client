using CatraProto.TL;
using System.Collections.Generic;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class PhoneCallBase : IObject
    {

[Newtonsoft.Json.JsonProperty("id")]
		public abstract long Id { get; set; }

        public abstract void UpdateFlags();
        public abstract void Deserialize(Reader reader);
        public abstract void Serialize(Writer writer);
    }
}
