using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class RecentMeUrlChat : CatraProto.Client.TL.Schemas.CloudChats.RecentMeUrlBase
    {
        public static int StaticConstructorId
        {
            get => -1294306862;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("url")] public sealed override string Url { get; set; }

        [Newtonsoft.Json.JsonProperty("chat_id")]
        public long ChatId { get; set; }


    #nullable enable
        public RecentMeUrlChat(string url, long chatId)
        {
            Url = url;
            ChatId = chatId;
        }
    #nullable disable
        internal RecentMeUrlChat()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Url);
            writer.Write(ChatId);
        }

        public override void Deserialize(Reader reader)
        {
            Url = reader.Read<string>();
            ChatId = reader.Read<long>();
        }

        public override string ToString()
        {
            return "recentMeUrlChat";
        }
    }
}