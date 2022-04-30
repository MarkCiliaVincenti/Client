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
    public partial class MessageMediaInvoice : CatraProto.Client.TL.Schemas.CloudChats.MessageMediaBase
    {
        [Flags]
        public enum FlagsEnum
        {
            ShippingAddressRequested = 1 << 1,
            Test = 1 << 3,
            Photo = 1 << 0,
            ReceiptMsgId = 1 << 2
        }

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -2074799289; }

        [Newtonsoft.Json.JsonIgnore]
        public int Flags { get; set; }

        [Newtonsoft.Json.JsonProperty("shipping_address_requested")]
        public bool ShippingAddressRequested { get; set; }

        [Newtonsoft.Json.JsonProperty("test")]
        public bool Test { get; set; }

        [Newtonsoft.Json.JsonProperty("title")]
        public string Title { get; set; }

        [Newtonsoft.Json.JsonProperty("description")]
        public string Description { get; set; }

        [MaybeNull]
        [Newtonsoft.Json.JsonProperty("photo")]
        public CatraProto.Client.TL.Schemas.CloudChats.WebDocumentBase Photo { get; set; }

        [Newtonsoft.Json.JsonProperty("receipt_msg_id")]
        public int? ReceiptMsgId { get; set; }

        [Newtonsoft.Json.JsonProperty("currency")]
        public string Currency { get; set; }

        [Newtonsoft.Json.JsonProperty("total_amount")]
        public long TotalAmount { get; set; }

        [Newtonsoft.Json.JsonProperty("start_param")]
        public string StartParam { get; set; }


#nullable enable
        public MessageMediaInvoice(string title, string description, string currency, long totalAmount, string startParam)
        {
            Title = title;
            Description = description;
            Currency = currency;
            TotalAmount = totalAmount;
            StartParam = startParam;

        }
#nullable disable
        internal MessageMediaInvoice()
        {
        }

        public override void UpdateFlags()
        {
            Flags = ShippingAddressRequested ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
            Flags = Test ? FlagsHelper.SetFlag(Flags, 3) : FlagsHelper.UnsetFlag(Flags, 3);
            Flags = Photo == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
            Flags = ReceiptMsgId == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);

        }

        public override WriteResult Serialize(Writer writer)
        {
            writer.WriteInt32(ConstructorId);
            UpdateFlags();

            writer.WriteInt32(Flags);

            writer.WriteString(Title);

            writer.WriteString(Description);
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var checkphoto = writer.WriteObject(Photo);
                if (checkphoto.IsError)
                {
                    return checkphoto;
                }
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                writer.WriteInt32(ReceiptMsgId.Value);
            }


            writer.WriteString(Currency);
            writer.WriteInt64(TotalAmount);

            writer.WriteString(StartParam);

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
            ShippingAddressRequested = FlagsHelper.IsFlagSet(Flags, 1);
            Test = FlagsHelper.IsFlagSet(Flags, 3);
            var trytitle = reader.ReadString();
            if (trytitle.IsError)
            {
                return ReadResult<IObject>.Move(trytitle);
            }
            Title = trytitle.Value;
            var trydescription = reader.ReadString();
            if (trydescription.IsError)
            {
                return ReadResult<IObject>.Move(trydescription);
            }
            Description = trydescription.Value;
            if (FlagsHelper.IsFlagSet(Flags, 0))
            {
                var tryphoto = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.WebDocumentBase>();
                if (tryphoto.IsError)
                {
                    return ReadResult<IObject>.Move(tryphoto);
                }
                Photo = tryphoto.Value;
            }

            if (FlagsHelper.IsFlagSet(Flags, 2))
            {
                var tryreceiptMsgId = reader.ReadInt32();
                if (tryreceiptMsgId.IsError)
                {
                    return ReadResult<IObject>.Move(tryreceiptMsgId);
                }
                ReceiptMsgId = tryreceiptMsgId.Value;
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
            var trystartParam = reader.ReadString();
            if (trystartParam.IsError)
            {
                return ReadResult<IObject>.Move(trystartParam);
            }
            StartParam = trystartParam.Value;
            return new ReadResult<IObject>(this);

        }

        public override string ToString()
        {
            return "messageMediaInvoice";
        }

        public override int GetConstructorId()
        {
            return ConstructorId;
        }

#nullable enable
        public override IObject? Clone()
        {
            var newClonedObject = new MessageMediaInvoice
            {
                Flags = Flags,
                ShippingAddressRequested = ShippingAddressRequested,
                Test = Test,
                Title = Title,
                Description = Description
            };
            if (Photo is not null)
            {
                var clonePhoto = (CatraProto.Client.TL.Schemas.CloudChats.WebDocumentBase?)Photo.Clone();
                if (clonePhoto is null)
                {
                    return null;
                }
                newClonedObject.Photo = clonePhoto;
            }
            newClonedObject.ReceiptMsgId = ReceiptMsgId;
            newClonedObject.Currency = Currency;
            newClonedObject.TotalAmount = TotalAmount;
            newClonedObject.StartParam = StartParam;
            return newClonedObject;

        }
#nullable disable
    }
}