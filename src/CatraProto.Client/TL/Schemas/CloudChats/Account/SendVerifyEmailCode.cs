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
    public partial class SendVerifyEmailCode : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1880182943; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonProperty("email")]
        public string Email { get; set; }


#nullable enable
        public SendVerifyEmailCode(string email)
        {
            Email = email;

        }
#nullable disable

        internal SendVerifyEmailCode()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(Email);

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryemail = reader.ReadString();
            if (tryemail.IsError)
            {
                return ReadResult<IObject>.Move(tryemail);
            }
            Email = tryemail.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "account.sendVerifyEmailCode";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new SendVerifyEmailCode
            {
                Email = Email
            };
            return newClonedObject;

        }

        public bool Compare(IObject other)
        {
            if (other is not SendVerifyEmailCode castedOther)
            {
                return true;
            }
            if (Email != castedOther.Email)
            {
                return true;
            }
            return false;

        }
#nullable disable
    }
}