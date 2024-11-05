using System;
using System.Runtime.InteropServices;

namespace Thriving.Win32Tools
{
    [StructLayout(LayoutKind.Explicit, Size = 32)]
    public struct MOUSEHOOKSTRUCT
    {
        [FieldOffset(0)] public int pt_x;
        [FieldOffset(4)] public int pt_y;
        [FieldOffset(8)] public IntPtr hwnd;
        [FieldOffset(16)] public uint wHitTestCode;
        [FieldOffset(24)] public IntPtr dwExtraInfo;
    }
}
