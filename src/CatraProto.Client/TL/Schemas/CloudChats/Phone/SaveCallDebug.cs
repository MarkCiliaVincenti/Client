using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
    public partial class SaveCallDebug : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 662363518; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("peer")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("debug")]
        public CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase Debug { get; set; }


#nullable enable
        public SaveCallDebug(CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase peer, CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase debug)
        {
            Peer = peer;
            Debug = debug;

        }
#nullable disable

        internal SaveCallDebug()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkpeer = writer.WriteObject(Peer);
            if (checkpeer.IsError)
            {
                return checkpeer;
            }
            var checkdebug = writer.WriteObject(Debug);
            if (checkdebug.IsError)
            {
                return checkdebug;
            }

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }
            Peer = trypeer.Value;
            var trydebug = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.DataJSONBase>();
            if (trydebug.IsError)
            {
                return ReadResult<IObject>.Move(trydebug);
            }
            Debug = trydebug.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "phone.saveCallDebug";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}