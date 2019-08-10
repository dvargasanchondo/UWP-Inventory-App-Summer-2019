using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App4.Models
{
    public class Inventory
    {
        public class TodoItem
        {
            public string Id { get; set; }
            public string iPhoneModel { get; set; }
            public string Category { get; set; }
            public bool Complete { get; set; }
            public string PartName { get; set; }
            public string SKU { get; set; }
            public int NumberStock { get; set; }
        }
    }
}
