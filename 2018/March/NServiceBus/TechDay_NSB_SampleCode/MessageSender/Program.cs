using System;
using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.Transport.SQLServer;
using Common;

namespace Service1
{
	class Program
	{
		static void Main(string[] args)
		{
			//setup my endpoint (message queues, data tables ie)
			var connection = @"Data Source=localhost;Database=SomethingElse;Integrated Security=True;Max Pool Size=100";
			var endpointConfiguration = new EndpointConfiguration("Service1.Endpoint");
			endpointConfiguration.SendFailedMessagesTo("error");
			endpointConfiguration.AuditProcessedMessagesTo("audit");
			endpointConfiguration.EnableInstallers();
			endpointConfiguration.UsePersistence<NHibernatePersistence>();

			var transport = endpointConfiguration.UseTransport<SqlServerTransport>();
			transport.ConnectionString(connection);
			transport.DefaultSchema("dbo");
			transport.UseSchemaForQueue("error", "dbo");
			transport.UseSchemaForQueue("audit", "dbo");

			//setup routing, sending TestMessage to receiver endpoint ("Service2.Endpoint")
			var routing = transport.Routing();
			routing.RouteToEndpoint(typeof(TestMessage), "Service2.Endpoint");

			var endpointInstance = Task.Run(async () => await Endpoint.Start(endpointConfiguration)
				.ConfigureAwait(false)).Result;

			//create and send the message
			Task sendMessage = endpointInstance.Send(new TestMessage { Message = "Hello, world!"});
			Task.WaitAll(sendMessage);
		
			Console.WriteLine("Done!");
			Console.ReadLine();
		}
	}
}
