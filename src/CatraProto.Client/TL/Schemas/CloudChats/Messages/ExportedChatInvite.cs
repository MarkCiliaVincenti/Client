using System.Collections.Generic;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class ExportedChatInvite : CatraProto.Client.TL.Schemas.CloudChats.Messages.ExportedChatInviteBase
    {
        public static int StaticConstructorId
        {
            get => 410107472;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("invite")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase Invite { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


    #nullable enable
        public ExportedChatInvite(CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase invite, IList<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
        {
            Invite = invite;
            Users = users;
        }
    #nullable disable
        internal ExportedChatInvite()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Invite);
            writer.Write(Users);
        }

        public override void Deserialize(Reader reader)
        {
            Invite = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ExportedChatInviteBase>();
            Users = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();
        }

        public override string ToString()
        {
            return "messages.exportedChatInvite";
        }
    }
}