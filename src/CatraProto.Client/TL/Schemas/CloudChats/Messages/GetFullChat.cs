using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetFullChat : IMethod
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => -1364194508;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatFullBase);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonProperty("chat_id")]
        public long ChatId { get; set; }


    #nullable enable
        public GetFullChat(long chatId)
        {
            ChatId = chatId;
        }
    #nullable disable

        internal GetFullChat()
        {
        }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(ChatId);
        }

        public void Deserialize(Reader reader)
        {
            ChatId = reader.Read<long>();
        }

        public override string ToString()
        {
            return "messages.getFullChat";
        }
    }
}