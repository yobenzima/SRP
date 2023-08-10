using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP.Application.Responses;

public class BaseCommandResponse
{
    public Guid Id { get; set; }
    public bool Success { get; set; }
    public string? Message { get; set; }
    public List<string> Errors { get; set; } = new List<string>();
}

