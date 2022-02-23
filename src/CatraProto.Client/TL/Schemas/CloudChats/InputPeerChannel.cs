using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class InputPeerChannel : CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase
    {
        public static int StaticConstructorId
        {
            get => 666680316;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("channel_id")]
        public long ChannelId { get; set; }

        [Newtonsoft.Json.JsonProperty("access_hash")]
        public long AccessHash { get; set; }


    #nullable enable
        public InputPeerChannel(long channelId, long accessHash)
        {
            ChannelId = channelId;
            AccessHash = accessHash;
        }
    #nullable disable
        internal InputPeerChannel()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(ChannelId);
            writer.Write(AccessHash);
        }

        public override void Deserialize(Reader reader)
        {
            ChannelId = reader.Read<long>();
            AccessHash = reader.Read<long>();
        }

        public override string ToString()
        {
            return "inputPeerChannel";
        }
    }
}