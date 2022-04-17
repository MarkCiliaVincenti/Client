using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;

using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Messages
{
	public partial class GetWebPagePreview : IMethod
	{
		[Flags]
		public enum FlagsEnum 
		{
			Entities = 1 << 3
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1956073268; }
        
[Newtonsoft.Json.JsonIgnore]
		ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("message")]
		public string Message { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("entities")]
		public List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> Entities { get; set; }

        
        #nullable enable
 public GetWebPagePreview (string message)
{
 Message = message;
 
}
#nullable disable
                
        internal GetWebPagePreview() 
        {
        }
        
		public void UpdateFlags() 
		{
			Flags = Entities == null ? FlagsHelper.UnsetFlag(Flags, 3) : FlagsHelper.SetFlag(Flags, 3);

		}

		public WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
			UpdateFlags();

			writer.WriteInt32(Flags);

			writer.WriteString(Message);
			if(FlagsHelper.IsFlagSet(Flags, 3))
			{
var checkentities = 				writer.WriteVector(Entities, false);
if(checkentities.IsError){
 return checkentities; 
}
			}


return new WriteResult();

		}

		public ReadResult<IObject> Deserialize(Reader reader)
		{
			var tryflags = reader.ReadInt32();
if(tryflags.IsError){
return ReadResult<IObject>.Move(tryflags);
}
Flags = tryflags.Value;
			var trymessage = reader.ReadString();
if(trymessage.IsError){
return ReadResult<IObject>.Move(trymessage);
}
Message = trymessage.Value;
			if(FlagsHelper.IsFlagSet(Flags, 3))
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
		    return "messages.getWebPagePreview";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}