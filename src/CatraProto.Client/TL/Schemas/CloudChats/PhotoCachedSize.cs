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
    public partial class PhotoCachedSize : CatraProto.Client.TL.Schemas.CloudChats.PhotoSizeBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 35527382; }

        [Newtonsoft.Json.JsonProperty("type")]
        public sealed override string Type { get; set; }

        [Newtonsoft.Json.JsonProperty("w")]
        public int W { get; set; }

        [Newtonsoft.Json.JsonProperty("h")]
        public int H { get; set; }

        [Newtonsoft.Json.JsonProperty("bytes")]
        public byte[] Bytes { get; set; }


#nullable enable
        public PhotoCachedSize(string type, int w, int h, byte[] bytes)
        {
            Type = type;
            W = w;
            H = h;
            Bytes = bytes;

        }
#nullable disable
        internal PhotoCachedSize()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Type);
            writer.WriteInt32(W);
            writer.WriteInt32(H);

            writer.WriteBytes(Bytes);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trytype = reader.ReadString();
            if (trytype.IsError)
            {
                return ReadResult<IObject>.Move(trytype);
            }
            Type = trytype.Value;
            var tryw = reader.ReadInt32();
            if (tryw.IsError)
            {
                return ReadResult<IObject>.Move(tryw);
            }
            W = tryw.Value;
            var tryh = reader.ReadInt32();
            if (tryh.IsError)
            {
                return ReadResult<IObject>.Move(tryh);
            }
            H = tryh.Value;
            var trybytes = reader.ReadBytes();
            if (trybytes.IsError)
            {
                return ReadResult<IObject>.Move(trybytes);
            }
            Bytes = trybytes.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "photoCachedSize";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PhotoCachedSize
            {
                Type = Type,
                W = W,
                H = H,
                Bytes = Bytes
            };
            return newClonedObject;

        }
#nullable disable
    }
}