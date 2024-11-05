using System;
using System.Runtime.InteropServices;

namespace Thriving.Win32Tools
{
    [StructLayout(LayoutKind.Explicit, Size = 24)]
    public struct KBDLLHOOKSTRUCT
    {
        [FieldOffset(0)] public int vkCode;
        [FieldOffset(4)] public int scanCode;
        [FieldOffset(8)] public int flags;
        [FieldOffset(12)] public int time;
        [FieldOffset(16)] public IntPtr dwExtraInfo;
    }
}
