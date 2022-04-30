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
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class MessagePeerReaction : CatraProto.Client.TL.Schemas.CloudChats.MessagePeerReactionBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Big = 1 << 0,
            Unread = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1370914559; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("big")]
        public sealed override bool Big { get; set; }

        [Newtonsoft.Json.JsonProperty("unread")]
        public sealed override bool Unread { get; set; }

        [Newtonsoft.Json.JsonProperty("peer_id")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.PeerBase PeerId { get; set; }

        [Newtonsoft.Json.JsonProperty("reaction")]
        public sealed override string Reaction { get; set; }


#nullable enable
        public MessagePeerReaction(CatraProto.Client.TL.Schemas.CloudChats.PeerBase peerId, string reaction)
        {
            PeerId = peerId;
            Reaction = reaction;

        }
#nullable disable
        internal MessagePeerReaction()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Big ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
            Flags = Unread ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            var checkpeerId = writer.WriteObject(PeerId);
            if (checkpeerId.IsError)
            {
                return checkpeerId;
            }

            writer.WriteString(Reaction);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }
            Flags = tryflags.Value;
            Big = FlagsHelper.IsFlagSet(Flags, 0);
            Unread = FlagsHelper.IsFlagSet(Flags, 1);
            var trypeerId = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
            if (trypeerId.IsError)
            {
                return ReadResult<IObject>.Move(trypeerId);
            }
            PeerId = trypeerId.Value;
            var tryreaction = reader.ReadString();
            if (tryreaction.IsError)
            {
                return ReadResult<IObject>.Move(tryreaction);
            }
            Reaction = tryreaction.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messagePeerReaction";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MessagePeerReaction
            {
                Flags = Flags,
                Big = Big,
                Unread = Unread
            };
            var clonePeerId = (CatraProto.Client.TL.Schemas.CloudChats.PeerBase?)PeerId.Clone();
            if (clonePeerId is null)
            {
                return null;
            }
            newClonedObject.PeerId = clonePeerId;
            newClonedObject.Reaction = Reaction;
            return newClonedObject;

        }
#nullable disable
    }
}