using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PrivacyKeyAddedByPhone : CatraProto.Client.TL.Schemas.CloudChats.PrivacyKeyBase
    {
        public static int StaticConstructorId
        {
            get => 1124062251;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public PrivacyKeyAddedByPhone()
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
            return "privacyKeyAddedByPhone";
        }
    }
}