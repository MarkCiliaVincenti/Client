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
    public partial class UpdatePasswordSettings : IMethod
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1516564433; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Bool;

        [Newtonsoft.Json.JsonProperty("password")]
        public CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase Password { get; set; }

        [Newtonsoft.Json.JsonProperty("new_settings")]
        public CatraProto.Client.TL.Schemas.CloudChats.Account.PasswordInputSettingsBase NewSettings { get; set; }


#nullable enable
        public UpdatePasswordSettings(CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase password, CatraProto.Client.TL.Schemas.CloudChats.Account.PasswordInputSettingsBase newSettings)
        {
            Password = password;
            NewSettings = newSettings;

        }
#nullable disable

        internal UpdatePasswordSettings()
        {
        }

        public void UpdateFlags()
        {

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkpassword = writer.WriteObject(Password);
            if (checkpassword.IsError)
            {
                return checkpassword;
            }
            var checknewSettings = writer.WriteObject(NewSettings);
            if (checknewSettings.IsError)
            {
                return checknewSettings;
            }

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var trypassword = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase>();
            if (trypassword.IsError)
            {
                return ReadResult<IObject>.Move(trypassword);
            }
            Password = trypassword.Value;
            var trynewSettings = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.Account.PasswordInputSettingsBase>();
            if (trynewSettings.IsError)
            {
                return ReadResult<IObject>.Move(trynewSettings);
            }
            NewSettings = trynewSettings.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "account.updatePasswordSettings";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new UpdatePasswordSettings();
            var clonePassword = (CatraProto.Client.TL.Schemas.CloudChats.InputCheckPasswordSRPBase?)Password.Clone();
            if (clonePassword is null)
            {
                return null;
            }
            newClonedObject.Password = clonePassword;
            var cloneNewSettings = (CatraProto.Client.TL.Schemas.CloudChats.Account.PasswordInputSettingsBase?)NewSettings.Clone();
            if (cloneNewSettings is null)
            {
                return null;
            }
            newClonedObject.NewSettings = cloneNewSettings;
            return newClonedObject;

        }
#nullable disable
    }
}