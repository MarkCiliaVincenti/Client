using CatraProto.TL;
using CatraProto.TL.Results;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL.Interfaces;
#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public abstract class RpcErrorBase : IObject
    {

[Newtonsoft.Json.JsonProperty("error_code")]
		public abstract int ErrorCode { get; set; }

[Newtonsoft.Json.JsonProperty("error_message")]
		public abstract string ErrorMessage { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
