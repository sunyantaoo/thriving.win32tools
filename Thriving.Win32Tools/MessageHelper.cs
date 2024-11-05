using System;
using System.Runtime.InteropServices;

namespace Thriving.Win32Tools
{
    public class MessageHelper
    {
        [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Unicode)]
        public static extern int SendMessage(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", EntryPoint = "GetMessage", CharSet = CharSet.Unicode)]
        public static extern bool GetMessage(MSG msg, IntPtr hwnd, int min, int max);

        [DllImport("user32.dll", EntryPoint = "PeekMessage", CharSet = CharSet.Unicode)]
        public static extern bool PeekMessage(MSG msg, IntPtr hwnd, int min, int max, HandleMode mode);

        /// <summary>
        /// 消息提示框
        /// </summary>
        /// <param name="hWnd">父窗体</param>
        /// <param name="lpText">消息内容</param>
        /// <param name="lpCaption">标题</param>
        /// <param name="uType">样式</param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "MessageBox", CharSet = CharSet.Unicode)]
        public static extern int MessageBox(  IntPtr hWnd, string lpText,  string lpCaption,  int uType);
    }

    public enum HandleMode
    {
        /// <summary>
        /// 不从消息队列移除消息
        /// </summary>
        PM_NOREMOVE = 0x0000,
        /// <summary>
        /// 从消息队列移除消息
        /// </summary>
        PM_REMOVE = 0x0001,
        /// <summary>
        /// 与PM_NOREMOVE或PM_REMOVE合并使用，不释放线程使调用者处于Idle状态
        /// </summary>
        PM_NOYIELD = 0x0002
    }
}
