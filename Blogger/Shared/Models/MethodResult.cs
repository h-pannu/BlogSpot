using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogger.Shared.Models
{
    public record struct MethodResult(bool Status, string? ErrorMessage = null)
    {
        public static MethodResult Success() => new(true);
        public static MethodResult Failure(string errorMessage) => new(false, errorMessage);
    }
}
