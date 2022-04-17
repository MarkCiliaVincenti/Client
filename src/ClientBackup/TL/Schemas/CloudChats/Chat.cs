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
	public partial class Chat : CatraProto.Client.TL.Schemas.CloudChats.ChatBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Creator = 1 << 0,
			Kicked = 1 << 1,
			Left = 1 << 2,
			Deactivated = 1 << 5,
			CallActive = 1 << 23,
			CallNotEmpty = 1 << 24,
			Noforwards = 1 << 25,
			MigratedTo = 1 << 6,
			AdminRights = 1 << 14,
			DefaultBannedRights = 1 << 18
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1103884886; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("creator")]
		public bool Creator { get; set; }

[Newtonsoft.Json.JsonProperty("kicked")]
		public bool Kicked { get; set; }

[Newtonsoft.Json.JsonProperty("left")]
		public bool Left { get; set; }

[Newtonsoft.Json.JsonProperty("deactivated")]
		public bool Deactivated { get; set; }

[Newtonsoft.Json.JsonProperty("call_active")]
		public bool CallActive { get; set; }

[Newtonsoft.Json.JsonProperty("call_not_empty")]
		public bool CallNotEmpty { get; set; }

[Newtonsoft.Json.JsonProperty("noforwards")]
		public bool Noforwards { get; set; }

[Newtonsoft.Json.JsonProperty("id")]
		public sealed override long Id { get; set; }

[Newtonsoft.Json.JsonProperty("title")]
		public string Title { get; set; }

[Newtonsoft.Json.JsonProperty("photo")]
		public CatraProto.Client.TL.Schemas.CloudChats.ChatPhotoBase Photo { get; set; }

[Newtonsoft.Json.JsonProperty("participants_count")]
		public int ParticipantsCount { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public int Date { get; set; }

[Newtonsoft.Json.JsonProperty("version")]
		public int Version { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("migrated_to")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase MigratedTo { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("admin_rights")]
		public CatraProto.Client.TL.Schemas.CloudChats.ChatAdminRightsBase AdminRights { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("default_banned_rights")]
		public CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase DefaultBannedRights { get; set; }


        #nullable enable
 public Chat (long id,string title,CatraProto.Client.TL.Schemas.CloudChats.ChatPhotoBase photo,int participantsCount,int date,int version)
{
 Id = id;
Title = title;
Photo = photo;
ParticipantsCount = participantsCount;
Date = date;
Version = version;
 
}
#nullable disable
        internal Chat() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Creator ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Kicked ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = Left ? FlagsHelper.SetFlag(Flags, 2) : FlagsHelper.UnsetFlag(Flags, 2);
			Flags = Deactivated ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
			Flags = CallActive ? FlagsHelper.SetFlag(Flags, 23) : FlagsHelper.UnsetFlag(Flags, 23);
			Flags = CallNotEmpty ? FlagsHelper.SetFlag(Flags, 24) : FlagsHelper.UnsetFlag(Flags, 24);
			Flags = Noforwards ? FlagsHelper.SetFlag(Flags, 25) : FlagsHelper.UnsetFlag(Flags, 25);
			Flags = MigratedTo == null ? FlagsHelper.UnsetFlag(Flags, 6) : FlagsHelper.SetFlag(Flags, 6);
			Flags = AdminRights == null ? FlagsHelper.UnsetFlag(Flags, 14) : FlagsHelper.SetFlag(Flags, 14);
			Flags = DefaultBannedRights == null ? FlagsHelper.UnsetFlag(Flags, 18) : FlagsHelper.SetFlag(Flags, 18);

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
			UpdateFlags();

			writer.WriteInt32(Flags);
writer.WriteInt64(Id);

			writer.WriteString(Title);
var checkphoto = 			writer.WriteObject(Photo);
if(checkphoto.IsError){
 return checkphoto; 
}
writer.WriteInt32(ParticipantsCount);
writer.WriteInt32(Date);
writer.WriteInt32(Version);
			if(FlagsHelper.IsFlagSet(Flags, 6))
			{
var checkmigratedTo = 				writer.WriteObject(MigratedTo);
if(checkmigratedTo.IsError){
 return checkmigratedTo; 
}
			}

			if(FlagsHelper.IsFlagSet(Flags, 14))
			{
var checkadminRights = 				writer.WriteObject(AdminRights);
if(checkadminRights.IsError){
 return checkadminRights; 
}
			}

			if(FlagsHelper.IsFlagSet(Flags, 18))
			{
var checkdefaultBannedRights = 				writer.WriteObject(DefaultBannedRights);
if(checkdefaultBannedRights.IsError){
 return checkdefaultBannedRights; 
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
			Creator = FlagsHelper.IsFlagSet(Flags, 0);
			Kicked = FlagsHelper.IsFlagSet(Flags, 1);
			Left = FlagsHelper.IsFlagSet(Flags, 2);
			Deactivated = FlagsHelper.IsFlagSet(Flags, 5);
			CallActive = FlagsHelper.IsFlagSet(Flags, 23);
			CallNotEmpty = FlagsHelper.IsFlagSet(Flags, 24);
			Noforwards = FlagsHelper.IsFlagSet(Flags, 25);
			var tryid = reader.ReadInt64();
if(tryid.IsError){
return ReadResult<IObject>.Move(tryid);
}
Id = tryid.Value;
			var trytitle = reader.ReadString();
if(trytitle.IsError){
return ReadResult<IObject>.Move(trytitle);
}
Title = trytitle.Value;
			var tryphoto = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ChatPhotoBase>();
if(tryphoto.IsError){
return ReadResult<IObject>.Move(tryphoto);
}
Photo = tryphoto.Value;
			var tryparticipantsCount = reader.ReadInt32();
if(tryparticipantsCount.IsError){
return ReadResult<IObject>.Move(tryparticipantsCount);
}
ParticipantsCount = tryparticipantsCount.Value;
			var trydate = reader.ReadInt32();
if(trydate.IsError){
return ReadResult<IObject>.Move(trydate);
}
Date = trydate.Value;
			var tryversion = reader.ReadInt32();
if(tryversion.IsError){
return ReadResult<IObject>.Move(tryversion);
}
Version = tryversion.Value;
			if(FlagsHelper.IsFlagSet(Flags, 6))
			{
				var trymigratedTo = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase>();
if(trymigratedTo.IsError){
return ReadResult<IObject>.Move(trymigratedTo);
}
MigratedTo = trymigratedTo.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 14))
			{
				var tryadminRights = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ChatAdminRightsBase>();
if(tryadminRights.IsError){
return ReadResult<IObject>.Move(tryadminRights);
}
AdminRights = tryadminRights.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 18))
			{
				var trydefaultBannedRights = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.ChatBannedRightsBase>();
if(trydefaultBannedRights.IsError){
return ReadResult<IObject>.Move(trydefaultBannedRights);
}
DefaultBannedRights = trydefaultBannedRights.Value;
			}

return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "chat";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}