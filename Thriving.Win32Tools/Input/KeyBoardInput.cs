using System;
using System.Runtime.InteropServices;

namespace Thriving.Win32Tools
{
    /// <summary>
    /// 支持非键盘输入方法，如手写识别，声音识别等，需将dwFlags指定为KEYEVENTF_UNICODE
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 24)]
    public struct KeyboardInput
    {
        /// <summary>
        /// 虚拟按键代码，1-254之间，
        /// 如果dwFlags指定为KEYEVENTF_UNICODE，必须为0
        /// </summary>
        [FieldOffset(0)] public VirtualKeyCode wVk;
        /// <summary>
        /// 按键对应的硬件扫描码
        /// 如果dwFlags指定为KEYEVENTF_UNICODE，需指定为Unicode字符
        /// </summary>
        [FieldOffset(2)] public short wScan;
        /// <summary>
        /// 键盘事件
        /// </summary>
        [FieldOffset(4)] public VirtualKeyEvent dwFlags;
        [FieldOffset(8)] public uint time;
        [FieldOffset(16)] public IntPtr dwExtraInfo;

        public KeyboardInput(VirtualKeyCode vkCode, VirtualKeyEvent vkEvent)
        {
            dwFlags = vkEvent;
            wVk = vkCode;
            wScan = 0;
            time = 0;
            dwExtraInfo = IntPtr.Zero;
        }

        public KeyboardInput(char unicode)
        {
            dwFlags = VirtualKeyEvent.KEYEVENTF_UNICODE;
            wScan = (short)unicode;
            wVk = 0;
            time = 0;
            dwExtraInfo = IntPtr.Zero;
        }
    }
}
