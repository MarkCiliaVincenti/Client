using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Updates
{
    public partial class DifferenceEmpty : CatraProto.Client.TL.Schemas.CloudChats.Updates.DifferenceBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1567990072; }

        [Newtonsoft.Json.JsonProperty("date")]
        public int Date { get; set; }

        [Newtonsoft.Json.JsonProperty("seq")]
        public int Seq { get; set; }


#nullable enable
        public DifferenceEmpty(int date, int seq)
        {
            Date = date;
            Seq = seq;

        }
#nullable disable
        internal DifferenceEmpty()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Date);
            writer.WriteInt32(Seq);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trydate = reader.ReadInt32();
            if (trydate.IsError)
            {
                return ReadResult<IObject>.Move(trydate);
            }
            Date = trydate.Value;
            var tryseq = reader.ReadInt32();
            if (tryseq.IsError)
            {
                return ReadResult<IObject>.Move(tryseq);
            }
            Seq = tryseq.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "updates.differenceEmpty";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new DifferenceEmpty
            {
                Date = Date,
                Seq = Seq
            };
            return newClonedObject;

        }
#nullable disable
    }
}