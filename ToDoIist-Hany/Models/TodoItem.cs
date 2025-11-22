using System.ComponentModel.DataAnnotations;

namespace ToDolist_Hany.Models
{
    public class TodoItem
    {
        [Key]
        public int Id { get; set; }                 // primary key
        public string Title { get; set; } = "";     // what to do
        public bool IsDone { get; set; }            // completed or not
    }
}
