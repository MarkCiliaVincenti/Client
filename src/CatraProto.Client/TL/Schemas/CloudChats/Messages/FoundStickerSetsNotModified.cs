using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class FoundStickerSetsNotModified : CatraProto.Client.TL.Schemas.CloudChats.Messages.FoundStickerSetsBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 223655517; }



        public FoundStickerSetsNotModified()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.foundStickerSetsNotModified";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new FoundStickerSetsNotModified();
            return newClonedObject;

        }
#nullable disable
    }
}