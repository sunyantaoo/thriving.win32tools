using System;
using System.Runtime.InteropServices;

namespace Thriving.Win32Tools
{
    [StructLayout(LayoutKind.Explicit, Size = 32)]
    public struct CWPSTRUCT
    {
        [FieldOffset(0)] public IntPtr lParam;
        [FieldOffset(8)] public IntPtr wParam;
        [FieldOffset(16)] public int message;
        [FieldOffset(24)] public IntPtr hwnd;
    }
}
