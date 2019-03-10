using System;
using System.Collections.Generic;
using System.Linq;

namespace Visma.Models
{
    public interface IBankAccount
    {
        string GetLongFormat();
        bool IsCheckDigitCorrect();
    }
}