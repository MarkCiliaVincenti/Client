using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class BaseThemeNight : CatraProto.Client.TL.Schemas.CloudChats.BaseThemeBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1212997976; }



        public BaseThemeNight()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "baseThemeNight";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new BaseThemeNight();
            return newClonedObject;

        }
#nullable disable
    }
}