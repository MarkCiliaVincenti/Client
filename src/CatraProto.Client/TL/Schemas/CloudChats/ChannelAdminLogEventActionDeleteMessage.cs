using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class ChannelAdminLogEventActionDeleteMessage : CatraProto.Client.TL.Schemas.CloudChats.ChannelAdminLogEventActionBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1121994683; }

        [Newtonsoft.Json.JsonProperty("message")]
        public CatraProto.Client.TL.Schemas.CloudChats.MessageBase Message { get; set; }


#nullable enable
        public ChannelAdminLogEventActionDeleteMessage(CatraProto.Client.TL.Schemas.CloudChats.MessageBase message)
        {
            Message = message;

        }
#nullable disable
        internal ChannelAdminLogEventActionDeleteMessage()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkmessage = writer.WriteObject(Message);
            if (checkmessage.IsError)
            {
                return checkmessage;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trymessage = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.MessageBase>();
            if (trymessage.IsError)
            {
                return ReadResult<IObject>.Move(trymessage);
            }
            Message = trymessage.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "channelAdminLogEventActionDeleteMessage";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}