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
    public partial class RestrictionReason : CatraProto.Client.TL.Schemas.CloudChats.RestrictionReasonBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -797791052; }

        [Newtonsoft.Json.JsonProperty("platform")]
        public sealed override string Platform { get; set; }

        [Newtonsoft.Json.JsonProperty("reason")]
        public sealed override string Reason { get; set; }

        [Newtonsoft.Json.JsonProperty("text")]
        public sealed override string Text { get; set; }


#nullable enable
        public RestrictionReason(string platform, string reason, string text)
        {
            Platform = platform;
            Reason = reason;
            Text = text;

        }
#nullable disable
        internal RestrictionReason()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Platform);

            writer.WriteString(Reason);

            writer.WriteString(Text);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryplatform = reader.ReadString();
            if (tryplatform.IsError)
            {
                return ReadResult<IObject>.Move(tryplatform);
            }
            Platform = tryplatform.Value;
            var tryreason = reader.ReadString();
            if (tryreason.IsError)
            {
                return ReadResult<IObject>.Move(tryreason);
            }
            Reason = tryreason.Value;
            var trytext = reader.ReadString();
            if (trytext.IsError)
            {
                return ReadResult<IObject>.Move(trytext);
            }
            Text = trytext.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "restrictionReason";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new RestrictionReason
            {
                Platform = Platform,
                Reason = Reason,
                Text = Text
            };
            return newClonedObject;

        }
#nullable disable
    }
}