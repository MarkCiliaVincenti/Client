using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public partial class TopPeersNotModified : CatraProto.Client.TL.Schemas.CloudChats.Contacts.TopPeersBase
    {
        public static int StaticConstructorId
        {
            get => -567906571;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public TopPeersNotModified()
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
            return "contacts.topPeersNotModified";
        }
    }
}