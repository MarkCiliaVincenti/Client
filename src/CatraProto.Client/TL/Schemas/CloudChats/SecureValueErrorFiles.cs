using System.Collections.Generic;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class SecureValueErrorFiles : CatraProto.Client.TL.Schemas.CloudChats.SecureValueErrorBase
    {
        public static int StaticConstructorId
        {
            get => 1717706985;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("type")] public sealed override CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase Type { get; set; }

        [Newtonsoft.Json.JsonProperty("file_hash")]
        public IList<byte[]> FileHash { get; set; }

        [Newtonsoft.Json.JsonProperty("text")] public sealed override string Text { get; set; }


    #nullable enable
        public SecureValueErrorFiles(CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase type, IList<byte[]> fileHash, string text)
        {
            Type = type;
            FileHash = fileHash;
            Text = text;
        }
    #nullable disable
        internal SecureValueErrorFiles()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Type);
            writer.Write(FileHash);
            writer.Write(Text);
        }

        public override void Deserialize(Reader reader)
        {
            Type = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase>();
            FileHash = reader.ReadVector<byte[]>();
            Text = reader.Read<string>();
        }

        public override string ToString()
        {
            return "secureValueErrorFiles";
        }
    }
}