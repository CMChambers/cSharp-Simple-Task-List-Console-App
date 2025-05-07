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

        enum MenuOption
        {
            Exit,
            ViewTasks,
            AddTask,
            EditTask,
            CompleteTask,
            DeleteTask,
            ClearTasks,
        }
        private void WriteMenu()
        {
            WriteMenuHeader();
            for (int currentMenuNumber = 0; currentMenuNumber < Enum.GetNames(typeof(MenuOption)).Length; currentMenuNumber++)
            {
                Console.WriteLine($"{currentMenuNumber}. {(MenuOption)currentMenuNumber}");
            }
            Console.Write("Enter your choice: ");
        }

        private void WriteMenuHeader()
        {
            Console.Clear();
            Console.WriteLine("Simple To-Do List");
        }

        private void GetMenuSelection()
        {
            string input = Console.ReadLine();
            if (input == null) { input = ""; }
            menuSelection = input;
        }

        private void ProcessMenuSelection()
        {
            switch ((MenuOption)int.Parse(menuSelection))
            {
                case MenuOption.Exit:
                    exit();
                    break;
                case MenuOption.AddTask:
                    addTask();
                    break;
                case MenuOption.ViewTasks:
                    viewTask();
                    break;
                case MenuOption.CompleteTask:
                    completeTask();
                    break;
                case MenuOption.DeleteTask:
                    deleteTask();
                    break;
                case MenuOption.ClearTasks:
                    clearTaskList();
                    break;
                case MenuOption.EditTask:
                    editTask();
                    break;
                default:
                    Console.WriteLine("Invalid selection.");
                    break;
            }
        }

        private void editTask()
        {
            Console.Write("Enter task ID to edit: ");
            if (int.TryParse(Console.ReadLine(), out int taskId))
            {
                taskList.WriteTaskIDandDescription(taskId);
                Console.Write("Enter new description: ");
                string newDescription = Console.ReadLine();
                taskList.EditTask(taskId, newDescription);
            }
        }

        private void clearTaskList()
        {
            taskList.ClearTasks();
        }

        private void deleteTask()
        {
            Console.Write("Enter task ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int deleteId))
            {
                taskList.DeleteTask(deleteId);
            }
        }

        private void completeTask()
        {
            Console.Write("Enter task ID to complete: ");
            if (int.TryParse(Console.ReadLine(), out int completeId))
            {
                taskList.CompleteTask(completeId);
            }
        }

        private void viewTask()
        {
            taskList.ViewTask();
            Console.ReadKey();
        }

        private void addTask()
        {
            Console.Write("Enter task description: ");
            string description = Console.ReadLine();
            taskList.AddTask(description);
        }

        private void exit()
        {
            running = false;
        }
    }
}