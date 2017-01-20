using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace WebApplicationTODO.Models
{
    public class TodoRepository : ITodoRepository
    {
        private static ConcurrentDictionary<string, TodoItem > _todos =
              new ConcurrentDictionary<string, TodoItem >();

        public TodoRepository()
        {
            Add(new TodoItem { Name = "Item1" });
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return _todos.Values;
        }

        public void Add(TodoItem item)
        {
            item.Key = Guid.NewGuid().ToString();
            _todos[item.Id] = item;
        }

        public TodoItem Find(string id)
        {
            TodoItem item;
            _todos.TryGetValue(id, out item);
            return item;
        }

        public TodoItem Remove(string id)
        {
            TodoItem item;
            _todos.TryRemove(id, out item);
            return item;
        }

        public void Update(TodoItem item)
        {
            _todos[item.Id] = item;
        }
    }
}