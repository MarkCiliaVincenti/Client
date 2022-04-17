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
	public partial class Theme : CatraProto.Client.TL.Schemas.CloudChats.ThemeBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Creator = 1 << 0,
			Default = 1 << 1,
			ForChat = 1 << 5,
			Document = 1 << 2,
			Settings = 1 << 3,
			Emoticon = 1 << 6,
			InstallsCount = 1 << 4
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1609668650; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("creator")]
		public sealed override bool Creator { get; set; }

[Newtonsoft.Json.JsonProperty("default")]
		public sealed override bool Default { get; set; }

[Newtonsoft.Json.JsonProperty("for_chat")]
		public sealed override bool ForChat { get; set; }

[Newtonsoft.Json.JsonProperty("id")]
		public sealed override long Id { get; set; }

[Newtonsoft.Json.JsonProperty("access_hash")]
		public sealed override long AccessHash { get; set; }

[Newtonsoft.Json.JsonProperty("slug")]
		public sealed override string Slug { get; set; }

[Newtonsoft.Json.JsonProperty("title")]
		public sealed override string Title { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("document")]
		public sealed override CatraProto.Client.TL.Schemas.CloudChats.DocumentBase Document { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("settings")]
		public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.ThemeSettingsBase> Settings { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("emoticon")]
		public sealed override string Emoticon { get; set; }

[Newtonsoft.Json.JsonProperty("installs_count")]
		public sealed override int? InstallsCount { get; set; }


        #nullable enable
 public Theme (long id,long accessHash,string slug,string title)
{
 Id = id;
AccessHash = accessHash;
Slug = slug;
Title = title;
 
}
#nullable disable
        internal Theme() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Creator ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Default ? FlagsHelper.SetFlag(Flags, 1) : FlagsHelper.UnsetFlag(Flags, 1);
			Flags = ForChat ? FlagsHelper.SetFlag(Flags, 5) : FlagsHelper.UnsetFlag(Flags, 5);
			Flags = Document == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = Settings == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);
			Flags = Emoticon == null ? FlagsHelper.UnsetFlag(Flags, 6) : FlagsHelper.SetFlag(Flags, 6);
			Flags = InstallsCount == null ? FlagsHelper.UnsetFlag(Flags, 4) : FlagsHelper.SetFlag(Flags, 4);

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
			UpdateFlags();

			writer.WriteInt32(Flags);
writer.WriteInt64(Id);
writer.WriteInt64(AccessHash);

			writer.WriteString(Slug);

			writer.WriteString(Title);
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
var checkdocument = 				writer.WriteObject(Document);
if(checkdocument.IsError){
 return checkdocument; 
}
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
var checksettings = 				writer.WriteVector(Settings, false);
if(checksettings.IsError){
 return checksettings; 
}
			}

			if(FlagsHelper.IsFlagSet(Flags, 6))
			{

				writer.WriteString(Emoticon);
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
writer.WriteInt32(InstallsCount.Value);
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
			Default = FlagsHelper.IsFlagSet(Flags, 1);
			ForChat = FlagsHelper.IsFlagSet(Flags, 5);
			var tryid = reader.ReadInt64();
if(tryid.IsError){
return ReadResult<IObject>.Move(tryid);
}
Id = tryid.Value;
			var tryaccessHash = reader.ReadInt64();
if(tryaccessHash.IsError){
return ReadResult<IObject>.Move(tryaccessHash);
}
AccessHash = tryaccessHash.Value;
			var tryslug = reader.ReadString();
if(tryslug.IsError){
return ReadResult<IObject>.Move(tryslug);
}
Slug = tryslug.Value;
			var trytitle = reader.ReadString();
if(trytitle.IsError){
return ReadResult<IObject>.Move(trytitle);
}
Title = trytitle.Value;
			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				var trydocument = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
if(trydocument.IsError){
return ReadResult<IObject>.Move(trydocument);
}
Document = trydocument.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				var trysettings = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ThemeSettingsBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(trysettings.IsError){
return ReadResult<IObject>.Move(trysettings);
}
Settings = trysettings.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 6))
			{
				var tryemoticon = reader.ReadString();
if(tryemoticon.IsError){
return ReadResult<IObject>.Move(tryemoticon);
}
Emoticon = tryemoticon.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 4))
			{
				var tryinstallsCount = reader.ReadInt32();
if(tryinstallsCount.IsError){
return ReadResult<IObject>.Move(tryinstallsCount);
}
InstallsCount = tryinstallsCount.Value;
			}

return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "theme";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}