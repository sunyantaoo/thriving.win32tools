using System;
using System.Runtime.InteropServices;

namespace Thriving.Win32Tools
{
    [StructLayout(LayoutKind.Explicit, Size = 16)]
    public struct CBTACTIVATESTRUCT
    {
        [FieldOffset(0)] public bool fMouse;
        [FieldOffset(8)] public IntPtr hWndActive;
    }
}
