using System;
using System.Runtime.InteropServices;

namespace Thriving.Win32Tools
{
    [StructLayout(LayoutKind.Explicit, Size = 40)]
    public struct CWPRETSTRUCT
    {
        [FieldOffset(0)] public IntPtr lResult;
        [FieldOffset(8)] public IntPtr lParam;
        [FieldOffset(16)] public IntPtr wParam;
        [FieldOffset(24)] public int message;
        [FieldOffset(32)] public IntPtr hwnd;
    }
}
