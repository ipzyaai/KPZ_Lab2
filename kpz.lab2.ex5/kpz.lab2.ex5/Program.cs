using System;
using System.Collections.Generic;

public interface ICharacterBuilder
{
    ICharacterBuilder SetHeight(int height);
    ICharacterBuilder SetBodyType(string bodyType);
    ICharacterBuilder SetHairColor(string hairColor);
    ICharacterBuilder SetEyeColor(string eyeColor);
    ICharacterBuilder SetClothes(string clothes);
    ICharacterBuilder SetInventory(List<string> inventory);
    ICharacterBuilder AddGoodDeed(string deed);
    ICharacterBuilder AddEvilDeed(string deed);
    GameCharacter Build();
}

public class GameCharacter
{
    public int Height { get; set; }
    public string BodyType { get; set; } = string.Empty;
    public string HairColor { get; set; } = string.Empty;
    public string EyeColor { get; set; } = string.Empty;
    public string Clothes { get; set; } = string.Empty;
    public List<string> Inventory { get; set; } = new();
    public List<string> GoodDeeds { get; set; } = new();
    public List<string> EvilDeeds { get; set; } = new();

    public override string ToString()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        return $"Ріст: {Height}, Статура: {BodyType}, Колір волосся: {HairColor}, Колір очей: {EyeColor}, Одяг: {Clothes},\n" +
               $"Інвентар: {string.Join(", ", Inventory)},\n" +
               $"Добрі справи: {string.Join(", ", GoodDeeds)},\n" +
               $"Погані справи : {string.Join(", ", EvilDeeds)}\n";
    }
}

public abstract class BaseCharacterBuilder : ICharacterBuilder
{
    protected GameCharacter character = new();

    public ICharacterBuilder SetHeight(int height) { character.Height = height; return this; }
    public ICharacterBuilder SetBodyType(string bodyType) { character.BodyType = bodyType; return this; }
    public ICharacterBuilder SetHairColor(string hairColor) { character.HairColor = hairColor; return this; }
    public ICharacterBuilder SetEyeColor(string eyeColor) { character.EyeColor = eyeColor; return this; }
    public ICharacterBuilder SetClothes(string clothes) { character.Clothes = clothes; return this; }
    public ICharacterBuilder SetInventory(List<string> inventory) { character.Inventory = inventory; return this; }

    public abstract ICharacterBuilder AddGoodDeed(string deed);
    public abstract ICharacterBuilder AddEvilDeed(string deed);

    public GameCharacter Build() => character;
}

public class HeroBuilder : BaseCharacterBuilder
{
    public override ICharacterBuilder AddGoodDeed(string deed)
    {
        character.GoodDeeds.Add(deed);
        return this;
    }

    public override ICharacterBuilder AddEvilDeed(string deed)
    {
        Console.WriteLine(" Герой не може чинити злі справи!");
        return this;
    }
}

public class EnemyBuilder : BaseCharacterBuilder
{
    public override ICharacterBuilder AddEvilDeed(string deed)
    {
        character.EvilDeeds.Add(deed);
        return this;
    }

    public override ICharacterBuilder AddGoodDeed(string deed)
    {
        Console.WriteLine(" Ворог не здатен на добрі вчинки!");
        return this;
    }
}

public class Director
{
    public void ConstructHero(HeroBuilder builder)
    {
        builder
            .SetHeight(180)
            .SetBodyType("Стрункий")
            .SetHairColor("Блондин")
            .SetEyeColor("Блакитні")
            .SetClothes("Броня")
            .SetInventory(new List<string> { "Меч", "Щит" })
            .AddGoodDeed("Врятував кота");
    }

    public void ConstructEnemy(EnemyBuilder builder)
    {
        builder
            .SetHeight(200)
            .SetBodyType("Мускулистий")
            .SetHairColor("Брюнет")
            .SetEyeColor("Червоні")
            .SetClothes("Темний плащ")
            .SetInventory(new List<string> { "Отрута", "Кинджал" })
            .AddEvilDeed("Спалив місто")
            .AddEvilDeed("Вкрав стародавній артефакт");
    }
}

class MainClass
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Director director = new();

        HeroBuilder heroBuilder = new();
        director.ConstructHero(heroBuilder);
        GameCharacter hero = heroBuilder.Build();

        EnemyBuilder enemyBuilder = new();
        director.ConstructEnemy(enemyBuilder);
        GameCharacter enemy = enemyBuilder.Build();

        Console.WriteLine("Герой:");
        Console.WriteLine(hero);
        Console.WriteLine("Ворог:");
        Console.WriteLine(enemy);

        heroBuilder.AddEvilDeed("Вкрав торт");
        enemyBuilder.AddGoodDeed("Подарував квіти");
    }
}
