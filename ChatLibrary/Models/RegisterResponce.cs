using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatLibrary.Models;

public class RegisterResponce
{
    public bool Success { get; set; }
    public string? Error { get; set; }

    public ChatUser? User { get; set; }
}
