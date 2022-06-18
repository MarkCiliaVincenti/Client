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

namespace CatraProto.Client.TL.Schemas.CloudChats.Account
{
    public partial class DeleteAccount : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1099779595; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("reason")]
        public string Reason { get; set; }


#nullable enable
        public DeleteAccount(string reason)
        {
            Reason = reason;

        }
#nullable disable

        internal DeleteAccount()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Reason);

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryreason = reader.ReadString();
            if (tryreason.IsError)
            {
                return ReadResult<IObject>.Move(tryreason);
            }
            Reason = tryreason.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "account.deleteAccount";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new DeleteAccount
            {
                Reason = Reason
            };
            return newClonedObject;

        }

        public bool Compare(IObject other)
        {
            if (other is not DeleteAccount castedOther)
            {
                return true;
            }
            if (Reason != castedOther.Reason)
            {
                return true;
            }
            return false;

        }
#nullable disable
    }
}