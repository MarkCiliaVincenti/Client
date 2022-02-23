using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetScheduledMessages : IMethod
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => -1111817116;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.MessagesBase);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public IList<int> Id { get; set; }


    #nullable enable
        public GetScheduledMessages(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, IList<int> id)
        {
            Peer = peer;
            Id = id;
        }
    #nullable disable

        internal GetScheduledMessages()
        {
        }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Peer);
            writer.Write(Id);
        }

        public void Deserialize(Reader reader)
        {
            Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            Id = reader.ReadVector<int>();
        }

        public override string ToString()
        {
            return "messages.getScheduledMessages";
        }
    }
}