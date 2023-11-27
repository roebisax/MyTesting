using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    public class BooksEntity
    {
        public int id {  get; set; }

        public string Title { get; set; }

        public IEnumerable<CategoryEntity> Categories { get; set; }
    }
}
