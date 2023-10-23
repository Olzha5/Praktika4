using System;
using System.Collections.Generic;

abstract class Animal
{
    public string Name { get; set; }

    public abstract string TypeOfFood();
}

class Carnivore : Animal
{
    public override string TypeOfFood()
    {
        return "Ìÿñî";
    }
}

class Omnivore : Animal
{
    public override string TypeOfFood()
    {
        return "Ìÿñî è ðàñòåíèÿ";
    }
}

class Herbivore : Animal
{
    public override string TypeOfFood()
    {
        return "Ðàñòåíèÿ";
    }
}

class Program
{
    static void Main()
    {
        List<Animal> animals = new List<Animal>();
        animals.Add(new Carnivore { Name = "Ëåâ" });
        animals.Add(new Omnivore { Name = "×åëîâåê" });
        animals.Add(new Herbivore { Name = "Êðîëèê" });
        animals.Add(new Herbivore { Name = "Êîàëà" });
        animals.Add(new Carnivore { Name = "Òèãð" });

        animals.Sort((a1, a2) =>
        {
            int foodComparison = String.Compare(a2.TypeOfFood(), a1.TypeOfFood());
            return foodComparison != 0 ? foodComparison : String.Compare(a1.Name, a2.Name);
        });

        foreach (var animal in animals)
        {
            Console.WriteLine($"Èìÿ: {animal.Name}, Òèï: {animal.GetType().Name}, Ïèùà: {animal.TypeOfFood()}");
        }
    }
}