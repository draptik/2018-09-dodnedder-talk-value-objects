using System;
using System.Collections.Generic;
using System.Linq;

namespace Examples.DateRangeDemo.V2
{
    public class TodoRepository
    {
        public IEnumerable<Todo> Todos { get; set; } = new List<Todo> {
            new Todo { Name = "foo1", ErstelltAm = new DateTime(2018, 1, 1) },
            new Todo { Name = "foo2", ErstelltAm = new DateTime(2018, 2, 1) },
            new Todo { Name = "foo3", ErstelltAm = new DateTime(2018, 3, 1) }
        };

        public IEnumerable<Todo> GetTodosInnerhalbVon(Zeitspanne zeitspanne) => 
            Todos.Where(x => zeitspanne.Umfasst(x.ErstelltAm));
    }
}