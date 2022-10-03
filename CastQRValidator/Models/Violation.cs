using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CastQRValidator.Models
{
    public class  Violation
    {
        public Violation(int beginLine, int endLine, int beginColumn, int endColumn)
        {
            BeginLine = beginLine;
            EndLine = endLine;
            BeginColumn = beginColumn;
            EndColumn = endColumn;
        }

        public int BeginLine { get;}
        public int EndLine { get;}
        public int BeginColumn { get;}

        public int EndColumn { get;}
    }
}
