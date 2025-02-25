namespace PizzaPalaceApi.Services
{
    public abstract class Pizza
    {
        public abstract string GetPizzaType();
        public abstract decimal Price { get; }
    }

    public class MargheritaPizza : Pizza
    {
        public override string GetPizzaType() => "Margherita";
        public override decimal Price => 8.99m;
    }

    public class PepperoniPizza : Pizza
    {
        public override string GetPizzaType() => "Pepperoni";
        public override decimal Price => 10.99m;
    }
}