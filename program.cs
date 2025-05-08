using System;

public abstract class Vehicle
{
    public string Model { get; set; }
    public int Speed { get; set; }
    public int MaxSpeed { get; set; }

    protected Vehicle(string model, int maxSpeed)
    {
        Model = model;
        MaxSpeed = maxSpeed;
        Speed = 0;
    }

    public abstract void Move();

    public virtual void Stop()
    {
        Console.WriteLine($"Транспортное средство {Model} остановилось.");
    }
}

public class Car : Vehicle
{
    public int PassengerSeats { get; set; }

    public Car(string model, int maxSpeed, int passengerSeats) : base(model, maxSpeed)
    {
        PassengerSeats = passengerSeats;
    }

    public override void Move()
    {
        Speed = Math.Min(Speed + 20, MaxSpeed);
        Console.WriteLine($"Автомобиль {Model} движется со скоростью {Speed} км/ч.");
    }

    public override void Stop()
    {
        Console.WriteLine($"Автомобиль {Model} неожиданно тормозит! Жжжжж!"); // допустим, что именно это "звук торможения" с условия задачи
        base.Stop();
    }
}

public class Truck : Vehicle
{
    public double CargoCapacity { get; set; }
    public double CurrentCargoWeight { get; set; }

    public Truck(string model, int maxSpeed, double cargoCapacity) : base(model, maxSpeed)
    {
        CargoCapacity = cargoCapacity;
        CurrentCargoWeight = 0;
    }

    public override void Move()
    {
        Speed = Math.Min(Speed + 10, MaxSpeed);
        double speedModifier = 1.0 - (CurrentCargoWeight / CargoCapacity);
        Speed = (int)(Speed * speedModifier);
        if (Speed < 0) Speed = 0;

        Console.WriteLine($"Грузовик {Model} движется со скоростью {Speed} км/ч. Текущий вес груза: {CurrentCargoWeight} кг.");
    }

    public void LoadCargo(double weight)
    {
        if (CurrentCargoWeight + weight <= CargoCapacity)
        {
            CurrentCargoWeight += weight;
            Console.WriteLine($"Загружено {weight} кг груза в грузовик {Model}.  Текущий вес: {CurrentCargoWeight} кг.");
        }
        else
        {
            Console.WriteLine($"Невозможно загрузить {weight} кг груза. Превышена грузоподъемность грузовика {Model}.");
        }
    }
}

public class Bicycle : Vehicle
{
    public bool HasBell { get; set; }

    public Bicycle(string model, int maxSpeed, bool hasBell) : base(model, maxSpeed)
    {
        HasBell = hasBell;
    }

    public override void Move()
    {
        Speed = Math.Min(Speed + 5, Math.Min(MaxSpeed, 30));
        Console.WriteLine($"Велосипед {Model} движется со скоростью {Speed} км/ч.");
    }

    public void RingBell()
    {
        if (HasBell)
        {
            Console.WriteLine($"Велосипед {Model} звонит в звонок!");
        }
        else
        {
            Console.WriteLine($"У велосипеда {Model} нет звонка.");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Создание автомобиля ---");
        Console.Write("Введите модель автомобиля: ");
        
        string carModel = Console.ReadLine();
        
        Console.Write("Введите максимальную скорость автомобиля (км/ч): ");
        
        int carMaxSpeed = int.Parse(Console.ReadLine());
        
        Console.Write("Введите количество пассажирских мест в автомобиле: ");
        
        int carPassengerSeats = int.Parse(Console.ReadLine());

        Car myCar = new Car(carModel, carMaxSpeed, carPassengerSeats);

        Console.WriteLine("\n--- Создание грузовика ---");
        Console.Write("Введите модель грузовика: ");
        
        string truckModel = Console.ReadLine();
        
        Console.Write("Введите максимальную скорость грузовика (км/ч): ");
        
        int truckMaxSpeed = int.Parse(Console.ReadLine());
        
        Console.Write("Введите грузоподъемность грузовика (кг): ");
        
        double truckCargoCapacity = double.Parse(Console.ReadLine());

        Truck myTruck = new Truck(truckModel, truckMaxSpeed, truckCargoCapacity);

        Console.WriteLine("\n--- Создание велосипеда ---");
        Console.Write("Введите модель велосипеда: ");
        
        string bicycleModel = Console.ReadLine();
        
        Console.Write("Введите максимальную скорость велосипеда (км/ч): ");
        
        int bicycleMaxSpeed = int.Parse(Console.ReadLine());
        
        Console.Write("Есть ли звонок у велосипеда (true/false): ");
        
        bool bicycleHasBell = bool.Parse(Console.ReadLine());

        Bicycle myBicycle = new Bicycle(bicycleModel, bicycleMaxSpeed, bicycleHasBell);

        Console.WriteLine("\n--- Демонстрация работы ---");
        Console.WriteLine("--- Автомобиль ---");
        
        myCar.Move();
        myCar.Move();
        myCar.Stop();

        Console.WriteLine("\n--- Грузовик ---");
        
        myTruck.Move();
        
        Console.Write("Введите вес груза для загрузки (кг): ");
        
        double cargoWeight = double.Parse(Console.ReadLine());
        
        myTruck.LoadCargo(cargoWeight);
        myTruck.Move();
        myTruck.Stop();

        Console.WriteLine("\n--- Велосипед ---");
        
        myBicycle.Move();
        myBicycle.Move();
        myBicycle.RingBell();
        myBicycle.Stop();

        Console.ReadKey();
    }
}
