using System;
namespace Decorator.Examples
{
    class MainApp
    {
        static void Main()
        {
            // Create ConcreteComponent and two Decorators
            ConcreteChristmasTree c =
            new ConcreteChristmasTree();
            ConcreteDecoratorA d1 =
            new ConcreteDecoratorA();
            ConcreteDecoratorB d2 =
            new ConcreteDecoratorB();
            ConcreteDecoratorC d3 =
            new ConcreteDecoratorC();
            // Link decorators
            d1.SetComponent(c);
            d1.SetColor("червоний");
            d1.Operation();
            d1.SetColor("зелений");
            d1.Operation();
            d2.SetComponent(c);
            d2.SetSize("велика");
            d2.Operation();
            d3.SetComponent(c);
            d3.Operation();


            // Wait for user
            Console.Read();
        }
    }
    // "Component"
    abstract class ChristmasTree
    {
        public abstract void Operation();
    }
    // "ConcreteComponent"
    class ConcreteChristmasTree : ChristmasTree
    {
        public override void Operation()
        {
            Console.WriteLine("На ялинку додано прикрасу: ");
        }
    }
    // "Decorator"
    abstract class Decorator : ChristmasTree
    {
        protected ChristmasTree tree;
        public void SetComponent(ChristmasTree tree)
        {
            this.tree = tree;
        }
        public override void Operation()
        {
            if (tree != null)
            {
                tree.Operation();
            }
        }
    }
    // "ConcreteDecoratorA"
    class ConcreteDecoratorA : Decorator
    {
        private string addedState;
        private string color;
        public void SetColor(string color)
        {
            this.color = color;
        }
        public override void Operation()
        {
            base.Operation();
            addedState = " шарик";
            Console.WriteLine(color+addedState);
        }
    }

    class ConcreteDecoratorB : Decorator
    {
        private string addedState;
        private string size;
        public void SetSize(string size)
        {
            this.size = size;
        }
        public override void Operation()
        {
            base.Operation();
            addedState = " зірка";
            Console.WriteLine(size+addedState);
        }
    }
    // "ConcreteDecoratorB"
    class ConcreteDecoratorC : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            Console.WriteLine("гірлянда");
            AddedBehavior();
        }
        void AddedBehavior()
        {
            Console.WriteLine("Ялинка тепер світиться!");
        }
    }
}