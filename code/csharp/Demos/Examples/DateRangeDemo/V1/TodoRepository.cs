using System;
using System.Collections.Generic;
using System.Linq;

namespace Examples.DateRangeDemo.V1
{
    public class TodoRepository
    {
        private IEnumerable<Todo> Todos { get; } = new List<Todo> {
            new Todo { Name = "foo1", ErstelltAm = new DateTime(2018, 1, 1) },
            new Todo { Name = "foo2", ErstelltAm = new DateTime(2018, 2, 1) },
            new Todo { Name = "foo3", ErstelltAm = new DateTime(2018, 3, 1) }
        };

        public IEnumerable<Todo> GetTodosBetween(DateTime from, DateTime to)
        {
            if (from > to)
            {
                return new List<Todo>();
            }
                           
            return Todos.Where(x => x.ErstelltAm >= from && x.ErstelltAm <= to);
        }
    }
}