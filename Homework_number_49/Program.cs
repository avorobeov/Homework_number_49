using System;
using System.Collections.Generic;

namespace Homework_number_49
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();

            zoo.Work();
        }
    }

    class Animal
    {
        public Animal(string name, string gender, string sound)
        {
            Name = name;
            Gender = gender;
            Sound = sound;
        }

        public string Name { get; private set; }
        public string Gender { get; private set; }
        public string Sound { get; private set; }
    }

    class Aviary
    {
        private List<Animal> _animals = new List<Animal>();

        public string Title;

        public Aviary(string title)
        {
            Title = title;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Название вольера: [{Title}] Количество животных которое в нём обитает: {_animals.Count}");

            for (int i = 0; i < _animals.Count; i++)
            {
                Console.WriteLine($"{_animals[i].Name} - {_animals[i].Gender} - {_animals[i].Sound}");
            }
        }

        public void TryAddAnimal(string name, string gender, string sound)
        {
            if (string.IsNullOrEmpty(name) != true && string.IsNullOrEmpty(gender) != true&& string.IsNullOrEmpty(sound) != true)
            {
                _animals.Add(new Animal(name, gender, sound));
            }
        }
    }

    class Zoo
    {
        private List<Aviary> _aviaries = new List<Aviary>();

        public Zoo()
        {
            FillZoo();
        }

        public void Work()
        {
            const string CommandSelectAviary = "1";
            const string CommandExit = "2";

            bool isExit = false;
            string userInput;

            while (isExit == false)
            {
                ShowAviaries();

                Console.WriteLine($"Для того что бы подойти к вольеру нажмите: {CommandSelectAviary}\n" +
                                  $"Для того что бы закрыть приложение нажмите {CommandExit}\n");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandSelectAviary:
                        SelectAviary();
                        break;

                    case CommandExit:
                        isExit = true;
                        break;

                    default:
                        Console.WriteLine("Такой команды нет в наличии!");
                        break;
                }

                Console.WriteLine("Для продолжения ведите любую клавишу...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void ShowAviaries()
        {
            Console.WriteLine("Список всех вольеров");

            for (int i = 0; i < _aviaries.Count; i++)
            {
                Console.WriteLine($"{i}) {_aviaries[i].Title}");
            }
        }

        private void SelectAviary()
        {
            int index = GetNumber("Укажите вольер к которому хотите подойти:");

            if (index >= 0 && index < _aviaries.Count)
            {
                _aviaries[index].ShowInfo();
            }
        }

        private int GetNumber(string message)
        {
            bool isNumber = false;
            string userInput;
            int number = 0;

            while (isNumber == false)
            {
                Console.WriteLine(message, ConsoleColor.Blue);
                userInput = Console.ReadLine();

                if (int.TryParse(userInput, out number))
                {
                    isNumber = true;
                }
                else
                {
                    Console.WriteLine("Не верный формат вода", ConsoleColor.Red);
                }
            }

            return number;
        }

        private void FillZoo()
        {
            CreateAviary("Льви");
            _aviaries[0].TryAddAnimal("Лев", "Женский", "Рычание");
            _aviaries[0].TryAddAnimal("Лев", "Женский", "Рычание");
            _aviaries[0].TryAddAnimal("Лев", "Женский", "Рычание");
            _aviaries[0].TryAddAnimal("Лев", "Мужской", "Рычание");

            CreateAviary("Лошади");
            _aviaries[1].TryAddAnimal("Лошадь", "Женский", "Ржание");
            _aviaries[1].TryAddAnimal("Лошадь", "Женский", "Ржание");
            _aviaries[1].TryAddAnimal("Лошадь", "Женский", "Ржание");
            _aviaries[1].TryAddAnimal("Лошадь", "Мужской", "Ржание");

            CreateAviary("Вовки");
            _aviaries[2].TryAddAnimal("Волк", "Женский", "Вой");
            _aviaries[2].TryAddAnimal("Волк", "Мужской", "Вой");
            _aviaries[2].TryAddAnimal("Волк", "Мужской", "Вой");
            _aviaries[2].TryAddAnimal("Волк", "Мужской", "Вой");

            CreateAviary("Козы");
            _aviaries[3].TryAddAnimal("Коза", "Женский", "блеет");
            _aviaries[3].TryAddAnimal("Коза", "Мужской", "блеет");
            _aviaries[3].TryAddAnimal("Коза", "Мужской", "блеет");
            _aviaries[3].TryAddAnimal("Коза", "Мужской", "блеет");
        }

        private void CreateAviary(string title)
        {
            _aviaries.Add(new Aviary(title));
        }
    }
}
