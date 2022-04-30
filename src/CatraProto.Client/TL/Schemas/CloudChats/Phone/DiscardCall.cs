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

using System;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Phone
{
    public partial class DiscardCall : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Video = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1295269440; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("video")]
        public bool Video { get; set; }

        [Newtonsoft.Json.JsonProperty("peer")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("duration")]
        public int Duration { get; set; }

        [Newtonsoft.Json.JsonProperty("reason")]
        public CatraProto.Client.TL.Schemas.CloudChats.PhoneCallDiscardReasonBase Reason { get; set; }

        [Newtonsoft.Json.JsonProperty("connection_id")]
        public long ConnectionId { get; set; }


#nullable enable
        public DiscardCall(CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase peer, int duration, CatraProto.Client.TL.Schemas.CloudChats.PhoneCallDiscardReasonBase reason, long connectionId)
        {
            Peer = peer;
            Duration = duration;
            Reason = reason;
            ConnectionId = connectionId;

        }
#nullable disable

        internal DiscardCall()
        {
        }

        public void UpdateFlags()
        {
            Flags = Video ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkpeer = writer.WriteObject(Peer);
            if (checkpeer.IsError)
            {
                return checkpeer;
            }
            writer.WriteInt32(Duration);
            var checkreason = writer.WriteObject(Reason);
            if (checkreason.IsError)
            {
                return checkreason;
            }
            writer.WriteInt64(ConnectionId);

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }
            Flags = tryflags.Value;
            Video = FlagsHelper.IsFlagSet(Flags, 0);
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }
            Peer = trypeer.Value;
            var tryduration = reader.ReadInt32();
            if (tryduration.IsError)
            {
                return ReadResult<IObject>.Move(tryduration);
            }
            Duration = tryduration.Value;
            var tryreason = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PhoneCallDiscardReasonBase>();
            if (tryreason.IsError)
            {
                return ReadResult<IObject>.Move(tryreason);
            }
            Reason = tryreason.Value;
            var tryconnectionId = reader.ReadInt64();
            if (tryconnectionId.IsError)
            {
                return ReadResult<IObject>.Move(tryconnectionId);
            }
            ConnectionId = tryconnectionId.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "phone.discardCall";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new DiscardCall
            {
                Flags = Flags,
                Video = Video
            };
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPhoneCallBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }
            newClonedObject.Peer = clonePeer;
            newClonedObject.Duration = Duration;
            var cloneReason = (CatraProto.Client.TL.Schemas.CloudChats.PhoneCallDiscardReasonBase?)Reason.Clone();
            if (cloneReason is null)
            {
                return null;
            }
            newClonedObject.Reason = cloneReason;
            newClonedObject.ConnectionId = ConnectionId;
            return newClonedObject;

        }
#nullable disable
    }
}