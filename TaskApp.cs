// using System;
// using System.Collections.Generic;

namespace SimpleTaskList
{
    public class TaskApp
    {
        bool running;
        TaskList taskList;
        string menuSelection;
        public void Run()
        {
            Initialize();
            while (running)
            {
                WriteMenu();
                GetMenuSelection();
                ProcessMenuSelection();
            }
        }

        private void Initialize()
        {
            taskList = new TaskList();
            taskList.LoadFromFile();
            running = true;
        }

        private void WriteMenu()
        {
            Console.Clear();
            Console.WriteLine("Simple To-Do List");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View Task");
            Console.WriteLine("3. Complete Task");
            Console.WriteLine("4. Delete Task");
            Console.WriteLine("5. Clear Tasks");
            Console.WriteLine("6. Edit Task");
            Console.Write("Enter your choice: ");
        }

        private void GetMenuSelection()
        {
            string input = Console.ReadLine();
            if (input == null) { input = ""; }
            menuSelection = input;
        }

        private void ProcessMenuSelection()
        {
            switch (menuSelection)
            {
                case "0":
                    running = false;
                    break;
                case "1":
                    Console.Write("Enter task description: ");
                    string description = Console.ReadLine();
                    taskList.AddTask(description);
                    break;
                case "2":
                    taskList.ViewTask();
                    Console.ReadKey();
                    break;
                case "3":
                    Console.Write("Enter task ID to complete: ");
                    if (int.TryParse(Console.ReadLine(), out int completeId))
                    {
                        taskList.CompleteTask(completeId);
                    }
                    break;
                case "4":
                    Console.Write("Enter task ID to delete: ");
                    if (int.TryParse(Console.ReadLine(), out int deleteId))
                    {
                        taskList.DeleteTask(deleteId);
                    }
                    break;
                case "5":
                    taskList.ClearTasks();
                    break;
                case "6":
                    Console.Write("Enter task ID to edit: ");
                    if (int.TryParse(Console.ReadLine(), out int taskId))
                    {
                        taskList.WriteTaskIDandDescription(taskId);
                        Console.Write("Enter new description: ");
                        string newDescription = Console.ReadLine();
                        taskList.EditTask(taskId, newDescription);
                    }
                    break;
                default:
                    Console.WriteLine("Invalid selection.");
                    break;
            }
        }

    }
}