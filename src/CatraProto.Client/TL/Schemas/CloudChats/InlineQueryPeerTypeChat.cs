using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InlineQueryPeerTypeChat : CatraProto.Client.TL.Schemas.CloudChats.InlineQueryPeerTypeBase
    {
        public static int StaticConstructorId
        {
            get => -681130742;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public InlineQueryPeerTypeChat()
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
            return "inlineQueryPeerTypeChat";
        }
    }
}