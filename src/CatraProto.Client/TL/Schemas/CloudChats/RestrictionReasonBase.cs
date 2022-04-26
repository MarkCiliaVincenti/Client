using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class RestrictionReasonBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("platform")]
        public abstract string Platform { get; set; }

        [Newtonsoft.Json.JsonProperty("reason")]
        public abstract string Reason { get; set; }

        [Newtonsoft.Json.JsonProperty("text")]
        public abstract string Text { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
#nullable enable
        public abstract IObject? Clone();
#nullable disable
    }
}
