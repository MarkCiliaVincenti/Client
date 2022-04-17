using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Storage
{
    public partial class FileMp3 : CatraProto.Client.TL.Schemas.CloudChats.Storage.FileTypeBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1384777335; }



        public FileMp3()
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
            return "storage.fileMp3";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}