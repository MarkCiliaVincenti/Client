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

using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class FavedStickers : CatraProto.Client.TL.Schemas.CloudChats.Messages.FavedStickersBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 750063767; }

        [Newtonsoft.Json.JsonProperty("hash")]
        public long Hash { get; set; }

        [Newtonsoft.Json.JsonProperty("packs")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.StickerPackBase> Packs { get; set; }

        [Newtonsoft.Json.JsonProperty("stickers")]
        public List<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> Stickers { get; set; }


#nullable enable
        public FavedStickers(long hash, List<CatraProto.Client.TL.Schemas.CloudChats.StickerPackBase> packs, List<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase> stickers)
        {
            Hash = hash;
            Packs = packs;
            Stickers = stickers;

        }
#nullable disable
        internal FavedStickers()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(Hash);
            var checkpacks = writer.WriteVector(Packs, false);
            if (checkpacks.IsError)
            {
                return checkpacks;
            }
            var checkstickers = writer.WriteVector(Stickers, false);
            if (checkstickers.IsError)
            {
                return checkstickers;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryhash = reader.ReadInt64();
            if (tryhash.IsError)
            {
                return ReadResult<IObject>.Move(tryhash);
            }
            Hash = tryhash.Value;
            var trypacks = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.StickerPackBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trypacks.IsError)
            {
                return ReadResult<IObject>.Move(trypacks);
            }
            Packs = trypacks.Value;
            var trystickers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trystickers.IsError)
            {
                return ReadResult<IObject>.Move(trystickers);
            }
            Stickers = trystickers.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.favedStickers";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new FavedStickers
            {
                Hash = Hash,
                Packs = new List<CatraProto.Client.TL.Schemas.CloudChats.StickerPackBase>()
            };
            foreach (var packs in Packs)
            {
                var clonepacks = (CatraProto.Client.TL.Schemas.CloudChats.StickerPackBase?)packs.Clone();
                if (clonepacks is null)
                {
                    return null;
                }
                newClonedObject.Packs.Add(clonepacks);
            }
            newClonedObject.Stickers = new List<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
            foreach (var stickers in Stickers)
            {
                var clonestickers = (CatraProto.Client.TL.Schemas.CloudChats.DocumentBase?)stickers.Clone();
                if (clonestickers is null)
                {
                    return null;
                }
                newClonedObject.Stickers.Add(clonestickers);
            }
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not FavedStickers castedOther)
            {
                return true;
            }
            if (Hash != castedOther.Hash)
            {
                return true;
            }
            var packssize = castedOther.Packs.Count;
            if (packssize != Packs.Count)
            {
                return true;
            }
            for (var i = 0; i < packssize; i++)
            {
                if (castedOther.Packs[i].Compare(Packs[i]))
                {
                    return true;
                }
            }
            var stickerssize = castedOther.Stickers.Count;
            if (stickerssize != Stickers.Count)
            {
                return true;
            }
            for (var i = 0; i < stickerssize; i++)
            {
                if (castedOther.Stickers[i].Compare(Stickers[i]))
                {
                    return true;
                }
            }
            return false;

        }

#nullable disable
    }
}