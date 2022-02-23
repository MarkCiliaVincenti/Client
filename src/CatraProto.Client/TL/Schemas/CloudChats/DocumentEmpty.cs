using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class DocumentEmpty : CatraProto.Client.TL.Schemas.CloudChats.DocumentBase
    {
        public static int StaticConstructorId
        {
            get => 922273905;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("id")] public sealed override long Id { get; set; }


    #nullable enable
        public DocumentEmpty(long id)
        {
            Id = id;
        }
    #nullable disable
        internal DocumentEmpty()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Id);
        }

        public override void Deserialize(Reader reader)
        {
            Id = reader.Read<long>();
        }

        public override string ToString()
        {
            return "documentEmpty";
        }
    }
}