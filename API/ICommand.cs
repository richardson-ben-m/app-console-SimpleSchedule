using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API;

public interface ICommand
{
    string Run(string[] args);
}
