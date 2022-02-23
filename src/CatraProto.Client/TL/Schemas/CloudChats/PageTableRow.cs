using System.Collections.Generic;
using CatraProto.TL;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class PageTableRow : CatraProto.Client.TL.Schemas.CloudChats.PageTableRowBase
    {
        public static int StaticConstructorId
        {
            get => -524237339;
        }

        [Newtonsoft.Json.JsonIgnore]
        public int ConstructorId
        {
            get => StaticConstructorId;
        }

        [Newtonsoft.Json.JsonProperty("cells")]
        public sealed override IList<CatraProto.Client.TL.Schemas.CloudChats.PageTableCellBase> Cells { get; set; }


    #nullable enable
        public PageTableRow(IList<CatraProto.Client.TL.Schemas.CloudChats.PageTableCellBase> cells)
        {
            Cells = cells;
        }
    #nullable disable
        internal PageTableRow()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override void Serialize(Writer writer)
        {
            writer.Write(ConstructorId);
            writer.Write(Cells);
        }

        public override void Deserialize(Reader reader)
        {
            Cells = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PageTableCellBase>();
        }

        public override string ToString()
        {
            return "pageTableRow";
        }
    }
}