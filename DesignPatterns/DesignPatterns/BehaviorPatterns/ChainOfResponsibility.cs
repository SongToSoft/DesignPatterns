using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehaviorPatterns
{
    static class ChainOfResponsibility
    {
        //Handler
        abstract class Delivery
        {
            public Delivery Shiftworker { get; set; }
            public abstract void HandleRequest(int packageWeight);
        }

        class AirDelivery : Delivery
        {
            public override void HandleRequest(int packageWeight)
            {
                if (packageWeight < 10)
                {
                    Console.WriteLine("Delivery by Air");
                }
                else
                {
                    Shiftworker.HandleRequest(packageWeight);
                }
            }
        }

        class TrainDelivery : Delivery
        {
            public override void HandleRequest(int packageWeight)
            {
                Console.WriteLine("Delivery by Train");
            }
        }

        //Client
        class PostOffice
        {
            private AirDelivery airDelivery;
            private TrainDelivery trainDelivery;

            public PostOffice()
            {
                airDelivery = new AirDelivery();
                trainDelivery = new TrainDelivery();

                airDelivery.Shiftworker = trainDelivery;
            }

            public void Delivery(int packageWeight)
            {
                airDelivery.HandleRequest(packageWeight);
            }
        }

        static public void Run()
        {
            PostOffice postOffice = new PostOffice();
            int packageFirst = 5, packageSecond = 20;

            postOffice.Delivery(packageFirst);
            postOffice.Delivery(packageSecond);
        }
    }
}
