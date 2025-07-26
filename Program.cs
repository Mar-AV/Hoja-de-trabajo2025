using System;
using System.Collections.Generic;

public abstract class Animal
{
    private string _nombre;
    private int _edad;

    public required string Nombre
    {
        get => _nombre;
        set => _nombre = value ?? throw new ArgumentNullException(nameof(value), "El nombre no puede ser nulo");
    }

    public int Edad
    {
        get => _edad;
        set
        {
            if (value < 0)
                throw new ArgumentException("La edad no puede ser negativa");
            _edad = value;
        }
    }

    protected Animal(string nombre, int edad)
    {
        Nombre = nombre;
        Edad = edad;
    }

    public abstract void EmitirSonido();
}

public class Perro : Animal
{
    public Perro(string nombre, int edad) : base(nombre, edad)
    {
    }

    public override void EmitirSonido()
    {
        Console.WriteLine($"{Nombre} dice: ¡Guau!");
    }
}

public class Gato : Animal
{
    public Gato(string nombre, int edad) : base(nombre, edad)
    {
    }

    public override void EmitirSonido()
    {
        Console.WriteLine($"{Nombre} dice: ¡Miau!");
    }
}

public class Refugio
{
    private List<Animal> animales;

    public Refugio()
    {
        animales = new List<Animal>();
    }

    public void AgregarAnimal(Animal animal)
    {
        animales.Add(animal);
        Console.WriteLine($"Animal {animal.Nombre} agregado al refugio");
    }

    public void MostrarTodos()
    {
        Console.WriteLine("\nAnimales en el refugio:");
        foreach (Animal animal in animales)
        {
            Console.WriteLine($"Nombre: {animal.Nombre}, Edad: {animal.Edad}");
            animal.EmitirSonido();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Refugio refugio = new Refugio();

            Animal perro1 = new Perro("Max", 3);
            Animal gato1 = new Gato("Luna", 2);

            refugio.AgregarAnimal(perro1);
            refugio.AgregarAnimal(gato1);

            refugio.MostrarTodos();

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
