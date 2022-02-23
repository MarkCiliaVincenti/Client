using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class DialogsNotModified : CatraProto.Client.TL.Schemas.CloudChats.Messages.DialogsBase
    {
        public static int StaticConstructorId
        {
            get => -253500010;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("count")]
        public int Count { get; set; }


    #nullable enable
        public DialogsNotModified(int count)
        {
            Count = count;
        }
    #nullable disable
        internal DialogsNotModified()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Count);
        }

        public override void Deserialize(Reader reader)
        {
            Count = reader.Read<int>();
        }

        public override string ToString()
        {
            return "messages.dialogsNotModified";
        }
    }
}