using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class PeerDialogs : CatraProto.Client.TL.Schemas.CloudChats.Messages.PeerDialogsBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 863093588; }

        [Newtonsoft.Json.JsonProperty("dialogs")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.DialogBase> Dialogs { get; set; }

        [Newtonsoft.Json.JsonProperty("messages")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.MessageBase> Messages { get; set; }

        [Newtonsoft.Json.JsonProperty("chats")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> Chats { get; set; }

        [Newtonsoft.Json.JsonProperty("users")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> Users { get; set; }

        [Newtonsoft.Json.JsonProperty("state")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.Updates.StateBase State { get; set; }


#nullable enable
        public PeerDialogs(List<CatraProto.Client.TL.Schemas.CloudChats.DialogBase> dialogs, List<CatraProto.Client.TL.Schemas.CloudChats.MessageBase> messages, List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chats, List<CatraProto.Client.TL.Schemas.CloudChats.UserBase> users, CatraProto.Client.TL.Schemas.CloudChats.Updates.StateBase state)
        {
            Dialogs = dialogs;
            Messages = messages;
            Chats = chats;
            Users = users;
            State = state;

        }
#nullable disable
        internal PeerDialogs()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkdialogs = writer.WriteVector(Dialogs, false);
            if (checkdialogs.IsError)
            {
                return checkdialogs;
            }
            var checkmessages = writer.WriteVector(Messages, false);
            if (checkmessages.IsError)
            {
                return checkmessages;
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
            var checkstate = writer.WriteObject(State);
            if (checkstate.IsError)
            {
                return checkstate;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trydialogs = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DialogBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trydialogs.IsError)
            {
                return ReadResult<IObject>.Move(trydialogs);
            }
            Dialogs = trydialogs.Value;
            var trymessages = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trymessages.IsError)
            {
                return ReadResult<IObject>.Move(trymessages);
            }
            Messages = trymessages.Value;
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
            var trystate = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.Updates.StateBase>();
            if (trystate.IsError)
            {
                return ReadResult<IObject>.Move(trystate);
            }
            State = trystate.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.peerDialogs";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}