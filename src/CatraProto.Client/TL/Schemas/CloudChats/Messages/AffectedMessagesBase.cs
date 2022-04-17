using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public abstract class AffectedMessagesBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("pts")]
        public abstract int Pts { get; set; }

        [Newtonsoft.Json.JsonProperty("pts_count")]
        public abstract int PtsCount { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
