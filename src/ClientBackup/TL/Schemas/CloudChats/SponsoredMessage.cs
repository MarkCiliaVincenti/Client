using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats
{
	public partial class SponsoredMessage : CatraProto.Client.TL.Schemas.CloudChats.SponsoredMessageBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			FromId = 1 << 3,
			ChatInvite = 1 << 4,
			ChatInviteHash = 1 << 4,
			ChannelPost = 1 << 2,
			StartParam = 1 << 0,
			Entities = 1 << 1
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 981691896; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("random_id")]
		public sealed override byte[] RandomId { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("from_id")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.PeerBase FromId { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("chat_invite")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.ChatInviteBase ChatInvite { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("chat_invite_hash")]
		public sealed override string ChatInviteHash { get; set; }

[Newtonsoft.Json.JsonProperty("channel_post")]
		public sealed override int? ChannelPost { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("start_param")]
		public sealed override string StartParam { get; set; }

[Newtonsoft.Json.JsonProperty("message")]
		public sealed override string Message { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("entities")]
		public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> Entities { get; set; }


        #nullable enable
 public SponsoredMessage (byte[] randomId,string message)
{
 RandomId = randomId;
Message = message;
 
}
#nullable disable
        internal SponsoredMessage() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = FromId == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
			Flags = ChatInvite == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
			Flags = ChatInviteHash == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);
			Flags = ChannelPost == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = StartParam == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = Entities == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
			UpdateFlags();

			writer.WriteInt32(Flags);

			writer.WriteBytes(RandomId);
			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
var checkfromId = 				writer.WriteObject(FromId);
if(checkfromId.IsError){
 return checkfromId; 
}
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
var checkchatInvite = 				writer.WriteObject(ChatInvite);
if(checkchatInvite.IsError){
 return checkchatInvite; 
}
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{

				writer.WriteString(ChatInviteHash);
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
writer.WriteInt32(ChannelPost.Value);
			}

			if(FlagsHelper.IsFlagSet(Flags, 0))
			{

				writer.WriteString(StartParam);
			}


			writer.WriteString(Message);
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
var checkentities = 				writer.WriteVector(Entities, false);
if(checkentities.IsError){
 return checkentities; 
}
			}


return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
			var tryflags = reader.ReadInt32();
if(tryflags.IsError){
return ReadResult<IObject>.Move(tryflags);
}
Flags = tryflags.Value;
			var tryrandomId = reader.ReadBytes();
if(tryrandomId.IsError){
return ReadResult<IObject>.Move(tryrandomId);
}
RandomId = tryrandomId.Value;
			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				var tryfromId = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.PeerBase>();
if(tryfromId.IsError){
return ReadResult<IObject>.Move(tryfromId);
}
FromId = tryfromId.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				var trychatInvite = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ChatInviteBase>();
if(trychatInvite.IsError){
return ReadResult<IObject>.Move(trychatInvite);
}
ChatInvite = trychatInvite.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				var trychatInviteHash = reader.ReadString();
if(trychatInviteHash.IsError){
return ReadResult<IObject>.Move(trychatInviteHash);
}
ChatInviteHash = trychatInviteHash.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				var trychannelPost = reader.ReadInt32();
if(trychannelPost.IsError){
return ReadResult<IObject>.Move(trychannelPost);
}
ChannelPost = trychannelPost.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				var trystartParam = reader.ReadString();
if(trystartParam.IsError){
return ReadResult<IObject>.Move(trystartParam);
}
StartParam = trystartParam.Value;
			}

			var trymessage = reader.ReadString();
if(trymessage.IsError){
return ReadResult<IObject>.Move(trymessage);
}
Message = trymessage.Value;
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				var tryentities = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(tryentities.IsError){
return ReadResult<IObject>.Move(tryentities);
}
Entities = tryentities.Value;
			}

return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "sponsoredMessage";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}