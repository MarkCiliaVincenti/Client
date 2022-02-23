using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PageBlockChannel : CatraProto.Client.TL.Schemas.CloudChats.PageBlockBase
    {
        public static int StaticConstructorId
        {
            get => -283684427;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("channel")]
        public CatraProto.Client.TL.Schemas.CloudChats.ChatBase Channel { get; set; }


    #nullable enable
        public PageBlockChannel(CatraProto.Client.TL.Schemas.CloudChats.ChatBase channel)
        {
            Channel = channel;
        }
    #nullable disable
        internal PageBlockChannel()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Channel);
        }

        public override void Deserialize(Reader reader)
        {
            Channel = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>();
        }

        public override string ToString()
        {
            return "pageBlockChannel";
        }
    }
}