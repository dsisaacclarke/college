using System;
using System.Collections.Generic;

namespace SimpleZoo
{
    class Program
    {
        static void Main(string[] args)
        {
            Zoo myZoo = new Zoo();

            Animal animal1 = new Animal();
            animal1.Id = 1;
            animal1.Name = "Саша";
            animal1.Species = "Жираф";
            animal1.Age = 7;
            animal1.IsFed = true;

            Animal animal2 = new Animal();
            animal2.Id = 2;
            animal2.Name = "Паша";
            animal2.Species = "Зебра";
            animal2.Age = 12;
            animal2.IsFed = false;

            myZoo.AddAnimal(animal1);
            myZoo.AddAnimal(animal2);

            Console.WriteLine("Список животных в зоопарке:");
            myZoo.ListAllAnimals();

            Console.WriteLine("Кормим животное с ID 2...");
            myZoo.FeedAnimal(2);

            Console.WriteLine("Список животных после кормления:");
            myZoo.ListAllAnimals();

            Console.WriteLine("Получаем животное с ID 1...");
            Animal animalFromZoo = myZoo.GetAnimalById(1);

            if (animalFromZoo != null)
            {
                Console.WriteLine("Имя животного: " + animalFromZoo.Name);
                Console.WriteLine("Возраст животного: " + animalFromZoo.Age);
            }

            Console.WriteLine("Изменяем данные животного с ID 1...");
            Animal updatedAnimal = new Animal();
            updatedAnimal.Id = 1;
            updatedAnimal.Name = "Александр Первый";
            updatedAnimal.Species = "Королевский жираф";
            updatedAnimal.Age = 8;
            updatedAnimal.IsFed = true;

            myZoo.UpdateAnimal(1, updatedAnimal);

            Console.WriteLine("Список животных после изменения:");
            myZoo.ListAllAnimals();

            Console.ReadKey();
        }
    }

    class Animal
    {
        public int Id;
        public string Name;
        public string Species;
        public int Age;
        public bool IsFed;
    }

    class Zoo
    {
        public List<Animal> Animals = new List<Animal>();

        public void AddAnimal(Animal animal)
        {
            Animals.Add(animal);
            Console.WriteLine("Животное " + animal.Name + " добавлено в зоопарк.");
        }

        public void FeedAnimal(int animalId)
        {
            bool found = false;
            foreach (Animal animal in Animals)
            {
                if (animal.Id == animalId)
                {
                    animal.IsFed = true;
                    Console.WriteLine("Животное " + animal.Name + " накормлено.");
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Животное с ID " + animalId + " не найдено.");
            }
        }

        public void UpdateAnimal(int animalId, Animal updatedAnimal)
        {
            bool found = false;
            foreach (Animal animal in Animals)
            {
                if (animal.Id == animalId)
                {
                    animal.Name = updatedAnimal.Name;
                    animal.Species = updatedAnimal.Species;
                    animal.Age = updatedAnimal.Age;
                    animal.IsFed = updatedAnimal.IsFed;
                    Console.WriteLine("Информация о животном " + animal.Name + " обновлена.");
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Животное с ID " + animalId + " не найдено.");
            }
        }

        public void ListAllAnimals()
        {
            if (Animals.Count == 0)
            {
                Console.WriteLine("В зоопарке пока нет животных.");
                return;
            }

            foreach (Animal animal in Animals)
            {
                Console.WriteLine("ID: " + animal.Id);
                Console.WriteLine("Имя: " + animal.Name);
                Console.WriteLine("Вид: " + animal.Species);
                Console.WriteLine("Возраст: " + animal.Age);
                Console.WriteLine("Сытость: " + animal.IsFed);
                Console.WriteLine("---");
            }
        }

        public Animal GetAnimalById(int animalId)
        {
            foreach (Animal animal in Animals)
            {
                if (animal.Id == animalId)
                {
                    return animal;
                }
            }

            Console.WriteLine("Животное с ID " + animalId + " не найдено.");
            return null;
        }
    }
}
