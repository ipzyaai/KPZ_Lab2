using System;
using System.Collections.Generic;

class Virus
{
    private string name;
    private double weight;
    private int age;
    private string species;
    private List<Virus> children;

    public Virus(string name, double weight, int age, string species)
    {
        this.name = name;
        this.weight = weight;
        this.age = age;
        this.species = species;
        this.children = new List<Virus>();
    }

    public void AddChild(Virus v)
    {
        children.Add(v);
    }

    public Virus Clone()
    {
        Virus clone = new Virus(name, weight, age, species);

        foreach (Virus child in children)
        {
            clone.AddChild(child.Clone());
        }

        return clone;
    }

    public void Print(int level = 0)
    {
        Console.WriteLine($"{new string('-', level * 2)} {name} (age: {age}, weight: {weight}, species: {species})");
        foreach (Virus child in children)
        {
            child.Print(level + 1);
        }
    }
}

class VirusSimulation
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Virus grandparent = new Virus("Alpha", 1.2, 5, "Corona");
        Virus parent1 = new Virus("Beta", 1.0, 3, "Corona");
        Virus parent2 = new Virus("Gamma", 0.9, 3, "Corona");

        Virus child1 = new Virus("Delta", 0.5, 1, "Corona");
        Virus child2 = new Virus("Epsilon", 0.4, 1, "Corona");

        parent1.AddChild(child1);
        parent2.AddChild(child2);

        grandparent.AddChild(parent1);
        grandparent.AddChild(parent2);

        Console.WriteLine("Оригінал:");
        grandparent.Print();

        Virus cloned = grandparent.Clone();
        Console.WriteLine("\nКлон:");
        cloned.Print();
    }
}

