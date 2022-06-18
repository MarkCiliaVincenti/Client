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
    public partial class ChannelForbidden : CatraProto.Client.TL.Schemas.CloudChats.ChatBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Broadcast = 1 << 5,
            Megagroup = 1 << 8,
            UntilDate = 1 << 16
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 399807445; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("broadcast")]
        public bool Broadcast { get; set; }

        [Newtonsoft.Json.JsonProperty("megagroup")]
        public bool Megagroup { get; set; }

        [Newtonsoft.Json.JsonProperty("id")]
        public sealed override long Id { get; set; }

        [Newtonsoft.Json.JsonProperty("access_hash")]
        public long AccessHash { get; set; }

        [Newtonsoft.Json.JsonProperty("title")]
        public string Title { get; set; }

        [Newtonsoft.Json.JsonProperty("until_date")]
        public int? UntilDate { get; set; }


#nullable enable
        public ChannelForbidden(long id, long accessHash, string title)
        {
            Id = id;
            AccessHash = accessHash;
            Title = title;

        }
#nullable disable
        internal ChannelForbidden()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Broadcast ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
            Flags = Megagroup ? FlagsHelper.SetFlag(Flags, 8) : FlagsHelper.UnsetFlag(Flags, 8);
            Flags = UntilDate == null ? FlagsHelper.UnsetFlag(Flags, 16) : FlagsHelper.SetFlag(Flags, 16);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt64(Id);
            writer.WriteInt64(AccessHash);

            writer.WriteString(Title);
            if (FlagsHelper.IsFlagSet(Flags, 16))
            {
                writer.WriteInt32(UntilDate.Value);
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
            Broadcast = FlagsHelper.IsFlagSet(Flags, 5);
            Megagroup = FlagsHelper.IsFlagSet(Flags, 8);
            var tryid = reader.ReadInt64();
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }
            Id = tryid.Value;
            var tryaccessHash = reader.ReadInt64();
            if (tryaccessHash.IsError)
            {
                return ReadResult<IObject>.Move(tryaccessHash);
            }
            AccessHash = tryaccessHash.Value;
            var trytitle = reader.ReadString();
            if (trytitle.IsError)
            {
                return ReadResult<IObject>.Move(trytitle);
            }
            Title = trytitle.Value;
            if (FlagsHelper.IsFlagSet(Flags, 16))
            {
                var tryuntilDate = reader.ReadInt32();
                if (tryuntilDate.IsError)
                {
                    return ReadResult<IObject>.Move(tryuntilDate);
                }
                UntilDate = tryuntilDate.Value;
            }

            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "channelForbidden";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new ChannelForbidden
            {
                Flags = Flags,
                Broadcast = Broadcast,
                Megagroup = Megagroup,
                Id = Id,
                AccessHash = AccessHash,
                Title = Title,
                UntilDate = UntilDate
            };
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not ChannelForbidden castedOther)
            {
                return true;
            }
            if (Flags != castedOther.Flags)
            {
                return true;
            }
            if (Broadcast != castedOther.Broadcast)
            {
                return true;
            }
            if (Megagroup != castedOther.Megagroup)
            {
                return true;
            }
            if (Id != castedOther.Id)
            {
                return true;
            }
            if (AccessHash != castedOther.AccessHash)
            {
                return true;
            }
            if (Title != castedOther.Title)
            {
                return true;
            }
            if (UntilDate != castedOther.UntilDate)
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}