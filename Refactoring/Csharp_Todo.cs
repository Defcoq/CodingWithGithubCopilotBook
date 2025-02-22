using System;
using System.Collections.Generic;

namespace TodoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Task> tasks = new List<Task>();

            bool runApp = true;

            while (runApp)
            {
                Console.WriteLine("1. Aggiungi attività");
                Console.WriteLine("2. Visualizza attività");
                Console.WriteLine("3. Aggiorna attività");
                Console.WriteLine("4. Rimuovi attività");
                Console.WriteLine("5. Esci");
                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    Console.WriteLine("Inserisci il titolo dell'attività:");
                    string title = Console.ReadLine();
                    Console.WriteLine("Inserisci la descrizione dell'attività:");
                    string description = Console.ReadLine();
                    Console.WriteLine("L'attività è completata? (sì/no):");
                    string isCompleted = Console.ReadLine();
                    Task t = new Task(title, description, isCompleted == "sì");
                    tasks.Add(t);
                }
                else if (choice == 2)
                {
                    foreach (Task t in tasks)
                    {
                        Console.WriteLine($"{t.Title} - {t.Description} - {(t.IsCompleted ? "Completata" : "Non completata")}");
                    }
                }
                else if (choice == 3)
                {
                    Console.WriteLine("Inserisci l'indice dell'attività da aggiornare:");
                    int index = Convert.ToInt32(Console.ReadLine()) - 1;
                    if (index >= 0 && index < tasks.Count)
                    {
                        Console.WriteLine("Inserisci il nuovo titolo:");
                        tasks[index].Title = Console.ReadLine();
                        Console.WriteLine("Inserisci la nuova descrizione:");
                        tasks[index].Description = Console.ReadLine();
                        Console.WriteLine("L'attività è completata? (sì/no):");
                        string isCompleted = Console.ReadLine();
                        tasks[index].IsCompleted = isCompleted == "sì";
                    }
                    else
                    {
                        Console.WriteLine("Attività non trovata!");
                    }
                }
                else if (choice == 4)
                {
                    Console.WriteLine("Inserisci l'indice dell'attività da rimuovere:");
                    int index = Convert.ToInt32(Console.ReadLine()) - 1;
                    if (index >= 0 && index < tasks.Count)
                    {
                        tasks.RemoveAt(index);
                    }
                    else
                    {
                        Console.WriteLine("Attività non trovata!");
                    }
                }
                else if (choice == 5)
                {
                    runApp = false;
                }
            }
        }
    }

    class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        public Task(string title, string description, bool isCompleted)
        {
            Title = title;
            Description = description;
            IsCompleted = isCompleted;
        }
    }
}

