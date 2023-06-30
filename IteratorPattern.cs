namespace ConsolePractice;

public interface IMenu
{
    public IIterator<string> CreateIterator();
}

public interface IIterator<T>
{
    public bool HasNext();
    public T Next();
}

public class PancakeHouseIterator : IIterator<string>
{
    private readonly string[] menu;
    private int position;
    
    public PancakeHouseIterator(string[] menu)
    {
        this.menu = menu;
        position = 0;
    }
    
    public bool HasNext()
    {
        return position < menu.Length;
    }
    public string Next()
    {
        return menu[position++];
    }
}

public class DinnerIterator : IIterator<string>
{
    private readonly List<string> menu;
    private int position;

    public DinnerIterator(List<string> menu)
    {
        this.menu = menu;
        position = 0;
    }

    public bool HasNext()
    {
        return position < menu.Count;
    }
    public string Next()
    {
        return menu[position++];
    }
}

public class PancakeHouseMenu : IMenu
{
    private readonly string[] menuItems;
    
    public PancakeHouseMenu()
    {
        menuItems = new string[5] 
        {
            "Buttermilk Pancakes",
            "Keto Pancakes",
            "Santa Hat Pancakes",
            "Instant Pot Giant Pancake",
            "Buckwheat Pancake"
        };
    }
    
    public IIterator<string> CreateIterator()
    {
        return new PancakeHouseIterator(menuItems);
    }
}

public class DinnerMenu : IMenu
{
    private readonly List<string> menuItems;

    public DinnerMenu()
    {
        menuItems = new List<string>
        {
            "Aloo Gobi",
            "Paneer Tikka Masala",
            "Palak Rice",
            "Garlic Naan",
            "Raita"
        };
    }

    public IIterator<string> CreateIterator()
    {
        return new DinnerIterator(menuItems);
    }
}

public class IteratorPattern
{
    public static void Run()
    {
        IMenu menu = new PancakeHouseMenu();
        PrintMenu(menu.CreateIterator());
        Console.WriteLine("\n");
        menu = new DinnerMenu();
        PrintMenu(menu.CreateIterator());
    }

    private static void PrintMenu(IIterator<string> menuIterator)
    {
        while (menuIterator.HasNext())
        {
            string nextItem = menuIterator.Next();
            Console.WriteLine("{0}", nextItem);
        }
    }
}