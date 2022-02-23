using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class ReadDiscussion : IMethod
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => -147740172;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(bool);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("msg_id")]
        public int MsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("read_max_id")]
        public int ReadMaxId { get; set; }


    #nullable enable
        public ReadDiscussion(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int msgId, int readMaxId)
        {
            Peer = peer;
            MsgId = msgId;
            ReadMaxId = readMaxId;
        }
    #nullable disable

        internal ReadDiscussion()
        {
        }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Peer);
            writer.Write(MsgId);
            writer.Write(ReadMaxId);
        }

        public void Deserialize(Reader reader)
        {
            Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            MsgId = reader.Read<int>();
            ReadMaxId = reader.Read<int>();
        }

        public override string ToString()
        {
            return "messages.readDiscussion";
        }
    }
}