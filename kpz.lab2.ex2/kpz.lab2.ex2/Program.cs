using System;

abstract class Device
{
    public abstract void GetInfo();
}

class Laptop : Device
{
    private string brand;
    public Laptop(string brand) => this.brand = brand;

    public override void GetInfo()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine($"Ноутбук бренду {brand}");
    }
}

class Netbook : Device
{
    private string brand;
    public Netbook(string brand) => this.brand = brand;

    public override void GetInfo()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine($"Нетбук бренду {brand}");
    }
}

class EBook : Device
{
    private string brand;
    public EBook(string brand) => this.brand = brand;

    public override void GetInfo()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine($"Електронна книга бренду {brand}");
    }
}

class Smartphone : Device
{
    private string brand;
    public Smartphone(string brand) => this.brand = brand;

    public override void GetInfo()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine($"Смартфон бренду {brand}");
    }
}

abstract class DeviceFactory
{
    public abstract Laptop CreateLaptop();
    public abstract Netbook CreateNetbook();
    public abstract EBook CreateEBook();
    public abstract Smartphone CreateSmartphone();
}

class IProneFactory : DeviceFactory
{
    private string brand = "IProne";

    public override Laptop CreateLaptop() => new Laptop(brand);
    public override Netbook CreateNetbook() => new Netbook(brand);
    public override EBook CreateEBook() => new EBook(brand);
    public override Smartphone CreateSmartphone() => new Smartphone(brand);
}

class KiaomiFactory : DeviceFactory
{
    private string brand = "Kiaomi";

    public override Laptop CreateLaptop() => new Laptop(brand);
    public override Netbook CreateNetbook() => new Netbook(brand);
    public override EBook CreateEBook() => new EBook(brand);
    public override Smartphone CreateSmartphone() => new Smartphone(brand);
}

class BalaxyFactory : DeviceFactory
{
    private string brand = "Balaxy";

    public override Laptop CreateLaptop() => new Laptop(brand);
    public override Netbook CreateNetbook() => new Netbook(brand);
    public override EBook CreateEBook() => new EBook(brand);
    public override Smartphone CreateSmartphone() => new Smartphone(brand);
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        DeviceFactory iprone = new IProneFactory();
        DeviceFactory kiaomi = new KiaomiFactory();
        DeviceFactory balaxy = new BalaxyFactory();

        Console.WriteLine("Пристрої IProne:");
        iprone.CreateLaptop().GetInfo();
        iprone.CreateNetbook().GetInfo();
        iprone.CreateEBook().GetInfo();
        iprone.CreateSmartphone().GetInfo();

        Console.WriteLine("\nПристрої Kiaomi:");
        kiaomi.CreateLaptop().GetInfo();
        kiaomi.CreateNetbook().GetInfo();
        kiaomi.CreateEBook().GetInfo();
        kiaomi.CreateSmartphone().GetInfo();

        Console.WriteLine("\nПристрої Balaxy:");
        balaxy.CreateLaptop().GetInfo();
        balaxy.CreateNetbook().GetInfo();
        balaxy.CreateEBook().GetInfo();
        balaxy.CreateSmartphone().GetInfo();
    }
}

