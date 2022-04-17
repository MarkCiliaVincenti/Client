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
	public partial class Chats : CatraProto.Client.TL.Schemas.CloudChats.Messages.ChatsBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => 1694474197; }
        
[Newtonsoft.Json.JsonProperty("chats")]
		public sealed override List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> ChatsField { get; set; }


        #nullable enable
 public Chats (List<CatraProto.Client.TL.Schemas.CloudChats.ChatBase> chatsField)
{
 ChatsField = chatsField;
 
}
#nullable disable
        internal Chats() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);
var checkchatsField = 			writer.WriteVector(ChatsField, false);
if(checkchatsField.IsError){
 return checkchatsField; 
}

return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
			var trychatsField = reader.ReadVector<CatraProto.Client.TL.Schemas.CloudChats.ChatBase>(ParserTypes.Object, nakedVector: false, nakedObjects: false);
if(trychatsField.IsError){
return ReadResult<IObject>.Move(trychatsField);
}
ChatsField = trychatsField.Value;
return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "messages.chats";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}