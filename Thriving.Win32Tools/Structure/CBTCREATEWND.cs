using System;
using System.Runtime.InteropServices;

namespace Thriving.Win32Tools
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CBTCREATEWND
    {
        public CREATESTRUCTA lpcs;
        public IntPtr hwndInsertAfter;
    }

    [StructLayout(LayoutKind.Explicit, Size = 80, CharSet = CharSet.Unicode)]
    public struct CREATESTRUCTA
    {
        [FieldOffset(0)] public IntPtr lpCreateParams;
        [FieldOffset(8)] public IntPtr hInstance;
        [FieldOffset(16)] public IntPtr hMenu;
        [FieldOffset(24)] public IntPtr hwndParent;
        [FieldOffset(32)] public int cy;
        [FieldOffset(36)] public int cx;
        [FieldOffset(40)] public int y;
        [FieldOffset(44)] public int x;
        [FieldOffset(48)] public int style;
        [MarshalAs(UnmanagedType.LPWStr)]
        [FieldOffset(56)] public string lpszName;
        [MarshalAs(UnmanagedType.LPWStr)]
        [FieldOffset(64)] public string lpszClass;
        [FieldOffset(72)] public int dwExStyle;
    }
}
