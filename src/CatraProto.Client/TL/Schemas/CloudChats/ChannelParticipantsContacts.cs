using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChannelParticipantsContacts : CatraProto.Client.TL.Schemas.CloudChats.ChannelParticipantsFilterBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1150621555; }

        [Newtonsoft.Json.JsonProperty("q")]
        public string Q { get; set; }


#nullable enable
        public ChannelParticipantsContacts(string q)
        {
            Q = q;

        }
#nullable disable
        internal ChannelParticipantsContacts()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Q);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryq = reader.ReadString();
            if (tryq.IsError)
            {
                return ReadResult<IObject>.Move(tryq);
            }
            Q = tryq.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "channelParticipantsContacts";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}