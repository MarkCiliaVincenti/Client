using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PhoneConnection : CatraProto.Client.TL.Schemas.CloudChats.PhoneConnectionBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1655957568; }

        [Newtonsoft.Json.JsonProperty("id")]
        public sealed override long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("ip")]
        public sealed override string Ip { get; set; }

        [Newtonsoft.Json.JsonProperty("ipv6")]
        public sealed override string Ipv6 { get; set; }

        [Newtonsoft.Json.JsonProperty("port")]
        public sealed override int Port { get; set; }

        [Newtonsoft.Json.JsonProperty("peer_tag")]
        public byte[] PeerTag { get; set; }


#nullable enable
        public PhoneConnection(long id, string ip, string ipv6, int port, byte[] peerTag)
        {
            Id = id;
            Ip = ip;
            Ipv6 = ipv6;
            Port = port;
            PeerTag = peerTag;

        }
#nullable disable
        internal PhoneConnection()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(Id);

            writer.WriteString(Ip);

            writer.WriteString(Ipv6);
            writer.WriteInt32(Port);

            writer.WriteBytes(PeerTag);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryid = reader.ReadInt64();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }
            Id = tryid.Value;
            var tryip = reader.ReadString();
            if (tryip.IsError)
            {
                return ReadResult<IObject>.Move(tryip);
            }
            Ip = tryip.Value;
            var tryipv6 = reader.ReadString();
            if (tryipv6.IsError)
            {
                return ReadResult<IObject>.Move(tryipv6);
            }
            Ipv6 = tryipv6.Value;
            var tryport = reader.ReadInt32();
            if (tryport.IsError)
            {
                return ReadResult<IObject>.Move(tryport);
            }
            Port = tryport.Value;
            var trypeerTag = reader.ReadBytes();
            if (trypeerTag.IsError)
            {
                return ReadResult<IObject>.Move(trypeerTag);
            }
            PeerTag = trypeerTag.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "phoneConnection";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PhoneConnection
            {
                Id = Id,
                Ip = Ip,
                Ipv6 = Ipv6,
                Port = Port,
                PeerTag = PeerTag
            };
            return newClonedObject;

        }
#nullable disable
    }
}