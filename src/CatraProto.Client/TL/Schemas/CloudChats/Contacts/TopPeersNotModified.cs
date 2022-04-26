using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public partial class TopPeersNotModified : CatraProto.Client.TL.Schemas.CloudChats.Contacts.TopPeersBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -567906571; }



        public TopPeersNotModified()
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
            return "contacts.topPeersNotModified";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new TopPeersNotModified();
            return newClonedObject;

        }
#nullable disable
    }
}