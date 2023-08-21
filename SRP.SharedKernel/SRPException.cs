using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.SharedKernel;

/// <summary>
/// Represents errors that occur during application execution.
/// </summary>
[Serializable]
public class SRPException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SRPException"/> class.
    /// </summary>
    public SRPException()
    {        
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="SRPException"/> class with specified error message.
    /// </summary>
    /// <param name="message"></param>
    public SRPException(string message) : base(message)
    {
    }
}
