using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class SendMessageGeoLocationAction : CatraProto.Client.TL.Schemas.CloudChats.SendMessageActionBase
    {
        public static int StaticConstructorId
        {
            get => 393186209;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public SendMessageGeoLocationAction()
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
            return "sendMessageGeoLocationAction";
        }
    }
}