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
    public partial class UpdateShort : CatraProto.Client.TL.Schemas.CloudChats.UpdatesBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 2027216577; }

        [Newtonsoft.Json.JsonProperty("update")]
        public CatraProto.Client.TL.Schemas.CloudChats.UpdateBase Update { get; set; }

        [Newtonsoft.Json.JsonProperty("date")]
        public int Date { get; set; }


#nullable enable
        public UpdateShort(CatraProto.Client.TL.Schemas.CloudChats.UpdateBase update, int date)
        {
            Update = update;
            Date = date;

        }
#nullable disable
        internal UpdateShort()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkupdate = writer.WriteObject(Update);
            if (checkupdate.IsError)
            {
                return checkupdate;
            }
            writer.WriteInt32(Date);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryupdate = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.UpdateBase>();
            if (tryupdate.IsError)
            {
                return ReadResult<IObject>.Move(tryupdate);
            }
            Update = tryupdate.Value;
            var trydate = reader.ReadInt32();
            if (trydate.IsError)
            {
                return ReadResult<IObject>.Move(trydate);
            }
            Date = trydate.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "updateShort";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateShort();
            var cloneUpdate = (CatraProto.Client.TL.Schemas.CloudChats.UpdateBase?)Update.Clone();
            if (cloneUpdate is null)
            {
                return null;
            }
            newClonedObject.Update = cloneUpdate;
            newClonedObject.Date = Date;
            return newClonedObject;

        }
#nullable disable
    }
}