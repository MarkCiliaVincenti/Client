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

using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class TopPeerCategoryPeers : CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryPeersBase
    {


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -75283823; }

        [Newtonsoft.Json.JsonProperty("category")]
        public sealed override CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryBase Category { get; set; }

        [Newtonsoft.Json.JsonProperty("count")]
        public sealed override int Count { get; set; }

        [Newtonsoft.Json.JsonProperty("peers")]
        public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.TopPeerBase> Peers { get; set; }


#nullable enable
        public TopPeerCategoryPeers(CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryBase category, int count, List<CatraProto.Client.TL.Schemas.CloudChats.TopPeerBase> peers)
        {
            Category = category;
            Count = count;
            Peers = peers;

        }
#nullable disable
        internal TopPeerCategoryPeers()
        {
        }

        public override void UpdateFlags()
        {

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            var checkcategory = writer.WriteObject(Category);
            if (checkcategory.IsError)
            {
                return checkcategory;
            }
            writer.WriteInt32(Count);
            var checkpeers = writer.WriteVector(Peers, false);
            if (checkpeers.IsError)
            {
                return checkpeers;
            }

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var trycategory = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryBase>();
            if (trycategory.IsError)
            {
                return ReadResult<IObject>.Move(trycategory);
            }
            Category = trycategory.Value;
            var trycount = reader.ReadInt32();
            if (trycount.IsError)
            {
                return ReadResult<IObject>.Move(trycount);
            }
            Count = trycount.Value;
            var trypeers = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.TopPeerBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
            if (trypeers.IsError)
            {
                return ReadResult<IObject>.Move(trypeers);
            }
            Peers = trypeers.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "topPeerCategoryPeers";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new TopPeerCategoryPeers();
            var cloneCategory = (CatraProto.Client.TL.Schemas.CloudChats.TopPeerCategoryBase?)Category.Clone();
            if (cloneCategory is null)
            {
                return null;
            }
            newClonedObject.Category = cloneCategory;
            newClonedObject.Count = Count;
            foreach (var peers in Peers)
            {
                var clonepeers = (CatraProto.Client.TL.Schemas.CloudChats.TopPeerBase?)peers.Clone();
                if (clonepeers is null)
                {
                    return null;
                }
                newClonedObject.Peers.Add(clonepeers);
            }
            return newClonedObject;

        }
#nullable disable
    }
}