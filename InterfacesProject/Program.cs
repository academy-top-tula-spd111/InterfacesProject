namespace InterfacesProject
{
    
    interface IHello
    {
        void Hello();
        void Hello(string message);
        //void Hello(T value);
    }

    interface IHello<T> : IHello
    {
        void Hello(T value);
    }

    class MyColl : IHello
    {
        public void Hello()
        {
            throw new NotImplementedException();
        }

        public void Hello(string message)
        {
            throw new NotImplementedException();
        }
    }

    abstract class AClass
    {
        public abstract void Print();
        public void Show()
        {
            Console.WriteLine("Show");
        }
    }

    class MyClass : AClass
    {
        public override void Print()
        {
            Console.WriteLine("Print");
        }
    }

    public interface IMove
    {
        const int MaxSize = 1000;

        public int Size { get; set; }

        delegate void MoveDelegate();

        event MoveDelegate Event;
        void Move();

        public void Beep()
        {
            Console.WriteLine("BEEEEEP!!!!");
        }
    }

    public class Transport : IMove
    {
        public int Size { get; set; }

        public event IMove.MoveDelegate Event;
        public void Move()
        {
            Console.WriteLine("Transport Move");
            Event?.Invoke();
        }

    }
    interface IA
    {
        void Method();
        void MethodA();
    }

    interface IB
    {
        void Method();
        void MethodB();
    }

    interface IC : IA, IB
    {

    }

    class Y : IA, IB
    {
        void IA.Method()
        {
            Console.WriteLine("Явная реализация Метода из А");
        }

        void IB.Method()
        {
            Console.WriteLine("Явная реализация Метода из В");
        }

        public void Method()
        {
            Console.WriteLine("Общая реализация Метода");
        }

        public void MethodA()
        {
            Console.WriteLine("Метод из А");
        }

        public void MethodB()
        {
            Console.WriteLine("Метод из В");
        }
    }

    interface IPrint
    {
        void Print();

        static void Show()
        {
            Console.WriteLine("Статик метод");
        }
    }

    class HelloBase : IPrint
    {
        public virtual void Print()
        {
            Console.WriteLine("Класс базовый");
        }
    }

    class HelloChild : HelloBase, IPrint
    {
        public override void Print()
        {            
            Console.WriteLine("Класс дочерний");
        }
        void IPrint.Print()
        {
            Console.WriteLine("Метод из интерфейса");
        }
    }

    

    internal class Program
    {
        static void SayBy()
        {
            Console.WriteLine("Good by");
        }
        static void Main(string[] args)
        {
            
            Transport transport = new();
            //transport.Event += SayBy;

            transport.Move();

            //((IMove)transport).Beep();

            ////IMove tran = new Transport();
            ////tran.Beep();

            //MyClass obj = new();

            //obj.Print();
            //obj.Show();

            //Y obj = new();
            //obj.Method();
            //obj.MethodA();
            //obj.MethodB();
            //(obj as IA).Method();
            //(obj as IB).Method();

            HelloChild child = new();
            (child as IPrint).Print();
            child.Print();
            IPrint.Show();
        }
    }
}