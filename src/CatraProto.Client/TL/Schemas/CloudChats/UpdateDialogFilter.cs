using System;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateDialogFilter : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Filter = 1 << 0
        }

        public static int StaticConstructorId
        {
            get => 654302845;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonIgnore] public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("id")] public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty("filter")]
        public CatraProto.Client.TL.Schemas.CloudChats.DialogFilterBase Filter { get; set; }


    #nullable enable
        public UpdateDialogFilter(int id)
        {
            Id = id;
        }
    #nullable disable
        internal UpdateDialogFilter()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Filter == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            UpdateFlags();
            writer.Write(Flags);
            writer.Write(Id);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                writer.Write(Filter);
            }
        }

        public override void Deserialize(Reader reader)
        {
            Flags = reader.Read<int>();
            Id = reader.Read<int>();
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                Filter = reader.Read<CatraProto.Client.TL.Schemas.CloudChats.DialogFilterBase>();
            }
        }

        public override string ToString()
        {
            return "updateDialogFilter";
        }
    }
}