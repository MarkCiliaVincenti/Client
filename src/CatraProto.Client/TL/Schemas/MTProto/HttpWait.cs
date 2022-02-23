using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class HttpWait : IMethod
    {
        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => -1835453025;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.MTProto.HttpWaitBase);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonProperty("max_delay")]
        public int MaxDelay { get; set; }

        [Newtonsoft.Json.JsonProperty("wait_after")]
        public int WaitAfter { get; set; }

        [Newtonsoft.Json.JsonProperty("max_wait")]
        public int MaxWait { get; set; }


    #nullable enable
        public HttpWait(int maxDelay, int waitAfter, int maxWait)
        {
            MaxDelay = maxDelay;
            WaitAfter = waitAfter;
            MaxWait = maxWait;
        }
    #nullable disable

        internal HttpWait()
        {
        }

        public void UpdateFlags()
        {
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(MaxDelay);
            writer.Write(WaitAfter);
            writer.Write(MaxWait);
        }

        public void Deserialize(Reader reader)
        {
            MaxDelay = reader.Read<int>();
            WaitAfter = reader.Read<int>();
            MaxWait = reader.Read<int>();
        }

        public override string ToString()
        {
            return "http_wait";
        }
    }
}