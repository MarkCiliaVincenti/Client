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
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class MessageEntitySpoiler : CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 852137487; }

        [Newtonsoft.Json.JsonProperty("offset")]
        public sealed override int Offset { get; set; }

        [Newtonsoft.Json.JsonProperty("length")]
        public sealed override int Length { get; set; }


#nullable enable
        public MessageEntitySpoiler(int offset, int length)
        {
            Offset = offset;
            Length = length;

        }
#nullable disable
        internal MessageEntitySpoiler()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Offset);
            writer.WriteInt32(Length);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryoffset = reader.ReadInt32();
            if (tryoffset.IsError)
            {
                return ReadResult<IObject>.Move(tryoffset);
            }
            Offset = tryoffset.Value;
            var trylength = reader.ReadInt32();
            if (trylength.IsError)
            {
                return ReadResult<IObject>.Move(trylength);
            }
            Length = trylength.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messageEntitySpoiler";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MessageEntitySpoiler
            {
                Offset = Offset,
                Length = Length
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not MessageEntitySpoiler castedOther)
            {
                return true;
            }
            if (Offset != castedOther.Offset)
            {
                return true;
            }
            if (Length != castedOther.Length)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}