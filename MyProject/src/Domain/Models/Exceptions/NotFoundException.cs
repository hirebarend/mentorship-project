using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.src.Domain.Models.Exceptions
{
    public class NotFoundException(string message) : Exception(message)
    {
    }
}