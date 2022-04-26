using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class DeleteMessages : IMethod
    {
        [Flags]
        public enum FlagsEnum
        {
            Revoke = 1 << 0
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -443640366; }

        [Newtonsoft.Json.JsonIgnore]
        ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("revoke")]
        public bool Revoke { get; set; }

        [Newtonsoft.Json.JsonProperty("id")]
        public List<int> Id { get; set; }


#nullable enable
        public DeleteMessages(List<int> id)
        {
            Id = id;

        }
#nullable disable

        internal DeleteMessages()
        {
        }

        public void UpdateFlags()
        {
            Flags = Revoke ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);

        }

        public WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);

            writer.WriteVector(Id, false);

            return new WriteResult();

        }

        public ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }
            Flags = tryflags.Value;
            Revoke = FlagsHelper.IsFlagSet(Flags, 0);
            var tryid = reader.ReadVector<int>(ParserTypes.Int);
            if (tryid.IsError)
            {
                return ReadResult<IObject>.Move(tryid);
            }
            Id = tryid.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.deleteMessages";
        }

        public int GetConstructorId()
        {
            return ConstructorId;
        }
#nullable enable
        public IObject? Clone()
        {
            var newClonedObject = new DeleteMessages
            {
                Flags = Flags,
                Revoke = Revoke
            };
            foreach (var id in Id)
            {
                newClonedObject.Id.Add(id);
            }
            return newClonedObject;

        }
#nullable disable
    }
}