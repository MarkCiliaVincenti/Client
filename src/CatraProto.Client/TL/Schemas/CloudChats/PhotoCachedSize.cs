using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PhotoCachedSize : CatraProto.Client.TL.Schemas.CloudChats.PhotoSizeBase
    {
        public static int StaticConstructorId
        {
            get => 35527382;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("type")] public sealed override string Type { get; set; }

        [Newtonsoft.Json.JsonProperty("w")] public int W { get; set; }

        [Newtonsoft.Json.JsonProperty("h")] public int H { get; set; }

        [Newtonsoft.Json.JsonProperty("bytes")]
        public byte[] Bytes { get; set; }


    #nullable enable
        public PhotoCachedSize(string type, int w, int h, byte[] bytes)
        {
            Type = type;
            W = w;
            H = h;
            Bytes = bytes;
        }
    #nullable disable
        internal PhotoCachedSize()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Type);
            writer.Write(W);
            writer.Write(H);
            writer.Write(Bytes);
        }

        public override void Deserialize(Reader reader)
        {
            Type = reader.Read<string>();
            W = reader.Read<int>();
            H = reader.Read<int>();
            Bytes = reader.Read<byte[]>();
        }

        public override string ToString()
        {
            return "photoCachedSize";
        }
    }
}