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
	public partial class Document : CatraProto.Client.TL.Schemas.CloudChats.DocumentBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			Thumbs = 1 << 0,
			VideoThumbs = 1 << 1
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 512177195; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("id")]
		public sealed override long Id { get; set; }

[Newtonsoft.Json.JsonProperty("access_hash")]
		public long AccessHash { get; set; }

[Newtonsoft.Json.JsonProperty("file_reference")]
		public byte[] FileReference { get; set; }

[Newtonsoft.Json.JsonProperty("date")]
		public int Date { get; set; }

[Newtonsoft.Json.JsonProperty("mime_type")]
		public string MimeType { get; set; }

[Newtonsoft.Json.JsonProperty("size")]
		public int Size { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("thumbs")]
		public List<CatraProto.Client.TL.Schemas.CloudChats.PhotoSizeBase> Thumbs { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("video_thumbs")]
		public List<CatraProto.Client.TL.Schemas.CloudChats.VideoSizeBase> VideoThumbs { get; set; }

[Newtonsoft.Json.JsonProperty("dc_id")]
		public int DcId { get; set; }

[Newtonsoft.Json.JsonProperty("attributes")]
		public List<CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase> Attributes { get; set; }


        #nullable enable
 public Document (long id,long accessHash,byte[] fileReference,int date,string mimeType,int size,int dcId,List<CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase> attributes)
{
 Id = id;
AccessHash = accessHash;
FileReference = fileReference;
Date = date;
MimeType = mimeType;
Size = size;
DcId = dcId;
Attributes = attributes;
 
}
#nullable disable
        internal Document() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = Thumbs == null ? FlagsHelper.UnsetFlag(Flags, 0) : FlagsHelper.SetFlag(Flags, 0);
			Flags = VideoThumbs == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
			UpdateFlags();

			writer.WriteInt32(Flags);
writer.WriteInt64(Id);
writer.WriteInt64(AccessHash);

			writer.WriteBytes(FileReference);
writer.WriteInt32(Date);

			writer.WriteString(MimeType);
writer.WriteInt32(Size);
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
var checkthumbs = 				writer.WriteVector(Thumbs, false);
if(checkthumbs.IsError){
 return checkthumbs; 
}
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
var checkvideoThumbs = 				writer.WriteVector(VideoThumbs, false);
if(checkvideoThumbs.IsError){
 return checkvideoThumbs; 
}
			}

writer.WriteInt32(DcId);
var checkattributes = 			writer.WriteVector(Attributes, false);
if(checkattributes.IsError){
 return checkattributes; 
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
			var tryfileReference = reader.ReadBytes();
if(tryfileReference.IsError){
return ReadResult<IObject>.Move(tryfileReference);
}
FileReference = tryfileReference.Value;
			var trydate = reader.ReadInt32();
if(trydate.IsError){
return ReadResult<IObject>.Move(trydate);
}
Date = trydate.Value;
			var trymimeType = reader.ReadString();
if(trymimeType.IsError){
return ReadResult<IObject>.Move(trymimeType);
}
MimeType = trymimeType.Value;
			var trysize = reader.ReadInt32();
if(trysize.IsError){
return ReadResult<IObject>.Move(trysize);
}
Size = trysize.Value;
			if(FlagsHelper.IsFlagSet(Flags, 0))
			{
				var trythumbs = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.PhotoSizeBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(trythumbs.IsError){
return ReadResult<IObject>.Move(trythumbs);
}
Thumbs = trythumbs.Value;
			}

			if(FlagsHelper.IsFlagSet(Flags, 1))
			{
				var tryvideoThumbs = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.VideoSizeBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(tryvideoThumbs.IsError){
return ReadResult<IObject>.Move(tryvideoThumbs);
}
VideoThumbs = tryvideoThumbs.Value;
			}

			var trydcId = reader.ReadInt32();
if(trydcId.IsError){
return ReadResult<IObject>.Move(trydcId);
}
DcId = trydcId.Value;
			var tryattributes = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.DocumentAttributeBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(tryattributes.IsError){
return ReadResult<IObject>.Move(tryattributes);
}
Attributes = tryattributes.Value;
return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "document";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}