using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class TmpPassword : CatraProto.Client.TL.Schemas.CloudChats.Account.TmpPasswordBase
    {
        public static int StaticConstructorId
        {
            get => -614138572;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("tmp_password")]
        public sealed override byte[] TmpPasswordField { get; set; }

        [Newtonsoft.Json.JsonProperty("valid_until")]
        public sealed override int ValidUntil { get; set; }


    #nullable enable
        public TmpPassword(byte[] tmpPasswordField, int validUntil)
        {
            TmpPasswordField = tmpPasswordField;
            ValidUntil = validUntil;
        }
    #nullable disable
        internal TmpPassword()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(TmpPasswordField);
            writer.Write(ValidUntil);
        }

        public override void Deserialize(Reader reader)
        {
            TmpPasswordField = reader.Read<byte[]>();
            ValidUntil = reader.Read<int>();
        }

        public override string ToString()
        {
            return "account.tmpPassword";
        }
    }
}