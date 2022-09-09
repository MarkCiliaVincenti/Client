using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class TextSubscript : CatraProto.Client.TL.Schemas.CloudChats.RichTextBase
    {
        [Newtonsoft.Json.JsonIgnore] public static int ConstructorId { get => -311786236; }

        [Newtonsoft.Json.JsonProperty("text")] public CatraProto.Client.TL.Schemas.CloudChats.RichTextBase Text { get; set; }


#nullable enable
        public TextSubscript(CatraProto.Client.TL.Schemas.CloudChats.RichTextBase text)
        {
            Text = text;
        }
#nullable disable
        internal TextSubscript()
        {
        }

        public override void UpdateFlags()
        {
        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checktext = writer.WriteObject(Text);
            if (checktext.IsError)
            {
                return checktext;
            }

            return new WriteResult();
        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trytext = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.RichTextBase>();
            if (trytext.IsError)
            {
                return ReadResult<IObject>.Move(trytext);
            }

            Text = trytext.Value;
            return new ReadResult<IObject>(this);
        }

        public override string ToString()
        {
            return "textSubscript";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new TextSubscript();
            var cloneText = (CatraProto.Client.TL.Schemas.CloudChats.RichTextBase?)Text.Clone();
            if (cloneText is null)
            {
                return null;
            }

            newClonedObject.Text = cloneText;
            return newClonedObject;
        }

        public override bool Compare(IObject other)
        {
            if (other is not TextSubscript castedOther)
            {
                return true;
            }

            if (Text.Compare(castedOther.Text))
            {
                return true;
            }

            return false;
        }

#nullable disable
    }
}