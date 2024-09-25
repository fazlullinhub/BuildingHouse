using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//создание интерфейса для части дома
public interface IPart
{
    string Name { get; }
    bool IsConstructed { get; set; }
}
//создание интерфейса для работника
public interface IWorker
{
    void Work(IPart part);
}

//создание класса для фундамента
public class Basement : IPart
{
    public string Name => "Basement";
    public bool IsConstructed { get; set; } = false;
}
//создание класса для стен
public class Walls : IPart
{
    public string Name => "Walls";
    public bool IsConstructed { get; set; } = false;
}
//создание класса для дверей
public class Doors : IPart
{
    public string Name => "Doors";
    public bool IsConstructed { get; set; } = false;
}
//создание класса для окна
public class Window : IPart
{
    public string Name => "Window";
    public bool IsConstructed { get; set; } = false;
}
//создание класса для крыши
public class Roof : IPart
{
    public string Name => "Roof";
    public bool IsConstructed { get; set; } = false;
}
//создание класса для работника
public class Worker : IWorker
{
    public void Work(IPart part)
    {
        if (!part.IsConstructed)
        {
            part.IsConstructed = true;
            Console.WriteLine($"{part.Name} constructed.");
        }
        else
        {
            Console.WriteLine($"{part.Name} is already constructed.");
        }
    }
}
//создание класса для бригадира
public class TeamLeader : IWorker
{
    public void Work(IPart part)
    {
        Console.WriteLine($"Counting down: {part.Name} - Status: {(part.IsConstructed ? "Constructed" : "Not constructed")}");
    }
}
//создание класса для команды строителей
public class Team
{
    private List<IWorker> workers = new List<IWorker>();
    private Basement basement;
    private Walls walls;
    private Doors doors;
    private List<Window> windows;
    private Roof roof;

    public Team()
    {
        this.basement = new Basement();
        this.walls = new Walls();
        this.doors = new Doors();
        this.windows = new List<Window> { new(), new Window(), new Window(), new Window() };
        this.roof = new Roof();
    }
    public void AddWorker(IWorker worker)
    {
        workers.Add(worker);
    }

    public void BuildHouse()
    {
        Console.WriteLine("Let's start building the house...\n");

        foreach (var worker in workers)
        {
            // Поэтапное строительство
            worker.Work(basement);
            worker.Work(walls);
            worker.Work(doors);

            foreach (var window in windows)
            {
                worker.Work(window);
            }

            worker.Work(roof);
        }

        Console.WriteLine("\nBuilding the house is finished!");
        PrintHouse();
    }

    private void PrintHouse()
    {
        Console.WriteLine(@"           
          /\  
         /  \ 
        /____\ 
       |  __  |
       ||    || 
       ||____|| 
       |______|");
    }
}

// Основной класс программы
class Program
{
    static void Main(string[] args)
    {
        Team team = new Team();

        // Создаем рабочих и бригадира
        team.AddWorker(new Worker());
        team.AddWorker(new TeamLeader());

        // Строительство дома начинается
        team.BuildHouse();

        Console.ReadLine();
    }
}




