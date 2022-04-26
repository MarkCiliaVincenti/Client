using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetEmojiKeywords : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 899735650; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("lang_code")]
        public string LangCode { get; set; }


#nullable enable
        public GetEmojiKeywords(string langCode)
        {
            LangCode = langCode;

        }
#nullable disable

        internal GetEmojiKeywords()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(LangCode);

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trylangCode = reader.ReadString();
            if (trylangCode.IsError)
            {
                return ReadResult<IObject>.Move(trylangCode);
            }
            LangCode = trylangCode.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.getEmojiKeywords";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetEmojiKeywords
            {
                LangCode = LangCode
            };
            return newClonedObject;

        }
#nullable disable
    }
}