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

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class GetUnreadReactions : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -396644838; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("peer")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("offset_id")]
        public int OffsetId { get; set; }

        [Newtonsoft.Json.JsonProperty("add_offset")]
        public int AddOffset { get; set; }

        [Newtonsoft.Json.JsonProperty("limit")]
        public int Limit { get; set; }

        [Newtonsoft.Json.JsonProperty("max_id")]
        public int MaxId { get; set; }

        [Newtonsoft.Json.JsonProperty("min_id")]
        public int MinId { get; set; }


#nullable enable
        public GetUnreadReactions(CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase peer, int offsetId, int addOffset, int limit, int maxId, int minId)
        {
            Peer = peer;
            OffsetId = offsetId;
            AddOffset = addOffset;
            Limit = limit;
            MaxId = maxId;
            MinId = minId;

        }
#nullable disable

        internal GetUnreadReactions()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkpeer = writer.WriteObject(Peer);
            if (checkpeer.IsError)
            {
                return checkpeer;
            }
            writer.WriteInt32(OffsetId);
            writer.WriteInt32(AddOffset);
            writer.WriteInt32(Limit);
            writer.WriteInt32(MaxId);
            writer.WriteInt32(MinId);

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }
            Peer = trypeer.Value;
            var tryoffsetId = reader.ReadInt32();
            if (tryoffsetId.IsError)
            {
                return ReadResult<IObject>.Move(tryoffsetId);
            }
            OffsetId = tryoffsetId.Value;
            var tryaddOffset = reader.ReadInt32();
            if (tryaddOffset.IsError)
            {
                return ReadResult<IObject>.Move(tryaddOffset);
            }
            AddOffset = tryaddOffset.Value;
            var trylimit = reader.ReadInt32();
            if (trylimit.IsError)
            {
                return ReadResult<IObject>.Move(trylimit);
            }
            Limit = trylimit.Value;
            var trymaxId = reader.ReadInt32();
            if (trymaxId.IsError)
            {
                return ReadResult<IObject>.Move(trymaxId);
            }
            MaxId = trymaxId.Value;
            var tryminId = reader.ReadInt32();
            if (tryminId.IsError)
            {
                return ReadResult<IObject>.Move(tryminId);
            }
            MinId = tryminId.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.getUnreadReactions";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new GetUnreadReactions();
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.InputPeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }
            newClonedObject.Peer = clonePeer;
            newClonedObject.OffsetId = OffsetId;
            newClonedObject.AddOffset = AddOffset;
            newClonedObject.Limit = Limit;
            newClonedObject.MaxId = MaxId;
            newClonedObject.MinId = MinId;
            return newClonedObject;

        }

        public bool Compare(IObject other)
        {
            if (other is not GetUnreadReactions castedOther)
            {
                return true;
            }
            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }
            if (OffsetId != castedOther.OffsetId)
            {
                return true;
            }
            if (AddOffset != castedOther.AddOffset)
            {
                return true;
            }
            if (Limit != castedOther.Limit)
            {
                return true;
            }
            if (MaxId != castedOther.MaxId)
            {
                return true;
            }
            if (MinId != castedOther.MinId)
            {
                return true;
            }
            return false;

        }
#nullable disable
    }
}