using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UrlAuthResultRequest : CatraProto.Client.TL.Schemas.CloudChats.UrlAuthResultBase
    {
        [Flags]
        public enum FlagsEnum
        {
            RequestWriteAccess = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1831650802; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("request_write_access")]
        public bool RequestWriteAccess { get; set; }

        [Newtonsoft.Json.JsonProperty("bot")]
        public CatraProto.Client.TL.Schemas.CloudChats.UserBase Bot { get; set; }

        [Newtonsoft.Json.JsonProperty("domain")]
        public string Domain { get; set; }


#nullable enable
        public UrlAuthResultRequest(CatraProto.Client.TL.Schemas.CloudChats.UserBase bot, string domain)
        {
            Bot = bot;
            Domain = domain;

        }
#nullable disable
        internal UrlAuthResultRequest()
        {
        }

        public override void UpdateFlags()
        {
            Flags = RequestWriteAccess ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkbot = writer.WriteObject(Bot);
            if (checkbot.IsError)
            {
                return checkbot;
            }

            writer.WriteString(Domain);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }
            Flags = tryflags.Value;
            RequestWriteAccess = FlagsHelper.IsFlagSet(Flags, 0);
            var trybot = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.UserBase>();
            if (trybot.IsError)
            {
                return ReadResult<IObject>.Move(trybot);
            }
            Bot = trybot.Value;
            var trydomain = reader.ReadString();
            if (trydomain.IsError)
            {
                return ReadResult<IObject>.Move(trydomain);
            }
            Domain = trydomain.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "urlAuthResultRequest";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }
    }
}