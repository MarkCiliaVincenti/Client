using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class SendMessageChooseStickerAction : CatraProto.Client.TL.Schemas.CloudChats.SendMessageActionBase
    {
        public static int StaticConstructorId
        {
            get => -1336228175;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public SendMessageChooseStickerAction()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
        }

        public override void Deserialize(Reader reader)
        {
        }

        public override string ToString()
        {
            return "sendMessageChooseStickerAction";
        }
    }
}