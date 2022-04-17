using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public abstract class PongBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("msg_id")]
        public abstract long MsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("ping_id")]
        public abstract long PingId { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
