using System;
using NServiceBus;
using System.Threading.Tasks;
using Common;
using NServiceBus.Transport.SQLServer;

namespace Service2
{
	class Program
	{
		static void Main(string[] args)
		{
			//setup my endpoint (message queues, data tables ie)
			var connection = @"Data Source=localhost;Database=SomethingElse;Integrated Security=True;Max Pool Size=100";
			var endpointConfiguration = new EndpointConfiguration("Service2.Endpoint");
			endpointConfiguration.SendFailedMessagesTo("error");
			endpointConfiguration.AuditProcessedMessagesTo("audit");
			endpointConfiguration.EnableInstallers();
			endpointConfiguration.UsePersistence<NHibernatePersistence>();

			var transport = endpointConfiguration.UseTransport<SqlServerTransport>();
			transport.ConnectionString(connection);
			transport.DefaultSchema("dbo");
			transport.UseSchemaForQueue("error", "dbo");
			transport.UseSchemaForQueue("audit", "dbo");

			//setup routing, listening to TestMessage at this endpoint ("Service2.Endpoint")
			//var routing = transport.Routing();
			//routing.RegisterPublisher(typeof(TestMessage).Assembly, "Service2.Endpoint");
			var endpointInstance = Task.Run(async () => await Endpoint.Start(endpointConfiguration)
				.ConfigureAwait(false)).Result;

			Console.ReadLine();
		}
	}
}
