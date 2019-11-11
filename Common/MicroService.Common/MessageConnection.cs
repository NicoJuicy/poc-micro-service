//using System;
//using MyNatsClient;
//namespace MicroService.Common
//{
//    public static class MessageConnection
//    {
//        public static NatsClient c;
//        static MessageConnection()
//        {
//            /*
//            Options opts = ConnectionFactory.GetDefaultOptions();

//            opts.Servers = new string[] { "192.168.99.100" };
//            opts.AsyncErrorEventHandler += (sender, args) =>
//        {
//            Console.WriteLine("Error: ");
//            Console.WriteLine("   Server: " + args.Conn.ConnectedUrl);
//            Console.WriteLine("   Message: " + args.Error);
//            Console.WriteLine("   Subject: " + args.Subscription.Subject);
//        };

//            opts.ServerDiscoveredEventHandler += (sender, args) =>
//            {
//                Console.WriteLine("A new server has joined the cluster:");
//                Console.WriteLine("    " + String.Join(", ", args.Conn.DiscoveredServers));
//            };

//            opts.ClosedEventHandler += (sender, args) =>
//            {
//                Console.WriteLine("Connection Closed: ");
//                Console.WriteLine("   Server: " + args.Conn.ConnectedUrl);
//            };

//            opts.DisconnectedEventHandler += (sender, args) =>
//            {
//                Console.WriteLine("Connection Disconnected: ");
//                Console.WriteLine("   Server: " + args.Conn.ConnectedUrl);
//            };

//            c =  new ConnectionFactory().CreateConnection(opts);
//*/
//            var connectionInfo = new ConnectionInfo(
//                //Hosts to use. When connecting, will randomize the list
//                //and try to connect. First successful will be used.
//                new[]
//                {
//        new Host("192.168.99.100", 4222)
//                });

//            var client = new NatsClient(connectionInfo);
//            client.Connect();
//        }
//    }
//}
