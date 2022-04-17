using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Contacts
{
    public partial class Blocked : CatraProto.Client.TL.Schemas.CloudChats.Contacts.BlockedBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 182326673; }

        [Newtonsoft.Json.JsonProperty("blocked")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.PeerBlockedBase> BlockedField { get; set; }

        [Newtonsoft.Json.JsonProperty("chats")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }


#nullable enable
        public Blocked(List<CatraProto.Client.TL.Schemas.CloudChats.PeerBlockedBase> blockedField, List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats, List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users)
        {
            BlockedField = blockedField;
            Chats = chats;
            Users = users;

        }
#nullable disable
        internal Blocked()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkblockedField = writer.WriteVector(BlockedField, false);
            if (checkblockedField.IsError)
            {
                return checkblockedField;
            }
            var checkchats = writer.WriteVector(Chats, false);
            if (checkchats.IsError)
            {
                return checkchats;
            }
            var checkusers = writer.WriteVector(Users, false);
            if (checkusers.IsError)
            {
                return checkusers;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryblockedField = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PeerBlockedBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryblockedField.IsError)
            {
                return ReadResult<IObject>.Move(tryblockedField);
            }
            BlockedField = tryblockedField.Value;
            var trychats = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trychats.IsError)
            {
                return ReadResult<IObject>.Move(trychats);
            }
            Chats = trychats.Value;
            var tryusers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.UserBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryusers.IsError)
            {
                return ReadResult<IObject>.Move(tryusers);
            }
            Users = tryusers.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "contacts.blocked";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}