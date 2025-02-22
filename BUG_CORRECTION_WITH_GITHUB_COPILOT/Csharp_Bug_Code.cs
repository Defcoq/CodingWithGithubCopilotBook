using System;
using System.Collections.Generic;

class Program
{
    static List<string> tasks = new List<string>();

    static void Main()
    {
        Console.WriteLine("Welcome to the Task Manager!");

        while (true)
        {
            Console.WriteLine("Choose an option: 1) Add Task 2) Remove Task 3) View Tasks 4) Exit");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("Enter task description:");
                string taskDescription = Console.ReadLine();
                AddTask(taskDescription);
            }
            else if (choice == "2")
            {
                Console.WriteLine("Enter task description to remove:");
                string taskDescription = Console.ReadLine();
                RemoveTask(taskDescription);
            }
            else if (choice == "3")
            {
                ViewTasks();
            }
            else if (choice == "4")
            {
                break;
            }
        }
    }

    static void AddTask(string task)
    {
        tasks.Add(task);
        Console.WriteLine("Task added successfully");
    }

    static void RemoveTask(string task)
    {
        tasks.Remove(task);
        Console.WriteLine("Task removed successfully");
    }

    static void ViewTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks to show.");
        }
        else
        {
            Console.WriteLine("Tasks:");
            foreach (var task in tasks)
            {
                Console.WriteLine(task);
            }
        }
    }
}

