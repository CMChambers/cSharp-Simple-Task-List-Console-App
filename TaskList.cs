// using SimpleTaskList;

namespace SimpleTaskList
{
    public class TaskList
    {
        private List<TaskItem> tasks = new();
        private int nextId = 1;
        private string filePath = "tasks.txt";

        public void AddTask(string description)
        {
            nextId = tasks.Count + 1;
            tasks.Add(new TaskItem { Id = nextId++, Description = description });
            SaveToFile();
        }

        public void ViewTask()
        {
            foreach (var task in tasks)
            {
                string status = task.IsCompleted ? "[x]" : "[ ]";
                Console.WriteLine($"{task.Id}: {status} {task.Description}");
            }
        }

        public void CompleteTask(int id)
        {
            var task = tasks.Find(t => t.Id == id);
            if (task != null)
            {
                task.IsCompleted = true;
            }
            SaveToFile();
        }

        public void DeleteTask(int id)
        {
            //tasks.RemoveAll(t => t.Id == id);  // alt method

            var task = tasks.Find(t => t.Id == id);
            if (task != null)
            {
                tasks.Remove(task);
            }

            RenumberTasks();
            SaveToFile();
        }

        private void RenumberTasks()
        {
            int newID = 1;
            foreach (var t in tasks)
            {
                t.Id = newID;
                newID++;
            }
        }

        private void SaveToFile()
        {
            using(var writer = new StreamWriter(filePath))
            {
                foreach (var task in tasks)
                {
                    writer.WriteLine($"{task.Id},{task.Description},{task.IsCompleted}");
                }
            }
        }

        public void LoadFromFile()
        {
            // string filepath = "tasks.txt";

            if (File.Exists(filePath))
            {
                foreach (var line in File.ReadAllLines(filePath))
                {
                    string[] parts = line.Split(',');
                    tasks.Add(new TaskItem
                    {
                        Id = int.Parse(parts[0]),
                            Description = parts[1],
                            IsCompleted = bool.Parse(parts[2])
                    });
                }

                // alt method
                // using(var reader = new StreamReader(filepath))
                // {
                //     string line;
                //     while ((line = reader.ReadLine()) != null)
                //     {
                //         var parts = line.Split(',');
                //         tasks.Add(new TaskItem
                //         {
                //             Id = int.Parse(parts[0]),
                //                 Description = parts[1],
                //                 IsCompleted = bool.Parse(parts[2])
                //         });
                //     }
                // }
            }
        }
    }
}