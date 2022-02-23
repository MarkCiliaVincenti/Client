using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class SendMedia : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Silent = 1 << 5,
            Background = 1 << 6,
            ClearDraft = 1 << 7,
            ReplyToMsgId = 1 << 0,
            ReplyMarkup = 1 << 2,
            Entities = 1 << 3,
            ScheduleDate = 1 << 10,
            SendAs = 1 << 13
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int StaticConstructorId
        {
            get => -497026848;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] System.Type IMethod.Type { get; init; } = typeof(CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase);

        [Newtonsoft.Json.JsonIgnore] bool IMethod.IsVector { get; init; } = false;

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("silent")]
        public bool Silent { get; set; }

        [Newtonsoft.Json.JsonProperty("background")]
        public bool Background { get; set; }

        [Newtonsoft.Json.JsonProperty("clear_draft")]
        public bool ClearDraft { get; set; }

        [Newtonsoft.Json.JsonProperty("peer")] public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("reply_to_msg_id")]
        public int? ReplyToMsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("media")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase Media { get; set; }

        [Newtonsoft.Json.JsonProperty("message")]
        public string Message { get; set; }

        [Newtonsoft.Json.JsonProperty("random_id")]
        public long RandomId { get; set; }

        [Newtonsoft.Json.JsonProperty("reply_markup")]
        public CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase ReplyMarkup { get; set; }

        [Newtonsoft.Json.JsonProperty("entities")]
        public IList<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> Entities { get; set; }

        [Newtonsoft.Json.JsonProperty("schedule_date")]
        public int? ScheduleDate { get; set; }

        [Newtonsoft.Json.JsonProperty("send_as")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase SendAs { get; set; }


    #nullable enable
        public SendMedia(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase media, string message, long randomId)
        {
            Peer = peer;
            Media = media;
            Message = message;
            RandomId = randomId;
        }
    #nullable disable

        internal SendMedia()
        {
        }

        public void UpdateFlags()
        {
            Flags = Silent ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
            Flags = Background ? FlagsHelper.SetFlag(Flags, 6) : FlagsHelper.UnsetFlag(Flags, 6);
            Flags = ClearDraft ? FlagsHelper.SetFlag(Flags, 7) : FlagsHelper.UnsetFlag(Flags, 7);
            Flags = ReplyToMsgId == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = ReplyMarkup == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = Entities == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
            Flags = ScheduleDate == null ? FlagsHelper.UnsetFlag(Flags, 10) : FlagsHelper.SetFlag(Flags, 10);
            Flags = SendAs == null ? FlagsHelper.UnsetFlag(Flags, 13) : FlagsHelper.SetFlag(Flags, 13);
        }

        public void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Peer);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(ReplyToMsgId.Value);
            }

            writer.Write(Media);
            writer.Write(Message);
            writer.Write(RandomId);
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.Write(ReplyMarkup);
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                writer.Write(Entities);
            }

            if (FlagsHelper.IsFlagSet(Flags, 10))
            {
                writer.Write(ScheduleDate.Value);
            }

            if (FlagsHelper.IsFlagSet(Flags, 13))
            {
                writer.Write(SendAs);
            }
        }

        public void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Silent = FlagsHelper.IsFlagSet(Flags, 5);
            Background = FlagsHelper.IsFlagSet(Flags, 6);
            ClearDraft = FlagsHelper.IsFlagSet(Flags, 7);
            Peer = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                ReplyToMsgId = reader.Read<int>();
            }

            Media = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase>();
            Message = reader.Read<string>();
            RandomId = reader.Read<long>();
            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                ReplyMarkup = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.ReplyMarkupBase>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                Entities = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 10))
            {
                ScheduleDate = reader.Read<int>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 13))
            {
                SendAs = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            }
        }

        public override string ToString()
        {
            return "messages.sendMedia";
        }
    }
}