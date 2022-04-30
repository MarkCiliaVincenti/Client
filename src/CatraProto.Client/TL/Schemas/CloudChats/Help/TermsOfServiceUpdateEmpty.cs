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
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
    public partial class TermsOfServiceUpdateEmpty : CatraProto.Client.TL.Schemas.CloudChats.Help.TermsOfServiceUpdateBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -483352705; }

        [Newtonsoft.Json.JsonProperty("expires")]
        public sealed override int Expires { get; set; }


#nullable enable
        public TermsOfServiceUpdateEmpty(int expires)
        {
            Expires = expires;

        }
#nullable disable
        internal TermsOfServiceUpdateEmpty()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(Expires);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryexpires = reader.ReadInt32();
            if (tryexpires.IsError)
            {
                return ReadResult<IObject>.Move(tryexpires);
            }
            Expires = tryexpires.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "help.termsOfServiceUpdateEmpty";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new TermsOfServiceUpdateEmpty
            {
                Expires = Expires
            };
            return newClonedObject;

        }
#nullable disable
    }
}