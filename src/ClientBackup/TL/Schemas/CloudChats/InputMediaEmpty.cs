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
	public partial class InputMediaEmpty : CatraProto.Client.TL.Schemas.CloudChats.InputMediaBase
	{


        [Newtonsoft.Json.JsonIgnore]
        public static int ConstructorId { get => -1771768449; }
        

        
        public InputMediaEmpty() 
        {
        }
		
		public override void UpdateFlags() 
		{

		}

		public override WriteResult Serialize(Writer writer)
		{
writer.WriteInt32(ConstructorId);

return new WriteResult();

		}

		public override ReadResult<IObject> Deserialize(Reader reader)
		{
return new ReadResult<IObject>(this);

		}
		
		public override string ToString()
		{
		    return "inputMediaEmpty";
		}

		public override int GetConstructorId()
		{
			return ConstructorId;
		}
	}
}