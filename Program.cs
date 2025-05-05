using SimpleTaskList;

var taskList = new TaskList();
bool running = true;

while (running)
{
    Console.Clear();
    Console.WriteLine("Simple To-Do List");
    Console.WriteLine("1. Add Task");
    Console.WriteLine("2. View Task");
    Console.WriteLine("3. Complete Task");
    Console.WriteLine("4. Delete Task");
    Console.WriteLine("5. Exit");
    Console.Write("Enter your choice: ");

    var input = Console.ReadLine();

    switch (input)
    {
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
            running = false;
            break;
    }
}