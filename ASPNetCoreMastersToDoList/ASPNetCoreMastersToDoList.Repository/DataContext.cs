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
            new Item() {Id = 1, Text ="item1", CreatedBy="sampleuser01", DateCreated= DateTime.Now},
            new Item() {Id = 2, Text ="item2", CreatedBy="sampleuser01", DateCreated= DateTime.Now},
            new Item() {Id = 3, Text ="item3", CreatedBy="sampleuser01", DateCreated= DateTime.Now}
        };


    }
}
