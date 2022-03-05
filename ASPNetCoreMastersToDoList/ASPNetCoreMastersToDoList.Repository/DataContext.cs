using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNetCoreMastersToDoList.Repository
{
    public class DataContext
    {
        public List<Item> Items = new List<Item> {
            new Item() {Id = 1, Text ="item1"},
            new Item() {Id = 2, Text ="item2"},
            new Item() {Id = 3, Text ="item3"}
        };

        
    }
}
