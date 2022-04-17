using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public abstract class PaymentChargeBase : IObject
    {

        [Newtonsoft.Json.JsonProperty("id")]
        public abstract string Id { get; set; }

        [Newtonsoft.Json.JsonProperty("provider_charge_id")]
        public abstract string ProviderChargeId { get; set; }

        public abstract void UpdateFlags();
        public abstract ReadResult<IObject> Deserialize(Reader reader);
        public abstract WriteResult Serialize(Writer writer);
        public abstract int GetConstructorId();
    }
}
