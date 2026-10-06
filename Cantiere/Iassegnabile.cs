using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cantiere
{
    public interface IAssegnabile
    {
        bool IsOccupato { get; }
        bool AssegnaACantiere();
        bool Libera();
    }
}
