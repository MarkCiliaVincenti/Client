using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class RequestUrlAuth : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Peer = 1 << 1,
            MsgId = 1 << 1,
            ButtonId = 1 << 1,
            Url = 1 << 2
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => 428848198;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UrlAuthResultBase);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("msg_id")]
        public int? MsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("button_id")]
        public int? ButtonId { get; set; }

        [Newtonsoft.Json.JsonProperty("url")] public string Url { get; set; }


        public RequestUrlAuth()
        {
        }

        public void UpdateFlags()
        {
            Flags = Peer == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = MsgId == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = ButtonId == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = Url == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.Write(Peer);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.Write(MsgId.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.Write(ButtonId.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.Write(Url);
            }
        }

        public void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                MsgId = reader.Read<int>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                ButtonId = reader.Read<int>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                Url = reader.Read<string>();
            }
        }

        public override string ToString()
        {
            return "messages.requestUrlAuth";
        }
    }
}