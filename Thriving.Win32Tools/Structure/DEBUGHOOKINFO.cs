using System;
using System.Runtime.InteropServices;

namespace Thriving.Win32Tools
{
    [StructLayout(LayoutKind.Explicit, Size = 32)]
    public struct DEBUGHOOKINFO
    {
        [FieldOffset(0)] public int idThread;
        [FieldOffset(4)] public int idThreadInstaller;
        [FieldOffset(8)] public IntPtr lParam;
        [FieldOffset(16)] public IntPtr wParam;
        [FieldOffset(24)] public int code;
    }
}
