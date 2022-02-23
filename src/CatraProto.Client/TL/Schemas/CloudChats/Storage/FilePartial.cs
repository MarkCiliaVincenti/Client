using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Storage
{
    public partial class FilePartial : CatraProto.Client.TL.Schemas.CloudChats.Storage.FileTypeBase
    {
        public static int StaticConstructorId
        {
            get => 1086091090;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public FilePartial()
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
            return "storage.filePartial";
        }
    }
}