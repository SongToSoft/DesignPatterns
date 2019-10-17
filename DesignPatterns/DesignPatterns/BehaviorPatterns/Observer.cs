using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.BehaviorPatterns
{
    static class Observer
    {
        interface IObserver
        {
            void Update(SoccerPlayer player);
        }

        interface IObservable
        {
            void RegisterObserver(IObserver observer);
            void RemoveObserver(IObserver observer);
            void NotifyObservers();
        }

        class SoccerPlayer : IObservable
        {
            private List<IObserver> observers = new List<IObserver>();
            private int cost;
            private string name;

            public SoccerPlayer(string _name)
            {
                name = _name;
            }

            public string Name()
            {
                return name;
            }
            public int GetCost()
            {
                return cost;
            }

            public void SetCost(int _cost)
            {
                cost = _cost;
                NotifyObservers();
            }

            public void RegisterObserver(IObserver observer)
            {
                observers.Add(observer);
            }

            public void RemoveObserver(IObserver observer)
            {
                observers.Remove(observer);
            }

            public void NotifyObservers()
            {
                for (int i = 0; i < observers.Count; ++i)
                {
                    observers[i].Update(this);
                }
            }
        }

        class Club : IObserver
        {
            private string name;
            private int money;
    
            public Club(string _name, int _money)
            {
                name = _name;
                money = _money;
            }
 
            public void Update(SoccerPlayer player)
            {
                if (money >= player.GetCost())
                {
                    Console.WriteLine("Club " + name + " can buy player " + player.Name());
                }
            }
        }
 
        static public void Run()
        {
            Console.WriteLine("------------Observer------------");
            Club mu = new Club("Manchester United", 150);
            Club cl = new Club("Chelsea", 100);
            Club ju = new Club("Juventus", 70);
            SoccerPlayer messi = new SoccerPlayer("Messi");
 
            messi.RegisterObserver(mu);
            messi.RegisterObserver(cl);
            messi.RegisterObserver(ju);

            messi.SetCost(90);
        }
    }
}
