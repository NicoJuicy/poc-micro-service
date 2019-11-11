using System;
using System.Collections.Generic;
using System.Text;

namespace TagService.Core.Enums
{
    [Flags]
    public enum TagType
    {
        IsActive = 1,
        IsSynonym = 4
    }
}
