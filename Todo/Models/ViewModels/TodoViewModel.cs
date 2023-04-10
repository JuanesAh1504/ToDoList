using System.Collections.Generic;

namespace Todo.Models.ViewModels
{
    public class Tarea
    {
        public List<TodoItem> TodoList { get; set; }
        public TodoItem Todo { get; set; }
    }
}