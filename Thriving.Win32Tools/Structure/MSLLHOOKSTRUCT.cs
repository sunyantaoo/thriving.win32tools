using System;
using System.Runtime.InteropServices;

namespace Thriving.Win32Tools
{
    [StructLayout(LayoutKind.Explicit, Size = 32)]
    public struct MSLLHOOKSTRUCT
    {
        [FieldOffset(0)] public int pt_x;
        [FieldOffset(4)] public int pt_y;
        [FieldOffset(8)] public int mouseData;
        [FieldOffset(12)] public int flags;
        [FieldOffset(16)] public int time;
        [FieldOffset(24)] public IntPtr dwExtraInfo;
    }
}
