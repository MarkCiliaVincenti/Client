using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateBotWebhookJSON : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        public static int StaticConstructorId
        {
            get => -2095595325;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("data")] public CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase Data { get; set; }


    #nullable enable
        public UpdateBotWebhookJSON(CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase data)
        {
            Data = data;
        }
    #nullable disable
        internal UpdateBotWebhookJSON()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Data);
        }

        public override void Deserialize(Reader reader)
        {
            Data = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>();
        }

        public override string ToString()
        {
            return "updateBotWebhookJSON";
        }
    }
}