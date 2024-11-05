using System;
using System.Runtime.InteropServices;

namespace Thriving.Win32Tools
{
    [StructLayout(LayoutKind.Explicit, Size = 24)]
    public struct EVENTMSG
    {
        [FieldOffset(0)] public int message;
        [FieldOffset(4)] public int paramL;
        [FieldOffset(8)] public int paramH;
        [FieldOffset(12)] public int time;
        [FieldOffset(16)] public IntPtr hwnd;
    }
}
