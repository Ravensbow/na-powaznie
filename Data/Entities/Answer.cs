using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt1.Data.Entities
{
    public class Answer
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public bool Correctness { get; set; }
    }
}