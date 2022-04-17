using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

#nullable disable
namespace CatraProto.Client.TL.Schemas.CloudChats.Help
{
	public partial class AppUpdate : CatraProto.Client.TL.Schemas.CloudChats.Help.AppUpdateBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			CanNotSkip = 1 << 0,
			Document = 1 << 1,
			Url = 1 << 2,
			Sticker = 1 << 3
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -860107216; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("can_not_skip")]
		public bool CanNotSkip { get; set; }

[Newtonsoft.Json.JsonProperty("id")]
		public int Id { get; set; }

[Newtonsoft.Json.JsonProperty("version")]
		public string Version { get; set; }

[Newtonsoft.Json.JsonProperty("text")]
		public string Text { get; set; }

[Newtonsoft.Json.JsonProperty("entities")]
		public List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> Entities { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("document")]
		public CatraProto.Client.TL.Schemas.CloudChats.DocumentBase Document { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("url")]
		public string Url { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("sticker")]
		public CatraProto.Client.TL.Schemas.CloudChats.DocumentBase Sticker { get; set; }


        #nullable enable
 public AppUpdate (int id,string version,string text,List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> entities)
{
 Id = id;
Version = version;
Text = text;
Entities = entities;
 
}
#nullable disable
        internal AppUpdate() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = CanNotSkip ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Document == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);
			Flags = Url == null ? FlagsHelper.UnsetFlag(Flags, 2) : FlagsHelper.SetFlag(Flags, 2);
			Flags = Sticker == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
			UpdateFlags();

			writer.WriteInt32(Flags);
writer.WriteInt32(Id);

			writer.WriteString(Version);

			writer.WriteString(Text);
var checkentities = 			writer.WriteVector(Entities, false);
if(checkentities.IsError){
 return checkentities; 
}
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
var checkdocument = 				writer.WriteObject(Document);
if(checkdocument.IsError){
 return checkdocument; 
}
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{

				writer.WriteString(Url);
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
var checksticker = 				writer.WriteObject(Sticker);
if(checksticker.IsError){
 return checksticker; 
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
			CanNotSkip = FlagsHelper.IsFlagSet(Flags, 0);
			var tryid = reader.ReadInt32();
if(tryid.IsError){
return ReadResult<IObject>.Move(tryid);
}
Id = tryid.Value;
			var tryversion = reader.ReadString();
if(tryversion.IsError){
return ReadResult<IObject>.Move(tryversion);
}
Version = tryversion.Value;
			var trytext = reader.ReadString();
if(trytext.IsError){
return ReadResult<IObject>.Move(trytext);
}
Text = trytext.Value;
			var tryentities = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(tryentities.IsError){
return ReadResult<IObject>.Move(tryentities);
}
Entities = tryentities.Value;
			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				var trydocument = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
if(trydocument.IsError){
return ReadResult<IObject>.Move(trydocument);
}
Document = trydocument.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 2))
			{
				var tryurl = reader.ReadString();
if(tryurl.IsError){
return ReadResult<IObject>.Move(tryurl);
}
Url = tryurl.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
				var trysticker = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.DocumentBase>();
if(trysticker.IsError){
return ReadResult<IObject>.Move(trysticker);
}
Sticker = trysticker.Value;
			}

return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "help.appUpdate";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}