using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.SharedKernel;

public interface IStartupBase
{
    /// <summary>
    /// Execute the startup action.
    /// </summary>
    void Execute();
    /// <summary>
    /// Priority of the startup action.
    /// </summary>
    int Priority { get; }
}
