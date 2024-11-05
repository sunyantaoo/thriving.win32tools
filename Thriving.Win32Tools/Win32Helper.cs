using System;

namespace Thriving.Win32Tools
{
    public class Win32Helper
    {
        public static short High16Bits(IntPtr param)
        {
            var data = (long)param;
            var result = (short)(data >> 16 & 0xffff);
            return result;
        }

        public static short Low16Bits(IntPtr param)
        {
            var data = (long)param;
            var result = (short)(data & 0xffff);
            return result;
        }
    }
}
