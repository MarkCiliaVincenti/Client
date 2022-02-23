using System;
using System.Collections.Generic;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PhoneCallProtocol : CatraProto.Client.TL.Schemas.CloudChats.PhoneCallProtocolBase
    {
        [Flags]
        public enum FlagsEnum
        {
            UdpP2p = 1 << 0,
            UdpReflector = 1 << 1
        }

        public static int StaticConstructorId
        {
            get => -58224696;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("udp_p2p")]
        public sealed override bool UdpP2p { get; set; }

        [Newtonsoft.Json.JsonProperty("udp_reflector")]
        public sealed override bool UdpReflector { get; set; }

        [Newtonsoft.Json.JsonProperty("min_layer")]
        public sealed override int MinLayer { get; set; }

        [Newtonsoft.Json.JsonProperty("max_layer")]
        public sealed override int MaxLayer { get; set; }

        [Newtonsoft.Json.JsonProperty("library_versions")]
        public sealed override IList<string> LibraryVersions { get; set; }


    #nullable enable
        public PhoneCallProtocol(int minLayer, int maxLayer, IList<string> libraryVersions)
        {
            MinLayer = minLayer;
            MaxLayer = maxLayer;
            LibraryVersions = libraryVersions;
        }
    #nullable disable
        internal PhoneCallProtocol()
        {
        }

        public override void UpdateFlags()
        {
            Flags = UdpP2p ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = UdpReflector ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(MinLayer);
            writer.Write(MaxLayer);
            writer.Write(LibraryVersions);
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            UdpP2p = FlagsHelper.IsFlagSet(Flags, 0);
            UdpReflector = FlagsHelper.IsFlagSet(Flags, 1);
            MinLayer = reader.Read<int>();
            MaxLayer = reader.Read<int>();
            LibraryVersions = reader.ReadVector<string>();
        }

        public override string ToString()
        {
            return "phoneCallProtocol";
        }
    }
}