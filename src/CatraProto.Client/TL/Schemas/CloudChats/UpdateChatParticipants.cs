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
    public partial class UpdateChatParticipants : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 125178264; }

        [Newtonsoft.Json.JsonProperty("participants")]
        public CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantsBase Participants { get; set; }


#nullable enable
        public UpdateChatParticipants(CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantsBase participants)
        {
            Participants = participants;

        }
#nullable disable
        internal UpdateChatParticipants()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkparticipants = writer.WriteObject(Participants);
            if (checkparticipants.IsError)
            {
                return checkparticipants;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryparticipants = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantsBase>();
            if (tryparticipants.IsError)
            {
                return ReadResult<IObject>.Move(tryparticipants);
            }
            Participants = tryparticipants.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "updateChatParticipants";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateChatParticipants();
            var cloneParticipants = (CatraProto.Client.TL.Schemas.CloudChats.ChatParticipantsBase?)Participants.Clone();
            if (cloneParticipants is null)
            {
                return null;
            }
            newClonedObject.Participants = cloneParticipants;
            return newClonedObject;

        }

        public override bool Compare(IObject other)
        {
            if (other is not UpdateChatParticipants castedOther)
            {
                return true;
            }
            if (Participants.Compare(castedOther.Participants))
            {
                return true;
            }
            return false;

        }

#nullable disable
    }
}