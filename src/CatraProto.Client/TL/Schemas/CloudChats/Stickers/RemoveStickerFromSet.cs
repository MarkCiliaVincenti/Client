using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Stickers
{
    public partial class RemoveStickerFromSet : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -143257775; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("sticker")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase Sticker { get; set; }


#nullable enable
        public RemoveStickerFromSet(CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase sticker)
        {
            Sticker = sticker;

        }
#nullable disable

        internal RemoveStickerFromSet()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checksticker = writer.WriteObject(Sticker);
            if (checksticker.IsError)
            {
                return checksticker;
            }

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trysticker = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputDocumentBase>();
            if (trysticker.IsError)
            {
                return ReadResult<IObject>.Move(trysticker);
            }
            Sticker = trysticker.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "stickers.removeStickerFromSet";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}