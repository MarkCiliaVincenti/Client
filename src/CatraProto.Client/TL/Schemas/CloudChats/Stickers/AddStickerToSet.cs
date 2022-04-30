/*
CatraProto, a C# library that implements the MTProto protocol and the Telegram API.
Copyright (C) 2022 Aquatica <aquathing@protonmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Stickers
{
    public partial class AddStickerToSet : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -2041315650; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("stickerset")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase Stickerset { get; set; }

        [Newtonsoft.Json.JsonProperty("sticker")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetItemBase Sticker { get; set; }


#nullable enable
        public AddStickerToSet(CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase stickerset, CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetItemBase sticker)
        {
            Stickerset = stickerset;
            Sticker = sticker;

        }
#nullable disable

        internal AddStickerToSet()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkstickerset = writer.WriteObject(Stickerset);
            if (checkstickerset.IsError)
            {
                return checkstickerset;
            }
            var checksticker = writer.WriteObject(Sticker);
            if (checksticker.IsError)
            {
                return checksticker;
            }

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trystickerset = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase>();
            if (trystickerset.IsError)
            {
                return ReadResult<IObject>.Move(trystickerset);
            }
            Stickerset = trystickerset.Value;
            var trysticker = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetItemBase>();
            if (trysticker.IsError)
            {
                return ReadResult<IObject>.Move(trysticker);
            }
            Sticker = trysticker.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "stickers.addStickerToSet";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new AddStickerToSet();
            var cloneStickerset = (CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetBase?)Stickerset.Clone();
            if (cloneStickerset is null)
            {
                return null;
            }
            newClonedObject.Stickerset = cloneStickerset;
            var cloneSticker = (CatraProto.Client.TL.Schemas.CloudChats.InputStickerSetItemBase?)Sticker.Clone();
            if (cloneSticker is null)
            {
                return null;
            }
            newClonedObject.Sticker = cloneSticker;
            return newClonedObject;

        }
#nullable disable
    }
}