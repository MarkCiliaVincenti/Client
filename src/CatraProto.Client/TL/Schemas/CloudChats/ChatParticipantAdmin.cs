using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChatParticipantAdmin : CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1600962725; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public sealed override long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("inviter_id")]
        public long InviterId { get; set; }

        [Newtonsoft.Json.JsonProperty("date")]
        public int Date { get; set; }


#nullable enable
        public ChatParticipantAdmin(long userId, long inviterId, int date)
        {
            UserId = userId;
            InviterId = inviterId;
            Date = date;

        }
#nullable disable
        internal ChatParticipantAdmin()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(UserId);
            writer.WriteInt64(InviterId);
            writer.WriteInt32(Date);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryuserId = reader.ReadInt64();
            if (tryuserId.IsError)
            {
                return ReadResult<IObject>.Move(tryuserId);
            }
            UserId = tryuserId.Value;
            var tryinviterId = reader.ReadInt64();
            if (tryinviterId.IsError)
            {
                return ReadResult<IObject>.Move(tryinviterId);
            }
            InviterId = tryinviterId.Value;
            var trydate = reader.ReadInt32();
            if (trydate.IsError)
            {
                return ReadResult<IObject>.Move(trydate);
            }
            Date = trydate.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "chatParticipantAdmin";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}