using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2a
{
    public interface IPersistence
    {
        bool Load(string filename);
        bool Save(string filename, bool appendToFile);
    }
}
