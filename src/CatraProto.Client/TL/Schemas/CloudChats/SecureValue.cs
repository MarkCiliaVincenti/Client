using System;
using System.Collections.Generic;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class SecureValue : CatraProto.Client.TL.Schemas.CloudChats.SecureValueBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Data = 1 << 0,
            FrontSide = 1 << 1,
            ReverseSide = 1 << 2,
            Selfie = 1 << 3,
            Translation = 1 << 6,
            Files = 1 << 4,
            PlainData = 1 << 5
        }

        public static int StaticConstructorId
        {
            get => 411017418;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("type")] public sealed override CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase Type { get; set; }

        [Newtonsoft.Json.JsonProperty("data")] public sealed override CatraProto.Client.TL.Schemas.CloudChats.SecureDataBase Data { get; set; }

        [Newtonsoft.Json.JsonProperty("front_side")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.SecureFileBase FrontSide { get; set; }

        [Newtonsoft.Json.JsonProperty("reverse_side")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.SecureFileBase ReverseSide { get; set; }

        [Newtonsoft.Json.JsonProperty("selfie")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.SecureFileBase Selfie { get; set; }

        [Newtonsoft.Json.JsonProperty("translation")]
        public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.SecureFileBase> Translation { get; set; }

        [Newtonsoft.Json.JsonProperty("files")]
        public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.SecureFileBase> Files { get; set; }

        [Newtonsoft.Json.JsonProperty("plain_data")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.SecurePlainDataBase PlainData { get; set; }

        [Newtonsoft.Json.JsonProperty("hash")] public sealed override byte[] Hash { get; set; }


    #nullable enable
        public SecureValue(CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase type, byte[] hash)
        {
            Type = type;
            Hash = hash;
        }
    #nullable disable
        internal SecureValue()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Data == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = FrontSide == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
            Flags = ReverseSide == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
            Flags = Selfie == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
            Flags = Translation == null ? FlagsHelper.UnsetFlag(Flags, 6) : FlagsHelper.SetFlag(Flags, 6);
            Flags = Files == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
            Flags = PlainData == null ? FlagsHelper.UnsetFlag(Flags, 5) : FlagsHelper.SetFlag(Flags, 5);
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Type);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(Data);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                writer.Write(FrontSide);
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.Write(ReverseSide);
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                writer.Write(Selfie);
            }

            if (FlagsHelper.IsFlagSet(Flags, 6))
            {
                writer.Write(Translation);
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                writer.Write(Files);
            }

            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                writer.Write(PlainData);
            }

            writer.Write(Hash);
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Type = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.SecureValueTypeBase>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                Data = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.SecureDataBase>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                FrontSide = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.SecureFileBase>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                ReverseSide = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.SecureFileBase>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 3))
            {
                Selfie = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.SecureFileBase>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 6))
            {
                Translation = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.SecureFileBase>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 4))
            {
                Files = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.SecureFileBase>();
            }

            if (FlagsHelper.IsFlagSet(Flags, 5))
            {
                PlainData = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.SecurePlainDataBase>();
            }

            Hash = reader.Read<byte[]>();
        }

        public override string ToString()
        {
            return "secureValue";
        }
    }
}