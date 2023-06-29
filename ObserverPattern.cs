namespace ConsolePractice;

public interface Observer
{
    Guid observerGuid { get; }
    void update(int update);
}

public interface Subject
{
    void registerObserver(Observer o);
    void removeObserver(Observer o);
    void notifyObservers();
}

public class SimpleSubject : Subject
{
    private List<Observer> observers;
    private int value = 0;
    public SimpleSubject()
    {
        observers = new List<Observer>();
    }
    public void registerObserver(Observer o)
    {
        observers.Add(o);
        Console.WriteLine("Observer {0} Added", o.observerGuid);
    }
    public void removeObserver(Observer o)
    {
        observers.Remove(o);
        Console.WriteLine("Observer {0} Removed", o.observerGuid);
    }
    public void notifyObservers()
    {
        observers.ForEach(observer => observer.update(value));
    }
    public void setValue(int value)
    {
        this.value = value;
        Console.WriteLine("New Value Set : {0}", value);
        notifyObservers();
    }
}

public class SimpleObserver : Observer
{
    private readonly Guid _observerGuid;
    private int value;
    private Subject simpleSubject;
    public Guid observerGuid
    {
        get => _observerGuid;
    }

    public SimpleObserver(Subject simpleSubject)
    {
        value = 0;
        _observerGuid = Guid.NewGuid();
        this.simpleSubject = simpleSubject;
        simpleSubject.registerObserver(this);
    }
    public void update(int value)
    {
        this.value = value;
        display();
    }
    public void display()
    {
        Console.WriteLine("Observer {0} Value : {1}", observerGuid, value);
    }
}

public class WeatherInfo
{
    internal float temprature { get; set; }
    internal long windSpeed { get; set; }
    internal float pressure { get; set; }

    public override string ToString()
    {
        return String.Format("Temprature: {0}, Wind Speed: {1}, Pressure: {2}", temprature, windSpeed, pressure);
    }
}

public interface WeatherObserver
{
    Guid observerGuid { get; }
    void update(WeatherInfo weatherInfo);
}

public interface WeatherSubject
{
    void registerObserver(WeatherObserver o);
    void removeObserver(WeatherObserver o);
    void notifyObservers();
}

public class WeatherStation : WeatherSubject
{
    private List<WeatherObserver> observers;
    private WeatherInfo weatherInfo;
    public WeatherStation()
    {
        weatherInfo = new WeatherInfo();
        observers = new List<WeatherObserver>();
    }
    public void registerObserver(WeatherObserver o)
    {
        observers.Add(o);
        Console.WriteLine("Observer {0} Added", o.observerGuid);
    }
    public void removeObserver(WeatherObserver o)
    {
        observers.Remove(o);
        Console.WriteLine("Observer {0} Removed", o.observerGuid);
    }
    public void notifyObservers()
    {
        observers.ForEach(observer => observer.update(weatherInfo));
    }
    public void setValue(WeatherInfo weatherInfo)
    {
        this.weatherInfo = weatherInfo;
        Console.WriteLine("New Value Set : {0}", weatherInfo.ToString());
        notifyObservers();
    }
}

public class UserInterface : WeatherObserver
{
    private readonly Guid _observerGuid;
    private WeatherInfo value;
    private WeatherSubject simpleSubject;
    public Guid observerGuid
    {
        get => _observerGuid;
    }

    public UserInterface(WeatherSubject simpleSubject)
    {
        value = new WeatherInfo();
        _observerGuid = Guid.NewGuid();
        this.simpleSubject = simpleSubject;
        simpleSubject.registerObserver(this);
    }
    public void update(WeatherInfo value)
    {
        this.value = value;
        display();
    }
    public void display()
    {
        Console.WriteLine("Observer {0} Value : {1}", observerGuid, value.ToString());
    }
}

public class Logger : WeatherObserver
{
    private readonly Guid _observerGuid;
    private WeatherInfo value;
    private WeatherSubject simpleSubject;
    public Guid observerGuid
    {
        get => _observerGuid;
    }

    public Logger(WeatherSubject simpleSubject)
    {
        value = new WeatherInfo();
        _observerGuid = Guid.NewGuid();
        this.simpleSubject = simpleSubject;
        simpleSubject.registerObserver(this);
    }
    public void update(WeatherInfo value)
    {
        this.value = value;
        log();
    }
    public void log()
    {
        Console.WriteLine("Observer {0} Value : {1}", observerGuid, value.ToString());
    }
}

public class AlterSystem : WeatherObserver
{
    private readonly Guid _observerGuid;
    private WeatherInfo value;
    private WeatherSubject simpleSubject;
    public Guid observerGuid
    {
        get => _observerGuid;
    }

    public AlterSystem(WeatherSubject simpleSubject)
    {
        value = new WeatherInfo();
        _observerGuid = Guid.NewGuid();
        this.simpleSubject = simpleSubject;
        simpleSubject.registerObserver(this);
    }
    public void update(WeatherInfo value)
    {
        this.value = value;
        alert();
    }
    public void alert()
    {
        Console.WriteLine("Observer {0} Value : {1}", observerGuid, value.ToString());
    }
}

public class ObserverPattern
{
    public static void Run()
    {
        var exampleSubject = new WeatherStation();
        var userInterfaceObserver = new UserInterface(exampleSubject);
        var loggerObserver = new Logger(exampleSubject);
        var alertObserver = new AlterSystem(exampleSubject);
        exampleSubject.setValue(new WeatherInfo
        {
            temprature = 12,
            windSpeed = 14,
            pressure = 23
        });
    }
}