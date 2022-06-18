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
namespace CatraProto.Client.TL.Schemas.MTProto
{
    public partial class DestroySessionNone : CatraProto.Client.TL.Schemas.MTProto.DestroySessionResBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1658015945; }

        [Newtonsoft.Json.JsonProperty("session_id")]
        public sealed override long SessionId { get; set; }


#nullable enable
        public DestroySessionNone(long sessionId)
        {
            SessionId = sessionId;

        }
#nullable disable
        internal DestroySessionNone()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt64(SessionId);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trysessionId = reader.ReadInt64();
            if (trysessionId.IsError)
            {
                return ReadResult<IObject>.Move(trysessionId);
            }
            SessionId = trysessionId.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "destroy_session_none";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new DestroySessionNone
            {
                SessionId = SessionId
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not DestroySessionNone castedOther)
            {
                return true;
            }
            if (SessionId != castedOther.SessionId)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}