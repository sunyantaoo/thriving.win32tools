using System;
using System.Runtime.InteropServices;

namespace Thriving.Win32Tools
{
    /// <summary>
    /// 用于解决线程之间的通信
    /// </summary>
    public class EventEx
    {
        private EventEx(IntPtr handle)
        {
            this._handle = handle;
        }
        public static EventEx CreateEventEx()
        {
            return null;
        }
        public static EventEx OpenEventEx()
        {
            return null;
        }

        private readonly IntPtr _handle;

        /// <summary>
        /// 通常在子线程中创建，阻塞当前线程，有信号时则继续执行，
        /// 复位方式为手动时，需要调用ReSet()将Event转为无信号状态
        /// </summary>
        public void Wait()
        {
            KernelHelper.WaitForSingleObjectEx(_handle, 0xFFFFFFFF, true);
        }
        /// <summary>
        /// 触发事件，将事件设为有信号状态
        /// </summary>
        /// <returns></returns>
        public bool Raise()
        {
            return SetEvent(_handle);
        }

        /// <summary>
        /// 复位事件，将事件设为无信号状态
        /// </summary>
        /// <returns></returns>
        public bool ReSet()
        {
            return ResetEvent(_handle);
        }

        public bool Close()
        {
            return KernelHelper.CloseHandle(_handle);
        }


        [DllImport("kernel32.dll", EntryPoint = "CreateEventEx", CharSet = CharSet.Unicode)]
        internal static extern IntPtr CreateEventEx(IntPtr lpEventAttributes, string lpName, int dwFlags, int dwDesiredAccess);

        [DllImport("kernel32.dll", EntryPoint = "OpenEvent", CharSet = CharSet.Unicode)]
        internal static extern IntPtr OpenEvent(int dwDesiredAccess, bool bInheritHandle, string lpName);

        [DllImport("kernel32.dll", EntryPoint = "ResetEvent")]
        internal static extern bool ResetEvent(IntPtr hEvent);

        [DllImport("kernel32.dll", EntryPoint = "ResetEvent")]
        internal static extern bool SetEvent(IntPtr hEvent);
    }
}
