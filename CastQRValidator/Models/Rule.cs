using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastQRValidator.Models
{
    internal class Rule
    {
        public Rule(int id, string originalName)
        {
            Id = id;
            OriginalName = originalName;
        }

        public int Id {  get; }

        public string OriginalName { get; }
    }
}
