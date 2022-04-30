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
namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
    public partial class DhConfig : CatraProto.Client.TL.Schemas.CloudChats.Messages.DhConfigBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 740433629; }

        [Newtonsoft.Json.JsonProperty("g")]
        public int G { get; set; }

        [Newtonsoft.Json.JsonProperty("p")]
        public byte[] P { get; set; }

        [Newtonsoft.Json.JsonProperty("version")]
        public int Version { get; set; }

        [Newtonsoft.Json.JsonProperty("random")]
        public sealed override byte[] Random { get; set; }


#nullable enable
        public DhConfig(int g, byte[] p, int version, byte[] random)
        {
            G = g;
            P = p;
            Version = version;
            Random = random;

        }
#nullable disable
        internal DhConfig()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            writer.WriteInt32(G);

            writer.WriteBytes(P);
            writer.WriteInt32(Version);

            writer.WriteBytes(Random);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryg = reader.ReadInt32();
            if (tryg.IsError)
            {
                return ReadResult<IObject>.Move(tryg);
            }
            G = tryg.Value;
            var tryp = reader.ReadBytes();
            if (tryp.IsError)
            {
                return ReadResult<IObject>.Move(tryp);
            }
            P = tryp.Value;
            var tryversion = reader.ReadInt32();
            if (tryversion.IsError)
            {
                return ReadResult<IObject>.Move(tryversion);
            }
            Version = tryversion.Value;
            var tryrandom = reader.ReadBytes();
            if (tryrandom.IsError)
            {
                return ReadResult<IObject>.Move(tryrandom);
            }
            Random = tryrandom.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messages.dhConfig";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new DhConfig
            {
                G = G,
                P = P,
                Version = Version,
                Random = Random
            };
            return newClonedObject;

        }
#nullable disable
    }
}