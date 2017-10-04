using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Pizza pizza1 = new TomatoPizza(new ItalianPizza()); // итальянская пицца с томатами
            Print("Name: {0}", pizza1.Name);
            Print("Price: {0}", pizza1.GetCost());

            Pizza pizza2 = new CheesePizza(new ItalianPizza());// итальянская пиццы с сыром
            Print("Name: {0}", pizza2.Name);
            Print("Price: {0}", pizza2.GetCost());

            Pizza pizza3 = new TomatoPizza(new BulgerianPizza());
            pizza3 = new CheesePizza(pizza3);// болгарская пиццы с томатами и сыром
            Print("Name: {0}", pizza3.Name);
            Print("Price: {0}", pizza3.GetCost());

            Console.ReadLine();
        }

        public static void Print(string format, params object[] args)
        {
            Console.WriteLine(format, args);
        }
    }

    abstract class Pizza
    {
        public Pizza(string n)
        {
            this.Name = n;
        }
        public string Name { get; protected set; }
        public abstract int GetCost();
    }

    class ItalianPizza : Pizza
    {
        public ItalianPizza() : base("Italian pizza")
        { }
        public override int GetCost()
        {
            return 10;
        }
    }
    class BulgerianPizza : Pizza
    {
        public BulgerianPizza()
            : base("Bolgarian pizza")
        { }
        public override int GetCost()
        {
            return 8;
        }
    }

    abstract class PizzaDecorator : Pizza
    {
        protected Pizza pizza;
        public PizzaDecorator(string n, Pizza pizza) : base(n)
        {
            this.pizza = pizza;
        }
    }

    class TomatoPizza : PizzaDecorator
    {
        public TomatoPizza(Pizza p)
            : base(p.Name + ", with tomato", p)
        { }

        public override int GetCost()
        {
            return pizza.GetCost() + 3;
        }
    }

    class CheesePizza : PizzaDecorator
    {
        public CheesePizza(Pizza p)
            : base(p.Name + ", with cheese", p)
        { }

        public override int GetCost()
        {
            return pizza.GetCost() + 5;
        }
    }
}
