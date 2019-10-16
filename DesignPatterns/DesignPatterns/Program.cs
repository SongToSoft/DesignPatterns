using DesignPatterns.BehaviorPatterns;
using DesignPatterns.GenerativePatterns;
using DesignPatterns.StructuralPatterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//SOLID

//Single Responsibility Principle(Принцип единственной обязанности)
//Под обязанностью здесь понимается набор функций, которые выполняют единую задачу.Суть этого принципа заключается в том,
//что класс должен выполнять одну единственную задачу.Весь функционал класса должен быть целостным, обладать высокой связностью
//(high cohesion).

//Open/Closed Principle(Принцип открытости/закрытости)
//Сущности программы должны быть открыты для расширения, но закрыты для изменения.
//Суть этого принципа состоит в том, что система должна быть построена таким образом, что все ее последующие изменения
//должны быть реализованы с помощью добавления нового кода, а не изменения уже существующего.

//Liskov Substitution Principle(Принцип подстановки Лисков)
//Должна быть возможность вместо базового типа подставить любой его подтип.
//Фактически принцип подстановки Лисков помогает четче сформулировать иерархию классов, определить функционал для базовых и
//производных классов и избежать возможных проблем при применении полиморфизма.

//Interface Segregation Principle(Принцип разделения интерфейсов)
//Принцип относится к тем случаям, когда классы имеют
//"жирный интерфейс", то есть слишком раздутый интерфейс, не все методы и свойства которого используются и могут быть востребованы.
//Таким образом, интерфейс получатся слишком избыточен или "жирным".

//Dependency Inversion Principle(Принцип инверсии зависимостей)
//Cлужит для создания слабосвязанных сущностей, которые легко тестировать, модифицировать и обновлять.Этот принцип можно сформулировать следующим образом:
//Модули верхнего уровня не должны зависеть от модулей нижнего уровня.И те и другие должны зависеть от абстракций.
//Абстракции не должны зависеть от деталей. Детали должны зависеть от абстракций.

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            //GenerativePatterns
            FactoryMethod.Run();
            AbstractFactory.Run();
            Singleton.Run();
            LazySingleton.Run();
            Prototype.Run();
            Builder.Run();

            //BehaviorPatterns
            Strategy.Run();
            Observer.Run();
            Command.Run();
            TemplateMethod.Run();
            Iterator.Run();
            State.Run();
            ChainOfResponsibility.Run();
            Interpreter.Run();
            Mediator.Run();
            Memento.Run();
            Visitor.Run();

            //StructuralPatterns
            Decorator.Run();
            Adapter.Run();
            Facade.Run();
            Composite.Run();
            Proxy.Run();
            Bridge.Run();
            Flyweight.Run();

            Console.ReadKey();
        }
    }
}
