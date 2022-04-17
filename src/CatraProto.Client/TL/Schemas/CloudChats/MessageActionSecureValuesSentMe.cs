using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class MessageActionSecureValuesSentMe : CatraProto.Client.TL.Schemas.CloudChats.MessageActionBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 455635795; }

        [Newtonsoft.Json.JsonProperty("values")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase> Values { get; set; }

        [Newtonsoft.Json.JsonProperty("credentials")]
        public CatraProto.Client.TL.Schemas.CloudChats.SecureCredentialsEncryptedBase Credentials { get; set; }


#nullable enable
        public MessageActionSecureValuesSentMe(List<CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase> values, CatraProto.Client.TL.Schemas.CloudChats.SecureCredentialsEncryptedBase credentials)
        {
            Values = values;
            Credentials = credentials;

        }
#nullable disable
        internal MessageActionSecureValuesSentMe()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkvalues = writer.WriteVector(Values, false);
            if (checkvalues.IsError)
            {
                return checkvalues;
            }
            var checkcredentials = writer.WriteObject(Credentials);
            if (checkcredentials.IsError)
            {
                return checkcredentials;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryvalues = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryvalues.IsError)
            {
                return ReadResult<IObject>.Move(tryvalues);
            }
            Values = tryvalues.Value;
            var trycredentials = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.SecureCredentialsEncryptedBase>();
            if (trycredentials.IsError)
            {
                return ReadResult<IObject>.Move(trycredentials);
            }
            Credentials = trycredentials.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messageActionSecureValuesSentMe";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}