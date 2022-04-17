using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
    public partial class LeaveGroupCallPresentation : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 475058500; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("call")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase Call { get; set; }


#nullable enable
        public LeaveGroupCallPresentation(CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase call)
        {
            Call = call;

        }
#nullable disable

        internal LeaveGroupCallPresentation()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkcall = writer.WriteObject(Call);
            if (checkcall.IsError)
            {
                return checkcall;
            }

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trycall = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputGroupCallBase>();
            if (trycall.IsError)
            {
                return ReadResult<IObject>.Move(trycall);
            }
            Call = trycall.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "phone.leaveGroupCallPresentation";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}