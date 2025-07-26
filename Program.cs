using System;
using System.Collections.Generic;

// Abstraction: Abstract class defining the blueprint for animals
public abstract class Animal
{
    // Encapsulation: Private fields with public properties
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
            // Encapsulation: Ensuring age cannot be negative
            if (value < 0)
                throw new ArgumentException("La edad no puede ser negativa");
            _edad = value;
        }
    }

    // Constructor to enforce initialization
    protected Animal(string nombre, int edad)
    {
        Nombre = nombre;
        Edad = edad;
    }

    // Abstract method for polymorphism
    public abstract void EmitirSonido();
}

// Inheritance: Perro inherits from Animal
public class Perro : Animal
{
    public Perro(string nombre, int edad) : base(nombre, edad)
    {
    }

    // Polymorphism: Override EmitirSonido for Perro
    public override void EmitirSonido()
    {
        Console.WriteLine($"{Nombre} dice: ¡Guau!");
    }
}

// Inheritance: Gato inherits from Animal
public class Gato : Animal
{
    public Gato(string nombre, int edad) : base(nombre, edad)
    {
    }

    // Polymorphism: Override EmitirSonido for Gato
    public override void EmitirSonido()
    {
        Console.WriteLine($"{Nombre} dice: ¡Miau!");
    }
}

// Class to manage the animal shelter
public class Refugio
{
    // Encapsulation: Private list to store animals
    private List<Animal> animales;

    public Refugio()
    {
        animales = new List<Animal>();
    }

    // Method to add animals to the shelter
    public void AgregarAnimal(Animal animal)
    {
        animales.Add(animal);
        Console.WriteLine($"Animal {animal.Nombre} agregado al refugio");
    }

    // Method to display all animals and their sounds
    // Polymorphism: Calls different EmitirSonido implementations
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

// Main program to test the system
class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create shelter
            Refugio refugio = new Refugio();

            // Create animals
            Animal perro1 = new Perro("Max", 3);
            Animal gato1 = new Gato("Luna", 2);

            // Add animals to shelter
            refugio.AgregarAnimal(perro1);
            refugio.AgregarAnimal(gato1);

            // Display all animals
            refugio.MostrarTodos();

            // Test null name (will throw exception)
            // Animal perro2 = new Perro(null, 1);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}