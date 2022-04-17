using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class StickerSetMultiCovered : CatraProto.Client.TL.Schemas.CloudChats.StickerSetCoveredBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 872932635; }

        [Newtonsoft.Json.JsonProperty("set")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase Set { get; set; }

        [Newtonsoft.Json.JsonProperty("covers")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> Covers { get; set; }


#nullable enable
        public StickerSetMultiCovered(CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase set, List<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> covers)
        {
            Set = set;
            Covers = covers;

        }
#nullable disable
        internal StickerSetMultiCovered()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkset = writer.WriteObject(Set);
            if (checkset.IsError)
            {
                return checkset;
            }
            var checkcovers = writer.WriteVector(Covers, false);
            if (checkcovers.IsError)
            {
                return checkcovers;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryset = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.StickerSetBase>();
            if (tryset.IsError)
            {
                return ReadResult<IObject>.Move(tryset);
            }
            Set = tryset.Value;
            var trycovers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trycovers.IsError)
            {
                return ReadResult<IObject>.Move(trycovers);
            }
            Covers = trycovers.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "stickerSetMultiCovered";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}