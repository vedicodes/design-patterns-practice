namespace ConsolePractice;

public abstract class Beverage
{
    protected string description = "Unknown Brew";
    public virtual string GetDescription()
    {
        return description;
    }
    public abstract double Cost();
}

/*
    TODO: Add classes of the following
    Blends
        HouseBlend
        Decaf
        Espresso
    Condiments
        Soy
        Mocha
*/

public class DarkRoast : Beverage // Blend
{
    public DarkRoast()
    {
        description = "Dark Roast";
    }
    public override double Cost()
    {
        return .90;
    }
}

public abstract class CondimentDecorator : Beverage
{
    public override abstract string GetDescription();
}

public class Whip : CondimentDecorator // Condiment
{
    readonly Beverage beverage;
    public Whip(Beverage beverage)
    {
        this.beverage = beverage;
    }
    public override string GetDescription()
    {
        return string.Format("{0}, Whip", beverage.GetDescription());
    }
    public override double Cost()
    {
        return beverage.Cost() + .10;
    }
}

public class Milk : CondimentDecorator // Condiment
{
    readonly Beverage beverage;
    public Milk(Beverage beverage)
    {
        this.beverage = beverage;
    }
    public override string GetDescription()
    {
        return string.Format("{0}, Milk", beverage.GetDescription());
    }
    public override double Cost()
    {
        return beverage.Cost() + .20;
    }
}

public abstract class Pizza
{
    protected string description = "Unknown Crust";
    public virtual string GetDescription()
    {
        return description;
    }
    public abstract double Cost();
}

public class ThinCrustPizza : Pizza
{
    public ThinCrustPizza()
    {
        description = "Thin Crust Pizza";
    }
    public override double Cost()
    {
        return 8;
    }
}

public class ThickCrustPizza : Pizza
{
    public ThickCrustPizza()
    {
        description = "Thick Crust Pizza";
    }
    public override double Cost()
    {
        return 10;
    }
}

public abstract class ToppingDecorator : Pizza
{
    public override abstract string GetDescription();
}

public class CheeseTopping : ToppingDecorator
{
    readonly Pizza pizza;
    public CheeseTopping(Pizza pizza)
    {
        this.pizza = pizza;
    }
    public override string GetDescription()
    {
        return string.Format("{0}, Cheese", pizza.GetDescription());
    }
    public override double Cost()
    {
        return pizza.Cost() + 5;
    }
}

public class OlivesTopping : ToppingDecorator
{
    readonly Pizza pizza;
    public OlivesTopping(Pizza pizza)
    {
        this.pizza = pizza;
    }
    public override string GetDescription()
    {
        return string.Format("{0}, Olives", pizza.GetDescription());
    }
    public override double Cost()
    {
        return pizza.Cost() + 1.5;
    }
}

public class PeppersTopping : ToppingDecorator
{
    readonly Pizza pizza;
    public PeppersTopping(Pizza pizza)
    {
        this.pizza = pizza;
    }
    public override string GetDescription()
    {
        return string.Format("{0}, Peppers", pizza.GetDescription());
    }
    public override double Cost()
    {
        return pizza.Cost() + 1;
    }
}

public class DecoratorPattern
{
    public static void Run()
    {
        Pizza pizza = new ThickCrustPizza();
        pizza = new CheeseTopping(pizza);
        pizza = new CheeseTopping(pizza);
        pizza = new OlivesTopping(pizza);
        pizza = new PeppersTopping(pizza);
        Console.WriteLine("Description: {0}\nCost: ${1:0.##}", pizza.GetDescription(), pizza.Cost());
    }
}