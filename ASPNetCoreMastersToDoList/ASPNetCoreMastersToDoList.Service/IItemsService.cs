using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNetCoreMastersToDoList.Service
{
    public interface IItemsService
    {
        IEnumerable<string> GetItems(int id);
    }
}
