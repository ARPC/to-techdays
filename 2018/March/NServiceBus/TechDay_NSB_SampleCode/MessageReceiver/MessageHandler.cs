using System.Threading.Tasks;
using Common;
using NServiceBus;
using NServiceBus.Logging;

public class MessageHandler :
	IHandleMessages<TestMessage> //handles messages of type TestMessage
{
	static ILog log = LogManager.GetLogger<MessageHandler>();

	public Task Handle(TestMessage message, IMessageHandlerContext context)
	{
		log.Info($"Message: {message.Message} accepted.");
		return Task.CompletedTask;
	}
}
