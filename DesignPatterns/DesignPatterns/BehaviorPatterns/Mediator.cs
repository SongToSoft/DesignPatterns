using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehaviorPatterns
{
    static class Mediator
    {
        abstract class AbstractMediator
        {
            public abstract void Send(string msg, NetworkMember member);
        }

        abstract class NetworkMember
        {
            protected AbstractMediator mediator;

            public NetworkMember(AbstractMediator mediator)
            {
                this.mediator = mediator;
            }

            public virtual void Send(string message)
            {
                mediator.Send(message, this);
            }

            public abstract void Notify(string message);
        }

        class Client : NetworkMember
        {
            public Client(AbstractMediator mediator)
                : base(mediator)
            {
            }

            public override void Notify(string message)
            {
                Console.WriteLine("Message for Client: " + message);
            }
        }

        class Server : NetworkMember
        {
            public Server(AbstractMediator mediator)
                : base(mediator)
            { }

            public override void Notify(string message)
            {
                Console.WriteLine("Message for Server: " + message);
            }
        }

        class ManagerMediator : AbstractMediator
        {
            public NetworkMember Client { get; set; }
            public NetworkMember Server { get; set; }
       
            public override void Send(string message, NetworkMember member)
            {
                if (Client == member)
                {
                    Server.Notify(message);
                }
                if (Server == member)
                {
                    Client.Notify(message);
                }
            }
        }

        static public void Run()
        {
            ManagerMediator mediator = new ManagerMediator();
            NetworkMember client = new Client(mediator);
            NetworkMember server = new Server(mediator);

            mediator.Client = client;
            mediator.Server = server;

            client.Send("Do something");
            server.Send("Ok, i'm doing");

        }
    }
}
