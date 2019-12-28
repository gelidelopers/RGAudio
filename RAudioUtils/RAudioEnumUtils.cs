using System;

namespace RAudioUtils
{
    public static class RAudioEnumUtils
    {
        public static bool IsInRange(this int index, int count)
        {
            return index >= 0 && index < count;
        }
    }
}
