using System;
using System.Runtime.InteropServices;

namespace Thriving.Win32Tools
{
    [StructLayout(LayoutKind.Explicit, Size = 32)]
    public struct MouseInput
    {
        /// <summary>
        /// 根据dwFlags的类型，取绝对值或相对值（相对上次鼠标事件的位置）
        /// 绝对值为鼠标的x坐标，相对值为像素值
        /// </summary>
        [FieldOffset(0)] public int dx;
        /// <summary>
        /// 根据dwFlags的类型，取绝对值或相对值（相对上次鼠标事件的位置）
        /// 绝对值为鼠标的y坐标，相对值为像素值
        /// </summary>
        [FieldOffset(4)] public int dy;
        /// <summary>
        /// 如果dwFlags包含MOUSEEVENTF_WHEEL使用mouseData指定滚轮的移动量，正值向前负值向后。One wheel click is defined as WHEEL_DELTA, which is 120.
        ///  如果dwFlags包含MOUSEEVENTF_WHEEL，MOUSEEVENTF_XDOWN或MOUSEEVENTF_XUP，mouseData 应该指定为0。
        /// 如果dwFlags包含MOUSEEVENTF_XDOWN或MOUSEEVENTF_XUP，mouseData应该指定哪一个X按钮（1,2）被按下或放开。
        /// </summary>
        [FieldOffset(8)] public int mouseData;
        /// <summary>
        /// 鼠标事件
        /// </summary>
        [FieldOffset(12)] public int dwFlags;
        [FieldOffset(16)] public int time;
        [FieldOffset(24)] public IntPtr dwExtraInfo;
    }
}
