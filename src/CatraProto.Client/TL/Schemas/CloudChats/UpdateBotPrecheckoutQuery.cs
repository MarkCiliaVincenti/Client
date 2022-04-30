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

using System;
using System.Diagnostics.CodeAnalysis;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
    public partial class UpdateBotPrecheckoutQuery : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
    {
        [Flags]
        public enum FlagsEnum
        {
            Info = 1 << 0,
            ShippingOptionId = 1 << 1
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1934976362; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("query_id")]
        public long QueryId { get; set; }

        [Newtonsoft.Json.JsonProperty("user_id")]
        public long UserId { get; set; }

        [Newtonsoft.Json.JsonProperty("payload")]
        public byte[] Payload { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("info")]
        public CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase Info { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("shipping_option_id")]
        public string ShippingOptionId { get; set; }

        [Newtonsoft.Json.JsonProperty("currency")]
        public string Currency { get; set; }

        [Newtonsoft.Json.JsonProperty("total_amount")]
        public long TotalAmount { get; set; }


#nullable enable
        public UpdateBotPrecheckoutQuery(long queryId, long userId, byte[] payload, string currency, long totalAmount)
        {
            QueryId = queryId;
            UserId = userId;
            Payload = payload;
            Currency = currency;
            TotalAmount = totalAmount;

        }
#nullable disable
        internal UpdateBotPrecheckoutQuery()
        {
        }

        public override void UpdateFlags()
        {
            Flags = Info == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = ShippingOptionId == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);
            writer.WriteInt64(QueryId);
            writer.WriteInt64(UserId);

            writer.WriteBytes(Payload);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checkinfo = writer.WriteObject(Info);
                if (checkinfo.IsError)
                {
                    return checkinfo;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {

                writer.WriteString(ShippingOptionId);
            }


            writer.WriteString(Currency);
            writer.WriteInt64(TotalAmount);

            return new WriteResult();

        }

        public override ReadResult<IObject> Deserialize(Reader reader)
        {
            var tryflags = reader.ReadInt32();
            if (tryflags.IsError)
            {
                return ReadResult<IObject>.Move(tryflags);
            }
            Flags = tryflags.Value;
            var tryqueryId = reader.ReadInt64();
            if (tryqueryId.IsError)
            {
                return ReadResult<IObject>.Move(tryqueryId);
            }
            QueryId = tryqueryId.Value;
            var tryuserId = reader.ReadInt64();
            if (tryuserId.IsError)
            {
                return ReadResult<IObject>.Move(tryuserId);
            }
            UserId = tryuserId.Value;
            var trypayload = reader.ReadBytes();
            if (trypayload.IsError)
            {
                return ReadResult<IObject>.Move(trypayload);
            }
            Payload = trypayload.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryinfo = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase>();
                if (tryinfo.IsError)
                {
                    return ReadResult<IObject>.Move(tryinfo);
                }
                Info = tryinfo.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 1))
            {
                var tryshippingOptionId = reader.ReadString();
                if (tryshippingOptionId.IsError)
                {
                    return ReadResult<IObject>.Move(tryshippingOptionId);
                }
                ShippingOptionId = tryshippingOptionId.Value;
            }

            var trycurrency = reader.ReadString();
            if (trycurrency.IsError)
            {
                return ReadResult<IObject>.Move(trycurrency);
            }
            Currency = trycurrency.Value;
            var trytotalAmount = reader.ReadInt64();
            if (trytotalAmount.IsError)
            {
                return ReadResult<IObject>.Move(trytotalAmount);
            }
            TotalAmount = trytotalAmount.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "updateBotPrecheckoutQuery";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new UpdateBotPrecheckoutQuery
            {
                Flags = Flags,
                QueryId = QueryId,
                UserId = UserId,
                Payload = Payload
            };
            if (Info is not null)
            {
                var cloneInfo = (CatraProto.Client.TL.Schemas.CloudChats.PaymentRequestedInfoBase?)Info.Clone();
                if (cloneInfo is null)
                {
                    return null;
                }
                newClonedObject.Info = cloneInfo;
            }
            newClonedObject.ShippingOptionId = ShippingOptionId;
            newClonedObject.Currency = Currency;
            newClonedObject.TotalAmount = TotalAmount;
            return newClonedObject;

        }
#nullable disable
    }
}