using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChatForbidden : CatraProto.Client.TL.Schemas.CloudChats.ChatBase
    {
        public static int StaticConstructorId
        {
            get => 1704108455;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("id")] public sealed override long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("title")]
        public string Title { get; set; }


    #nullable enable
        public ChatForbidden(long id, string title)
        {
            Id = id;
            Title = title;
        }
    #nullable disable
        internal ChatForbidden()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Id);
            writer.Write(Title);
        }

        public override void Deserialize(Reader reader)
        {
            Id = reader.Read<long>();
            Title = reader.Read<string>();
        }

        public override string ToString()
        {
            return "chatForbidden";
        }
    }
}