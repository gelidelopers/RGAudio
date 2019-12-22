using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RAudioDataAccess.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Category ParentCategory { get; set; }                    
    }
}
