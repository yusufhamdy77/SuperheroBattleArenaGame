using System;
using System.Collections.Generic;

abstract class Hero
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Power { get; set; }

    public Hero(string name, int health, int power)
    {
        Name = name;
        Health = health;
        Power = power;
    }

    public void ShowInfo()
    {
        Console.WriteLine(Name + " - HP: " + Health);
    }

    public abstract void Attack(Hero enemy);

    public void Heal()
    {
        Health += 20;
    }

    public void Heal(int amount)
    {
        Health += amount;
    }
}

class Warrior : Hero
{
    public Warrior(string n, int h, int p) : base(n, h, p) { }

    public override void Attack(Hero enemy)
    {
        enemy.Health -= Power;
        Console.WriteLine(Name + " hits with sword");
    }
}

class Mage : Hero
{
    public Mage(string n, int h, int p) : base(n, h, p) { }

    public override void Attack(Hero enemy)
    {
        enemy.Health -= Power;
        Console.WriteLine(Name + " casts magic");
    }
}

class Archer : Hero
{
    public Archer(string n, int h, int p) : base(n, h, p) { }

    public override void Attack(Hero enemy)
    {
        enemy.Health -= Power;
        Console.WriteLine(Name + " shoots arrow");
    }
}

class Program
{
    static void Main()
    {
        Warrior w = new Warrior("Warrior", 100, 20);
        Mage m = new Mage("Mage", 80, 25);
        Archer a = new Archer("Archer", 90, 15);

        List<Hero> heroes = new List<Hero> { w, m, a };

        foreach (Hero h in heroes)
        {
            h.ShowInfo();
        }

        w.Attack(m);

        if (m.Health > 0)
            Console.WriteLine("Mage still alive");
        else
            Console.WriteLine("Mage defeated");

        m.Heal();
        Console.WriteLine("Mage HP: " + m.Health);
    }
}
