using System;
using System.Collections.Generic;
using CatraProto.TL;
using CatraProto.TL.Interfaces;
using CatraProto.TL.Results;
using System.Diagnostics.CodeAnalysis;

using System.Linq;

#nullable disable

namespace CatraProto.Client.TL.Schemas.CloudChats.Channels
{
	public partial class LeaveChannel : IMethod
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -130635115; }
        
[Newtonsoft.Json.JsonIgnore]
		ParserTypes IMethod.Type { get; init; } = ParserTypes.Object;

[Newtonsoft.Json.JsonProperty("channel")]
		public CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase Channel { get; set; }

        
        #nullable enable
 public LeaveChannel (CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase channel)
{
 Channel = channel;
 
}
#nullable disable
                
        internal LeaveChannel() 
        {
        }
        
		public void UpdateFlags() 
		{

		}

		public WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
var checkchannel = 			writer.WriteObject(Channel);
if(checkchannel.IsError){
 return checkchannel; 
}

return new WriteResult();

		}

		public ReadResult<IObject> Deserialize(Reader reader)
		{
			var trychannel = reader.ReadObject<CatraProto.Client.TL.Schemas.CloudChats.InputChannelBase>();
if(trychannel.IsError){
return ReadResult<IObject>.Move(trychannel);
}
Channel = trychannel.Value;
return new ReadResult<IObject>(this);

		}

		public override string ToString()
		{
		    return "channels.leaveChannel";
		}

		public int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}