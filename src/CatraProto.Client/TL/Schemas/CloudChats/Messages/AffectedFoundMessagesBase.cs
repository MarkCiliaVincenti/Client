using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public abstract class AffectedFoundMessagesBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("pts")]
        public abstract int Pts { get; set; }

        [Newtonsoft.Json.JsonProperty("pts_count")]
        public abstract int PtsCount { get; set; }

        [Newtonsoft.Json.JsonProperty("offset")]
        public abstract int Offset { get; set; }

        [Newtonsoft.Json.JsonProperty("messages")]
        public abstract List<int> Messages { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
#nullable enable
        public abstract IObject? Clone();
#nullable disable
    }
}
