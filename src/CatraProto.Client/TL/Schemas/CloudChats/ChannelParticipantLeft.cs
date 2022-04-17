using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChannelParticipantLeft : CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 453242886; }

        [Newtonsoft.Json.JsonProperty("peer")]
        public CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }


#nullable enable
        public ChannelParticipantLeft(CatraProto.Client.TL.Schemas.CloudChats.PeerBase peer)
        {
            Peer = peer;

        }
#nullable disable
        internal ChannelParticipantLeft()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkpeer = writer.WriteObject(Peer);
            if (checkpeer.IsError)
            {
                return checkpeer;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }
            Peer = trypeer.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "channelParticipantLeft";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}