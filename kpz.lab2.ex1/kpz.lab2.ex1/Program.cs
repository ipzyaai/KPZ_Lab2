using System;
using System.Collections.Generic;

abstract class Subscription
{
    public float MonthlyFee { get; set; }
    public int MinPeriod { get; set; }
    public List<string> Channels { get; set; } = new List<string>();

    public abstract string GetDetails();
}

class DomesticSubscription : Subscription
{
    public DomesticSubscription()
    {
        MonthlyFee = 9.99f;
        MinPeriod = 1;
        Channels.AddRange(new[] { "Новини", "Спорт", "Фільми" });
    }

    public override string GetDetails()
    {
        return $"Домашня підписка: {MonthlyFee}$ / місяць, Мінімальний період: {MinPeriod} міс., Канали: {string.Join(", ", Channels)}";
    }
}

class EducationSubscription : Subscription
{
    public EducationSubscription()
    {
        MonthlyFee = 4.99f;
        MinPeriod = 6;
        Channels.AddRange(new[] { "Наука", "Документальні", "Історія" });
    }

    public override string GetDetails()
    {
        return $"Освітня підписка: {MonthlyFee}$ / місяць, Мінімальний період: {MinPeriod} міс., Канали: {string.Join(", ", Channels)}";
    }
}

class PremiumSubscription : Subscription
{
    public PremiumSubscription()
    {
        MonthlyFee = 19.99f;
        MinPeriod = 3;
        Channels.AddRange(new[] { "Усі канали", "Підтримка 4K", "Без реклами" });
    }

    public void PurchaseParkingPass()
    {
        Console.WriteLine("Преміум підписку активовано!");
    }

    public override string GetDetails()
    {
        return $"Преміум підписка: {MonthlyFee}$ / місяць, Мінімальний період: {MinPeriod} міс., Канали: {string.Join(", ", Channels)}";
    }
}

interface SubscriptionFactory
{
    Subscription CreateSubscription(string type);
}

class WebSite : SubscriptionFactory
{
    public Subscription CreateSubscription(string type)
    {
        Console.WriteLine("Створення підписки через вебсайт...");
        return Create(type);
    }

    private Subscription Create(string type)
    {
        return type switch
        {
            "domestic" => new DomesticSubscription(),
            "education" => new EducationSubscription(),
            "premium" => new PremiumSubscription(),
            _ => throw new ArgumentException("Невірний тип підписки")
        };
    }
}

class MobileApp : SubscriptionFactory
{
    public Subscription CreateSubscription(string type)
    {
        Console.WriteLine("Створення підписки через мобільний застосунок...");
        return Create(type);
    }

    private Subscription Create(string type)
    {
        return type switch
        {
            "domestic" => new DomesticSubscription(),
            "education" => new EducationSubscription(),
            "premium" => new PremiumSubscription(),
            _ => throw new ArgumentException("Невірний тип підписки")
        };
    }
}

class ManagerCall : SubscriptionFactory
{
    public Subscription CreateSubscription(string type)
    {
        Console.WriteLine("Створення підписки через дзвінок менеджера...");
        return Create(type);
    }

    private Subscription Create(string type)
    {
        return type switch
        {
            "domestic" => new DomesticSubscription(),
            "education" => new EducationSubscription(),
            "premium" => new PremiumSubscription(),
            _ => throw new ArgumentException("Невірний тип підписки")
        };
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        SubscriptionFactory website = new WebSite();
        Subscription domestic = website.CreateSubscription("domestic");
        Console.WriteLine(domestic.GetDetails());

        SubscriptionFactory app = new MobileApp();
        Subscription education = app.CreateSubscription("education");
        Console.WriteLine(education.GetDetails());

        SubscriptionFactory manager = new ManagerCall();
        Subscription premium = manager.CreateSubscription("premium");
        Console.WriteLine(premium.GetDetails());

        if (premium is PremiumSubscription premiumSub)
        {
            premiumSub.PurchaseParkingPass();
        }

        Console.WriteLine("\n=== Усі підписки успішно створено! ===");
    }
}

