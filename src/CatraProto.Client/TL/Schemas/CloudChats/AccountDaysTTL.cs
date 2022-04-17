using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class AccountDaysTTL : CatraProto.Client.TL.Schemas.CloudChats.AccountDaysTTLBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1194283041; }

        [Newtonsoft.Json.JsonProperty("days")]
        public sealed override int Days { get; set; }


#nullable enable
        public AccountDaysTTL(int days)
        {
            Days = days;

        }
#nullable disable
        internal AccountDaysTTL()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Days);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trydays = reader.ReadInt32();
            if (trydays.IsError)
            {
                return ReadResult<IObject>.Move(trydays);
            }
            Days = trydays.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "accountDaysTTL";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}