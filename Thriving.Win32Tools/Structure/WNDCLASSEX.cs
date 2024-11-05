using System;
using System.Runtime.InteropServices;

namespace Thriving.Win32Tools
{
    [StructLayout(LayoutKind.Explicit, Size = 80, CharSet = CharSet.Unicode)]
    public struct WNDCLASSEX
    {
        /// <summary>
        /// 结构体大小
        /// </summary>
        [FieldOffset(0)] public int cbSize;
        /// <summary>
        /// 窗口类样式
        /// </summary>
        [FieldOffset(4)] public WindowClassStyle style;
        /// <summary>
        /// 窗口处理函数
        /// </summary>
        [FieldOffset(8)] public WindowProc lpfnWndProc;
        /// <summary>
        /// 为窗口类额外分配的字节
        /// </summary>
        [FieldOffset(16)] public int cbClsExtra;
        /// <summary>
        /// 为窗口实例额外分配的字节
        /// </summary>
        [FieldOffset(20)] public int cbWndExtra;
        [FieldOffset(24)] public IntPtr hInstance;
        [FieldOffset(32)] public IntPtr hIcon;
        /// <summary>
        /// 光标
        /// </summary>
        [FieldOffset(40)] public IntPtr hCursor;
        /// <summary>
        /// 背景画刷
        /// </summary>
        [FieldOffset(48)] public IntPtr hbrBackground;
        /// <summary>
        /// 菜单
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        [FieldOffset(56)] public string lpszMenuName;
        /// <summary>
        /// 窗口类唯一名称
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        [FieldOffset(64)] public string lpszClassName;
        /// <summary>
        /// 小图标
        /// </summary>
        [FieldOffset(72)] public IntPtr hIconSm;
    }
}
