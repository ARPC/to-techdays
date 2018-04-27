using NServiceBus;

namespace Common
{
	public class TestMessage :
		IMessage
	{
		public string Message { get; set; }
	}
}
