using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class TopPeerCategoryPhoneCalls : CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 511092620; }



        public TopPeerCategoryPhoneCalls()
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
            return "topPeerCategoryPhoneCalls";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}