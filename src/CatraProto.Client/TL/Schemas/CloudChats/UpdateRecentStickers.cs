using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateRecentStickers : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        public static int StaticConstructorId
        {
            get => -1706939360;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }


        public UpdateRecentStickers()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
        }

        public override void Deserialize(Reader reader)
        {
        }

        public override string ToString()
        {
            return "updateRecentStickers";
        }
    }
}