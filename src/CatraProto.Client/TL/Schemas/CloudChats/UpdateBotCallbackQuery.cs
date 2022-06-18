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
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateBotCallbackQuery : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Data = 1 << 0,
            GameShortName = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1177566067; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("query_id")]
        public long QueryId { get; set; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("peer")]
        public CatraProto.Client.TL.Schemas.CloudChats.PeerBase Peer { get; set; }

        [Newtonsoft.Json.JsonProperty("msg_id")]
        public int MsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("chat_instance")]
        public long ChatInstance { get; set; }

        [Newtonsoft.Json.JsonProperty("data")]
        public byte[] Data { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("game_short_name")]
        public string GameShortName { get; set; }


#nullable enable
        public UpdateBotCallbackQuery(long queryId, long userId, CatraProto.Client.TL.Schemas.CloudChats.PeerBase peer, int msgId, long chatInstance)
        {
            QueryId = queryId;
            UserId = userId;
            Peer = peer;
            MsgId = msgId;
            ChatInstance = chatInstance;

        }
#nullable disable
        internal UpdateBotCallbackQuery()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Data == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = GameShortName == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt64(QueryId);
            writer.WriteInt64(UserId);
            var checkpeer = writer.WriteObject(Peer);
            if (checkpeer.IsError)
            {
                return checkpeer;
            }
            writer.WriteInt32(MsgId);
            writer.WriteInt64(ChatInstance);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {

                writer.WriteBytes(Data);
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {

                writer.WriteString(GameShortName);
            }


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
            var tryqueryId = reader.ReadInt64();
            if (tryqueryId.IsError)
            {
                return ReadResult<IObject>.Move(tryqueryId);
            }
            QueryId = tryqueryId.Value;
            var tryuserId = reader.ReadInt64();
            if (tryuserId.IsError)
            {
                return ReadResult<IObject>.Move(tryuserId);
            }
            UserId = tryuserId.Value;
            var trypeer = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
            if (trypeer.IsError)
            {
                return ReadResult<IObject>.Move(trypeer);
            }
            Peer = trypeer.Value;
            var trymsgId = reader.ReadInt32();
            if (trymsgId.IsError)
            {
                return ReadResult<IObject>.Move(trymsgId);
            }
            MsgId = trymsgId.Value;
            var trychatInstance = reader.ReadInt64();
            if (trychatInstance.IsError)
            {
                return ReadResult<IObject>.Move(trychatInstance);
            }
            ChatInstance = trychatInstance.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var trydata = reader.ReadBytes();
                if (trydata.IsError)
                {
                    return ReadResult<IObject>.Move(trydata);
                }
                Data = trydata.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var trygameShortName = reader.ReadString();
                if (trygameShortName.IsError)
                {
                    return ReadResult<IObject>.Move(trygameShortName);
                }
                GameShortName = trygameShortName.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "updateBotCallbackQuery";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateBotCallbackQuery
            {
                Flags = Flags,
                QueryId = QueryId,
                UserId = UserId
            };
            var clonePeer = (CatraProto.Client.TL.Schemas.CloudChats.PeerBase?)Peer.Clone();
            if (clonePeer is null)
            {
                return null;
            }
            newClonedObject.Peer = clonePeer;
            newClonedObject.MsgId = MsgId;
            newClonedObject.ChatInstance = ChatInstance;
            newClonedObject.Data = Data;
            newClonedObject.GameShortName = GameShortName;
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateBotCallbackQuery castedOther)
            {
                return true;
            }
            if (Flags != castedOther.Flags)
            {
                return true;
            }
            if (QueryId != castedOther.QueryId)
            {
                return true;
            }
            if (UserId != castedOther.UserId)
            {
                return true;
            }
            if (Peer.Compare(castedOther.Peer))
            {
                return true;
            }
            if (MsgId != castedOther.MsgId)
            {
                return true;
            }
            if (ChatInstance != castedOther.ChatInstance)
            {
                return true;
            }
            if (Data != castedOther.Data)
            {
                return true;
            }
            if (GameShortName != castedOther.GameShortName)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}