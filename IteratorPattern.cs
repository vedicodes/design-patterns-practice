using System;
using System.Collections;
using System.Collections.Generic;

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

public class DaysOfWeek : IEnumerable
{
    private readonly string[] daysOfWeek;

    public DaysOfWeek()
    {
        daysOfWeek = new string[]
        {
            "Mon",
            "Tue",
            "Wed",
            "Thu",
            "Fri",
            "Sat",
            "Sun"
        };
    }

    public IEnumerator GetEnumerator()
    {
        return new DaysOfWeekIterator(daysOfWeek);
    }
}

public class DaysOfWeekIterator : IEnumerator
{
    private readonly string[] daysOfWeek;
    private int position;

    public DaysOfWeekIterator(string[] daysOfWeek)
    {
        this.daysOfWeek = daysOfWeek;
        position = -1;
    }

    public object Current
    {
        get
        {
            try
            {
                return daysOfWeek[position];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
    }

    public void Reset()
    {
        position = -1;
    }

    public bool MoveNext()
    {
        position++;
        return (position < daysOfWeek.Length);
    }
}

public class IteratorPattern
{
    public static void Run()
    {
        var daysOfWeek = new DaysOfWeek();

        foreach (var item in daysOfWeek)
        {
            Console.WriteLine("{0}", item);
        }
    }
    
    public static IEnumerable<int> GetNumbers(int startPosition, int endPosition)
    {
        for (var number = startPosition; number <= endPosition; number++)
        {
            if (number % 2 == 0) yield return number;
        }
    }

    private static void ShowMenus()
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