using System;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class EncryptedChatDiscarded : CatraProto.Client.TL.Schemas.CloudChats.EncryptedChatBase
    {
        [Flags]
        public enum FlagsEnum
        {
            HistoryDeleted = 1 << 0
        }

        public static int StaticConstructorId
        {
            get => 505183301;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("history_deleted")]
        public bool HistoryDeleted { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public sealed override int Id { get; set; }


    #nullable enable
        public EncryptedChatDiscarded(int id)
        {
            Id = id;
        }
    #nullable disable
        internal EncryptedChatDiscarded()
        {
        }

        public override void UpdateFlags()
        {
            Flags = HistoryDeleted ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Id);
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            HistoryDeleted = FlagsHelper.IsFlagSet(Flags, 0);
            Id = reader.Read<int>();
        }

        public override string ToString()
        {
            return "encryptedChatDiscarded";
        }
    }
}