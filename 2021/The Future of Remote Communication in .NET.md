

# The future of Remote Communication in .NET

> Helping machines communicate with each other

## Why isn't WCF supported in .Net Core?

28 October 2018

https://www.ben-morris.com/why-isnt-wcf-supported-in-net-core/

> WCF is not supported in .NET Core since it's a Windows specific technology and .NET Core is supposed to be cross-platform.

### Caught by the rise of REST?

WCF has in part been undermined by the rising popularity of REST. The programming model in WCF is geared around *operations* rather than *resources* so it struggles to support genuinely resource-orientated, "RESTful" APIs. Microsoft’s response to REST [is ASP.Net WebAPI].

Added to this is the growing popularity of [gRPC](https://grpc.io/) as an alternative means of **contract-first development**. The format allows you to define genuinely **cross-platform operations and models that are tolerant to change**.  Microsoft are including a [gRPC template in .Net Core 3.0](https://devblogs.microsoft.com/aspnet/asp-net-core-updates-in-net-core-3-0-preview-3/) which does rather imply that it as a preferred technology for contract-first development.

### Why hasn't WCF been ported to .Net Core?

> A .Net Core port has been accepted into the .Net Foundation

Started in June 2019. The initial version will allow creating HTTP and TCP SOAP services to be created on top of the .Net Core Kestrel server. Although these appear to be the most popular use case for WCF, it is not clear how easy it will be to port existing services to the .Net Core version.

There may also be some practical obstacles to implementing a .Net Core WCF stack. Part of the problem is with the “W” in WCF, i.e. "Windows". Much of the work of porting WCF to a cross-platform paradigm will involve re-implementing operation system libraries, particularly in areas such as socket layers and cryptography. These are the areas of WCF that are never likely to make it through a .Net Core port.

https://github.com/CoreWCF/announcements/issues/2

## CoreWCF 0.1.0 GA Release

Feb 19, 2021 • Matt Connew

https://corewcf.github.io/blog/2021/02/19/corewcf-ga-release

Major Contributors (10,000+ lines of code):
[@mconnew](https://github.com/mconnew) (Microsoft)
[@birojnayak](https://github.com/birojnayak) (Amazon AWS) 

- [Microsoft] only wants one service host in .NET Core (not the WCF ServiceHost class)
- WCF prototype on top of ASP.NET Core
- CoreWCF project caught the attention of the Amazon AWS team and they have been contributing significantly to help make this project a success
- Supportability and maintainability is a high priority for CoreWCF.
- Removing Asynchronous Programming Model (APM) api’s and code, and removing direct native system calls and IO code.
- CoreWCF now uses async/await Task based asynchronous programming throughout. CoreWCF also switched to a request push pipeline model adopting the ASP.NET Core middleware pattern.
- CoreWCF doesn’t even know what a Socket is and yet supports NetTcp. ASP.NET Core handles all of that for CoreWCF. It just reads and writes to pipes or streams.

#### Old

```csharp
ServiceHost host = new ServiceHost(typeof(MyService), new Uri(http://localhost/myservice));
host.AddServiceEndpoint(typeof(IMyService), new BasicHttpBinding(), "/basic");
host.Open();
```

#### New

A single method is called to add WCF support.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddServiceModelServices();
}
```

```csharp
public void Configure(IApplicationBuilder app)
{
    app.UseServiceModel(builder =>
    {
        builder.AddService<MyService>();
        builder.AddServiceEndpoint<MyService, IMyService>(new BasicHttpBinding(), "/basic");
    });
}
```

### Road map

https://github.com/CoreWCF/CoreWCF/blob/main/Documentation/roadmap.md

Depends on ASP.NET Core 2.1

This enables still running on .NET Framework through the porting process

The major version being 0 is a reflection of some core features not currently available which would enable justification of a 1.0 release version. **An example of a feature required for 1.0 is support for WSDL generation.**

## gRPC for Windows Communication Foundation (WCF) developers

https://docs.microsoft.com/en-us/aspnet/core/grpc/why-migrate-wcf-to-dotnet-grpc?view=aspnetcore-5.0

 WCF and gRPC are RPC (remote procedure call) frameworks with the same goals:

- Make it possible to code as though the client and server are on the same platform.
- Provide a simplified portable networking API.

Both platforms share the requirement of declaring and implementing an interface.

The many types of RPC calls that gRPC supports map well to the bindings available to WCF services. For more information and examples, see [Migrate a WCF solution to gRPC](https://docs.microsoft.com/en-us/dotnet/architecture/grpc-for-wcf-developers/migrate-wcf-to-grpc).

gRPC uses HTTP/2

- Is a smaller, faster binary protocol.

gRPC uses Protobuf, an efficient binary format, to serialize messages. Protobuf messages are:

- Fast to serialize and deserialize.
- Use less bandwidth than text-based formats.

Like WCF, gRPC automatically generates messages and a strongly typed client.

### gRPC for Web Clients

gRPC **CAN** be used over HTTP/1.1 on the web via https://github.com/grpc/grpc-web

A JavaScript implementation of [gRPC](https://grpc.io/) for browser clients

gRPC-web clients connect to gRPC services via a special proxy

## gRPC as a migration path for WCF to .NET Core and .NET 5

.NET Core and .NET 5 marks a shift in the way that Microsoft delivers remote communication solutions to developers who want to deliver services across a range of platforms.

> across different languages, runtimes, operating system, containers

.NET Core and .NET 5 support [calling WCF services](https://docs.microsoft.com/en-us/dotnet/core/additional-tools/wcf-web-service-reference-guide), but won't offer server-side support for hosting WCF.

There are two recommended paths for modernizing WCF apps:

- gRPC is built on modern technologies and has emerged as the most popular choice across the developer community for RPC apps. Starting with .NET Core 3.0, modern .NET platforms have excellent support for gRPC. Migrating WCF services to use gRPC helps provide the RPC features, performance, an interoperability needed in modern apps.

- [CoreWCF](https://github.com/CoreWCF/CoreWCF) is a community effort to bring support for hosting WCF services to .NET Core and .NET 5. CoreWCF only supports a subset of WCF's features, and .NET Framework apps that migrate to use it will need code changes and testing to be successful. **CoreWCF is a good choice if an app has to maintain compatibility with existing clients that call WCF services.**

# ASP.NET Core gRPC for WCF Developers

- 01/06/2021

https://docs.microsoft.com/en-us/dotnet/architecture/grpc-for-wcf-developers/

### History

"The fundamental principle of a computer network as nothing more than a group of computers exchanging data with each other to achieve a set of interrelated tasks"

TCP/IP became the gold standard for this type of communication.

Service-oriented architecture (SOA) provided a structure for loosely coupling a broad collection of services that could be provided to an application.

The development of *web services* occurred when all major platforms could access the internet, but they still couldn't interact with each other. Web services have open standards and protocols, including:

- XML to tag and code data.
- Simple Object Access Protocol (SOAP) to transfer data.
- Web Services Definition Language (WSDL) to describe and connect web services to client applications.
- Universal Description, Discovery, and Integration (UDDI) to make web services discoverable by other services.

gRPC was launched, 10 years after Microsoft first released WCF

| Features                                    | WCF                                                          | gRPC                                                         |
| :------------------------------------------ | :----------------------------------------------------------- | :----------------------------------------------------------- |
| Objective                                   | Separate business code from networking implementation.       | Separate business code from interface definition and networking implementation. |
| Define services and messages (chapters 3-4) | Service Contract, Operation Contract, and Data Contract.     | Uses proto file to declare services and messages.            |
| Language (chapters 3-5)                     | Contracts written in C# or Visual Basic.                     | Protocol Buffer language.                                    |
| Wire format (chapter 3)                     | Configurable, including SOAP/XML, Plain XML, JSON, and .NET Binary. | Protocol Buffer binary format (although it's possible to use other formats). |
| Interoperability (chapter 4)                | When using SOAP over HTTP.                                   | Official support: .NET, Java, Python, JavaScript, C/C++, Go, Rust, Ruby, Swift, Dart, PHP. Unofficial support for other languages from the community. |
| Networking (chapter 4)                      | Configured at runtime. Switch between NetTCP, HTTP, and MSMQ. | HTTP/2, currently over TCP only with ASP.NET Core gRPC.      |
| Approach (chapter 4)                        | Runtime generation of serialization, deserialization, and networking code in base classes. | Build-time generation of serialization, deserialization, and networking code in base classes. |
| Security (chapter 6)                        | Authentication, WS-Security, message encryption.             | Credentials, ASP.NET Core security, TLS networking.          |

WCF uses WSDL to expose metadata about services.

gRPC uses the Interface Definition Language (IDL) from Protocol Buffers. The Protocol Buffers IDL is a custom, platform-neutral language with an open specification. Developers author `.proto` files to describe services, along with their inputs and outputs. These `.proto` files can then be used to generate language- or platform-specific stubs for clients and servers, allowing multiple different platforms to communicate. By sharing `.proto` files, teams can generate code to use each others' services, without needing to take a code dependency.

One of the advantages of the Protobuf IDL is that as a custom language, it enables gRPC to be completely language and platform agnostic, not favoring any technology over another.

The Protobuf IDL is also designed for humans to both read and write, whereas WSDL is intended as a machine-readable/writable format. Changing the WSDL of a WCF service typically requires changing the service, running the service, and regenerating the WSDL file from the server. By contrast, with a `.proto` file, changes are simple to apply with a text editor, and automatically flow through the generated code. 

When compared with XML, and particularly SOAP, messages encoded by using Protobuf have many advantages. Protobuf messages tend to be smaller than the same data serialized as SOAP XML, and encoding, decoding, and transmitting them over a network can be faster.

The potential disadvantage of Protobuf compared to SOAP is that, because the messages aren't readable by humans, additional tooling is required to debug message content.

#### Network Protocols

Unlike Windows Communication Foundation (WCF), gRPC uses HTTP/2 as a base for its networking. This protocol offers significant advantages over WCF and SOAP, which operate only on HTTP/1.1

##### HTTP/2

Unlike Windows Communication Foundation (WCF), gRPC uses HTTP/2 as a base for its networking. This protocol offers significant advantages over WCF and SOAP, which operate only on HTTP/1.1

### Protocol Buffers

gRPC services send and receive data as *Protocol Buffer (Protobuf) messages*, similar to data contracts in Windows Communication Foundation (WCF). Protobuf is an efficient way of serializing structured data for machines to read and write, without the overhead that human-readable formats like XML or JSON incur.

### How Protobuf works

Most .NET object serialization techniques, including WCF's data contracts, work by using reflection to analyze the object structure at runtime. By contrast, most Protobuf libraries require you to define the structure up front by using a dedicated language (*Protocol Buffer Language*) in a `.proto` file. A compiler then uses this file to generate code for any of the supported platforms. Supported platforms include .NET, Java, C/C++, JavaScript, and many more.

The Protobuf compiler, `protoc`, is maintained by Google, although alternative implementations are available. The generated code is efficient and optimized for fast serialization and deserialization of data.

The Protobuf wire format is a binary encoding. It uses some clever tricks to minimize the number of bytes used to represent messages.

```csharp
{
    [DataContract]
    public class Stock
    {
        [DataMember]
        public int Id { get; set;}
        [DataMember]
        public string Symbol { get; set;}
        [DataMember]
        public string DisplayName { get; set;}
        [DataMember]
        public int MarketId { get; set; }
    }
}
```

```protobuf

syntax = "proto3";

option csharp_namespace = "TraderSys";

message Stock {

    int32 id = 1;
    string symbol = 2;
    string display_name = 3;
    int32 market_id = 4;

}
```

#### Field numbers

Field numbers are an important part of Protobuf. They're used to identify fields in the binary encoded data, which means they can't change from version to version of your service. The advantage is that backward compatibility and forward compatibility are possible. Clients and services will ignore field numbers that they don't know about, as long as the possibility of missing values is handled.

### gRPC for .NET

Grpc.Core - has a Protobuf code generator for C# - https://github.com/grpc/grpc

Grpc.NET - https://github.com/grpc/grpc-dotnet

Starting from **May 2021**, gRPC for .NET is the recommended implemention of gRPC for C#. (versus Grpc.Core)

`protobuf-net.Grpc` takes the best bits from `protobuf-net` and `Grpc.Net` and smashes them together to give you:

### protobuf-net.Grpc

https://protobuf-net.github.io/protobuf-net.Grpc/gettingstarted.html

Simple gRPC access in .NET Core 3+ and .NET Framework 4.6.1+ - think WCF, but over gRPC

protobuf is contract first. **protobuf-net.Grpc is code first**

```csharp
[DataContract]
public class MultiplyRequest
{
    [DataMember(Order = 1)]
    public int X { get; set; }

    [DataMember(Order = 2)]
    public int Y { get; set; }
}

[DataContract]
public class MultiplyResult
{
    [DataMember(Order = 1)]
    public int Result { get; set; }
}
```

