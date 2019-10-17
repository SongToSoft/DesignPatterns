using System;

namespace DesignPatterns.StructuralPatterns
{
    static class Facade
    {
        class ActionFacade
        {
            public HttpRequests HttpRequests { get; }
            public TftpRequests TftpRequests { get; }
            public TcpRequests TcpRequests { get; }

            public ActionFacade(HttpRequests _httpRequests, TftpRequests _tftpRequests, TcpRequests _tcpRequests)
            {
                HttpRequests = _httpRequests;
                TftpRequests = _tftpRequests;
                TcpRequests = _tcpRequests;
            }
        }

        class HttpRequests
        {
            public void Get(string url)
            {
                Console.WriteLine("GET: " + url);
            }

            public void Post(string url, string filename)
            {
                Console.WriteLine("POST: " + url + " " + filename);
            }

            public void Put(string url, string filename)
            {
                Console.WriteLine("PUT: " + url + " " + filename);
            }
        }

        class TftpRequests
        {
            public void StartServer()
            {
                Console.WriteLine("Start tftp server");
            }

            public void SendFile(string filename)
            {
                Console.WriteLine("Send file: " + filename + " over tftp");
            }
        }

        class TcpRequests
        {
            public void Ping(string ip)
            {
                Console.WriteLine("Tcp ping: " + ip);
            }
        }

        static public void Run()
        {
            Console.WriteLine("------------Facade------------");
            ActionFacade actionFacade = new ActionFacade(new HttpRequests(), new TftpRequests(), new TcpRequests());
            actionFacade.HttpRequests.Get("SomeUrl");
            actionFacade.TftpRequests.StartServer();
            actionFacade.TcpRequests.Ping("SomeIp");         
        }
    }
}
