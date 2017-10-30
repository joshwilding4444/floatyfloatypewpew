using System;
// refer to : https://msdn.microsoft.com/en-us/library/system.runtime.serialization.json(v=vs.110).aspx
//            https://docs.microsoft.com/en-us/dotnet/api/system.runtime.serialization.json?view=netframework-4.7.1
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Json;
using System.Xml;
using System.Runtime.Serialization.Json;

namespace serverMessage
{
	//construct a data contract here
	//https://docs.microsoft.com/en-us/dotnet/api/system.runtime.serialization.datacontractattribute?view=netframework-4.7.1
    [DataContract(Name = "serverMessage", Namespace = "serverMessage" )]
    public class serverMessage : IExtensibleDataObject 
    {
        [DataMember(Name = "messageID")]
		public int messageID;
        [DataMember(Name = "conversationID")]
		public int conversationID;
        [DataMember(Name = "messageType")]
		public String messageType;
        [DataMember(Name = "messageBody")]
		public String messageBody;
        [DataMember(Name = "sentAs")]
		public String sentAs;
        [DataMember(Name = "initiator")]
		public String initiator;


		public serverMessage(int inputMessageID, int inputConversationID, String inputMessageType,
							 String inputMessageBody, String inputSentAs, String inputInitiator)
		{
			messageID = inputMessageID;
			conversationID = inputConversationID;
			messageType = inputMessageType;
			messageBody = inputMessageBody;
			sentAs = inputSentAs;
			initiator = inputInitiator;
		}

        private ExtensionDataObject messageDataValue;
        public ExtensionDataObject ExtensionData {
            get
            {
                return messageDataValue;
            }
            set
            {
                messageDataValue = value;
            }
        }
    }

    public class serverMessageRW
    {
        serverMessage targetMessage;
        public serverMessageRW( byte[] encodedMessage ) 
        {
            MemoryStream rawData = new MemoryStream(encodedMessage);
            BinaryReader readingStream = new BinaryReader(rawData);
            DataContractJsonSerializer messageReader = new DataContractJsonSerializer(typeof(serverMessage));
            targetMessage = (serverMessage)messageReader.ReadObject(readingStream);
		}

        byte[] EncodeMessage()
        {
            MemoryStream writingStream = new MemoryStream();
            DataContractJsonSerializer messageWriter = new DataContractJsonSerializer(typeof(serverMessage));
            messageWriter.WriteObject(writingStream, targetMessage);
            return writingStream.GetBuffer();
        }
    }
}
