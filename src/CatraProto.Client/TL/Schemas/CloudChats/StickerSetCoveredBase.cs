using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class StickerSetCoveredBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("set")]
        public abstract CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase Set { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
