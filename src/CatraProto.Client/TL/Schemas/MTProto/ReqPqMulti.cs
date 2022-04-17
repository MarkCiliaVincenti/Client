using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class ReqPqMulti : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1099002127; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("nonce")]
        public System.Numerics.BigInteger Nonce { get; set; }


#nullable enable
        public ReqPqMulti(System.Numerics.BigInteger nonce)
        {
            Nonce = nonce;

        }
#nullable disable

        internal ReqPqMulti()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkNonce = writer.WriteBigInteger(Nonce);
            if (checkNonce.IsError) { return checkNonce; }

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trynonce = reader.ReadBigInteger(128);
            if (trynonce.IsError)
            {
                return ReadResult<IObject>.Move(trynonce);
            }
            Nonce = trynonce.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "req_pq_multi";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}