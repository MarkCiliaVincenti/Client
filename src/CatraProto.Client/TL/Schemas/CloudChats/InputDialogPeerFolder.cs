using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputDialogPeerFolder : CatraProto.Client.TL.Schemas.CloudChats.InputDialogPeerBase
    {
        public static int StaticConstructorId
        {
            get => 1684014375;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("folder_id")]
        public int FolderId { get; set; }


    #nullable enable
        public InputDialogPeerFolder(int folderId)
        {
            FolderId = folderId;
        }
    #nullable disable
        internal InputDialogPeerFolder()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(FolderId);
        }

        public override void Deserialize(Reader reader)
        {
            FolderId = reader.Read<int>();
        }

        public override string ToString()
        {
            return "inputDialogPeerFolder";
        }
    }
}