namespace ConsolePractice;

public interface PizzaVariety
{
    public void Prepare();
    public void Bake();
    public void Cut();
    public void Box();
    public void Ready();
}

public class ChicagoStyleCheesePizza : PizzaVariety
{
    public void Prepare()
    {
        Console.WriteLine("Preparing Chicago Style Cheese Pizza");
    }
    public void Bake()
    {
        Console.WriteLine("Making Chicago Style Cheese Pizza");
    }
    public void Cut()
    {
        Console.WriteLine("Cutting Chicago Style Cheese Pizza");
    }
    public void Box()
    {
        Console.WriteLine("Packeging Chicago Style Cheese Pizza");
    }
    public void Ready()
    {
        Console.WriteLine("Chicago Style Cheese Pizza is Ready!");
    }
}

public class ChicagoStyleVeggiePizza : PizzaVariety
{
    public void Prepare()
    {
        Console.WriteLine("Preparing Chicago Style Veggie Pizza");
    }
    public void Bake()
    {
        Console.WriteLine("Making Chicago Style Veggie Pizza");
    }
    public void Cut()
    {
        Console.WriteLine("Cutting Chicago Style Veggie Pizza");
    }
    public void Box()
    {
        Console.WriteLine("Packeging Chicago Style Veggie Pizza");
    }
    public void Ready()
    {
        Console.WriteLine("Chicago Style Veggie Pizza is Ready!");
    }
}

public class ChicagoStylePepperoniPizza : PizzaVariety
{
    public void Prepare()
    {
        Console.WriteLine("Preparing Chicago Style Pepperoni Pizza");
    }
    public void Bake()
    {
        Console.WriteLine("Making Chicago Style Pepperoni Pizza");
    }
    public void Cut()
    {
        Console.WriteLine("Cutting Chicago Style Pepperoni Pizza");
    }
    public void Box()
    {
        Console.WriteLine("Packeging Chicago Style Pepperoni Pizza");
    }
    public void Ready()
    {
        Console.WriteLine("Chicago Style Pepperoni Pizza is Ready!");
    }
}

public class NYStyleCheesePizza : PizzaVariety
{
    public void Prepare()
    {
        Console.WriteLine("Preparing New York Style Cheese Pizza");
    }
    public void Bake()
    {
        Console.WriteLine("Making New York Style Cheese Pizza");
    }
    public void Cut()
    {
        Console.WriteLine("Cutting New York Style Cheese Pizza");
    }
    public void Box()
    {
        Console.WriteLine("Packeging New York Style Cheese Pizza");
    }
    public void Ready()
    {
        Console.WriteLine("New York Style Cheese Pizza is Ready!");
    }
}

public class NYStyleVeggiePizza : PizzaVariety
{
    public void Prepare()
    {
        Console.WriteLine("Preparing New York Style Veggie Pizza");
    }
    public void Bake()
    {
        Console.WriteLine("Making New York Style Veggie Pizza");
    }
    public void Cut()
    {
        Console.WriteLine("Cutting New York Style Veggie Pizza");
    }
    public void Box()
    {
        Console.WriteLine("Packeging New York Style Veggie Pizza");
    }
    public void Ready()
    {
        Console.WriteLine("New York Style Veggie Pizza is Ready!");
    }
}

public class NYStylePepperoniPizza : PizzaVariety
{
    public void Prepare()
    {
        Console.WriteLine("Preparing New York Style Pepperoni Pizza");
    }
    public void Bake()
    {
        Console.WriteLine("Making New York Style Pepperoni Pizza");
    }
    public void Cut()
    {
        Console.WriteLine("Cutting New York Style Pepperoni Pizza");
    }
    public void Box()
    {
        Console.WriteLine("Packeging New York Style Pepperoni Pizza");
    }
    public void Ready()
    {
        Console.WriteLine("New York Style Pepperoni Pizza is Ready!");
    }
}

public abstract class PizzaStore
{
    public abstract PizzaVariety? CreatePizza(string pizzaType);

    public PizzaVariety? OrderPizza(string pizzaType)
    {
        var pizza = CreatePizza(pizzaType);

        if (pizza != null)
        {
            pizza.Prepare();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();
        }

        return pizza;
    }
}

public class ChicagoStylePizza : PizzaStore
{
    public override PizzaVariety? CreatePizza(string pizzaType)
    {
        PizzaVariety? pizza = null;
        switch (pizzaType)
        {
            case "Pepperoni":
                pizza = new ChicagoStylePepperoniPizza();
                break;
            case "Veggie":
                pizza = new ChicagoStyleVeggiePizza();
                break;
            case "Cheese":
                pizza = new ChicagoStyleCheesePizza();
                break;
            default:
                break;
        }
        return pizza;
    }
}

public class NYStylePizza : PizzaStore
{
    public override PizzaVariety? CreatePizza(string pizzaType)
    {
        return pizzaType switch
        {
            "Pepperoni" => new NYStylePepperoniPizza(),
            "Veggie" => new NYStyleVeggiePizza(),
            "Cheese" => new NYStyleCheesePizza(),
            _ => null
        };
    }
}

public class Zone
{
    protected string displayName { get; set; }
    protected int offset { get; set; }

    public string GetDisplayName()
    {
        return displayName;
    }
    public double GetOffset()
    {
        return offset;
    }
}

public class ZoneUSEastern : Zone
{
    public ZoneUSEastern()
    {
        displayName = "Eastern Zone";
        offset = -5;
    }
}

public class ZoneUSCentral : Zone
{
    public ZoneUSCentral()
    {
        displayName = "Central Zone";
        offset = -6;
    }
}

public class ZoneUSMountain : Zone
{
    public ZoneUSMountain()
    {
        displayName = "Mountain Zone";
        offset = -7;
    }
}

public class ZoneUSPacific : Zone
{
    public ZoneUSPacific()
    {
        displayName = "Pacific Zone";
        offset = -8;
    }
}

public class ZoneFactory
{
    public static Zone? CreateZone(string zoneId)
    {
        return zoneId switch
        {
            "Eastern" => new ZoneUSEastern(),
            "Cental" => new ZoneUSCentral(),
            "Mountain" => new ZoneUSMountain(),
            "Pacific" => new ZoneUSPacific(),
            _ => null
        };
    }
}

public abstract class Calendar
{
    public Zone? zone { get; set; }
    public void Print()
    {
        Console.WriteLine(zone?.GetDisplayName());
    }
    public abstract void CreateCalendar();
}

public class PacificCalendar : Calendar
{
    public override void CreateCalendar()
    {
        zone = ZoneFactory.CreateZone("Pacific");
    }
}

public class FactoryPattern
{
    public static void Run()
    {
        var calendar = new PacificCalendar();
        if (calendar == null)
        {
            return;
        }
        calendar.CreateCalendar();
        calendar.Print();
    }
}