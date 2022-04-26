using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
    public partial class ChannelParticipantsNotModified : CatraProto.Client.TL.Schemas.CloudChats.Channels.ChannelParticipantsBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -266911767; }



        public ChannelParticipantsNotModified()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "channels.channelParticipantsNotModified";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChannelParticipantsNotModified();
            return newClonedObject;

        }
#nullable disable
    }
}