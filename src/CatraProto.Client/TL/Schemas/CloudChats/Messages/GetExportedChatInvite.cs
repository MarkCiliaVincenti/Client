using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetExportedChatInvite : IMethod
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => 1937010524;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.Messages.ExportedChatInviteBase);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("link")] public string Link { get; set; }


    #nullable enable
        public GetExportedChatInvite(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, string link)
        {
            Peer = peer;
            Link = link;
        }
    #nullable disable

        internal GetExportedChatInvite()
        {
        }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Peer);
            writer.Write(Link);
        }

        public void Deserialize(Reader reader)
        {
            Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            Link = reader.Read<string>();
        }

        public override string ToString()
        {
            return "messages.getExportedChatInvite";
        }
    }
}