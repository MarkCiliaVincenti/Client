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
	public partial class DeepLinkInfo : CatraProto.Client.TL.Schemas.CloudChats.Help.DeepLinkInfoBase
	{
		[Flags]
		public enum FlagsEnum 
		{
			UpdateApp = 1 << 0,
			Entities = 1 << 1
		}

        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1783556146; }
        
[Newtonsoft.Json.JsonIgnore]
		public int Flags { get; set; }

[Newtonsoft.Json.JsonProperty("update_app")]
		public bool UpdateApp { get; set; }

[Newtonsoft.Json.JsonProperty("message")]
		public string Message { get; set; }

[MaybeNull]
[Newtonsoft.Json.JsonProperty("entities")]
		public List<CatraProto.Client.TL.Schemas.CloudChats.MessageEntityBase> Entities { get; set; }


        #nullable enable
 public DeepLinkInfo (string message)
{
 Message = message;
 
}
#nullable disable
        internal DeepLinkInfo() 
        {
        }
		
		public override void UpdateFlags() 
		{
			Flags = UpdateApp ? FlagsHelper.SetFlag(Flags, 0) : FlagsHelper.UnsetFlag(Flags, 0);
			Flags = Entities == null ? FlagsHelper.UnsetFlag(Flags, 1) : FlagsHelper.SetFlag(Flags, 1);

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
			UpdateFlags();

			writer.WriteInt32(Flags);

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
			UpdateApp = FlagsHelper.IsFlagSet(Flags, 0);
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
		    return "help.deepLinkInfo";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}