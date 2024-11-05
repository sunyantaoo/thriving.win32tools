using System;
using System.Runtime.InteropServices;

namespace Thriving.Win32Tools
{
    [StructLayout(LayoutKind.Explicit, Size = 48)]
    public struct MSG
    {
        [FieldOffset(0)] public IntPtr hwnd;
        [FieldOffset(8)] public int message;
        [FieldOffset(16)] public IntPtr wParam;
        [FieldOffset(24)] public IntPtr lParam;
        [FieldOffset(32)] public int time;
        [FieldOffset(36)] public int pt_x;
        [FieldOffset(40)] public int pt_y;
        // MAC专用
        [FieldOffset(44)] public int lPrivate;
    }
}
