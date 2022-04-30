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
namespace CatraProto.Client.TL.Schemas.CloudChats.Auth
{
    public partial class PasswordRecovery : CatraProto.Client.TL.Schemas.CloudChats.Auth.PasswordRecoveryBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 326715557; }

        [Newtonsoft.Json.JsonProperty("email_pattern")]
        public sealed override string EmailPattern { get; set; }


#nullable enable
        public PasswordRecovery(string emailPattern)
        {
            EmailPattern = emailPattern;

        }
#nullable disable
        internal PasswordRecovery()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);

            writer.WriteString(EmailPattern);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryemailPattern = reader.ReadString();
            if (tryemailPattern.IsError)
            {
                return ReadResult<IObject>.Move(tryemailPattern);
            }
            EmailPattern = tryemailPattern.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "auth.passwordRecovery";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new PasswordRecovery
            {
                EmailPattern = EmailPattern
            };
            return newClonedObject;

        }
#nullable disable
    }
}