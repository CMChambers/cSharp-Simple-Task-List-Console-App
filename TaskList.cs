// using SimpleTaskList;

namespace SimpleTaskList
{
    public class TaskList
    {
        private List<TaskItem> tasks = new();
        private int nextId = 1;

        public void AddTask(string description)
        {
            tasks.Add(new TaskItem { Id = nextId++, Description = description });
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
        }

        public void DeleteTask(int id)
        {
            //tasks.RemoveAll(t => t.Id == id);  // alt method

            var task = tasks.Find(t => t.Id == id);
            if (task != null)
            {
                tasks.Remove(task);
            }
        }
    }
}