using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetMessages : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1673946374; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("id")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.InputMessageBase> Id { get; set; }


#nullable enable
        public GetMessages(List<CatraProto.Client.TL.Schemas.CloudChats.InputMessageBase> id)
        {
            Id = id;

        }
#nullable disable

        internal GetMessages()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkid = writer.WriteVector(Id, false);
            if (checkid.IsError)
            {
                return checkid;
            }

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryid = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.InputMessageBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }
            Id = tryid.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.getMessages";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}