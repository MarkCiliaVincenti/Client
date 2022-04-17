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
	public partial class UpdateNewChannelMessage : CatraProto.Client.TL.Schemas.CloudChats.UpdateBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1656358105; }
        
[Newtonsoft.Json.JsonProperty("message")]
		public CatraProto.Client.TL.Schemas.CloudChats.MessageBase Message { get; set; }

[Newtonsoft.Json.JsonProperty("pts")]
		public int Pts { get; set; }

[Newtonsoft.Json.JsonProperty("pts_count")]
		public int PtsCount { get; set; }


        #nullable enable
 public UpdateNewChannelMessage (CatraProto.Client.TL.Schemas.CloudChats.MessageBase message,int pts,int ptsCount)
{
 Message = message;
Pts = pts;
PtsCount = ptsCount;
 
}
#nullable disable
        internal UpdateNewChannelMessage() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
var checkmessage = 			writer.WriteObject(Message);
if(checkmessage.IsError){
 return checkmessage; 
}
writer.WriteInt32(Pts);
writer.WriteInt32(PtsCount);

return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
			var trymessage = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.MessageBase>();
if(trymessage.IsError){
return ReadResult<IObject>.Move(trymessage);
}
Message = trymessage.Value;
			var trypts = reader.ReadInt32();
if(trypts.IsError){
return ReadResult<IObject>.Move(trypts);
}
Pts = trypts.Value;
			var tryptsCount = reader.ReadInt32();
if(tryptsCount.IsError){
return ReadResult<IObject>.Move(tryptsCount);
}
PtsCount = tryptsCount.Value;
return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "updateNewChannelMessage";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}