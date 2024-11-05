using System;
using System.Runtime.InteropServices;

namespace Thriving.Win32Tools
{
    /// <summary>
    /// 互斥锁，Wait()和Release()之间的对象将被锁定
    /// </summary>
    public class MutexEx
    {
        private MutexEx(IntPtr hangle)
        {
            _handle= hangle;
        }
        public static MutexEx CreateMutex() 
        {
            return null;
        }
        public static MutexEx OpenMutex() 
        {
            return null;
        }

        private readonly IntPtr _handle;

        /// <summary>
        /// 通常在子线程中创建，阻塞当前线程，有信号时则继续执行，并将Mutex转为无信号状态
        /// </summary>
        public void Wait()
        {
            // 0xFFFFFFFF表示INFINITE无限时等待，知道有信号
            KernelHelper.WaitForSingleObjectEx(_handle, 0xFFFFFFFF, true);
        }

        /// <summary>
        /// 释放互斥锁，保持为有信号状态 
        /// </summary>
        /// <returns></returns>
        public bool Release() 
        {
            return ReleaseMutex(_handle);
        }

        public bool Close()
        {
            return KernelHelper.CloseHandle(_handle);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="lpMutexAttributes">安全属性</param>
        /// <param name="lpName">名称</param>
        /// <param name="dwFlags">true表示初始拥有者为创建线程</param>
        /// <param name="dwDesiredAccess">访问权</param>
        /// <returns></returns>
        [DllImport("kernel32.dll", EntryPoint = "CreateMutexEx", CharSet = CharSet.Unicode)]
        internal static extern IntPtr CreateMutexEx( IntPtr lpMutexAttributes, string lpName,  bool dwFlags,  int dwDesiredAccess);

        /// <summary>
        /// 打开已命名的互斥锁
        /// </summary>
        /// <param name="dwDesiredAccess"></param>
        /// <param name="bInheritHandle"></param>
        /// <param name="lpName"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", EntryPoint = "OpenMutex", CharSet = CharSet.Unicode)]
        internal static extern IntPtr OpenMutex( int dwDesiredAccess, bool bInheritHandle,  string lpName);

        /// <summary>
        /// 释放互斥锁
        /// </summary>
        /// <param name="hMutex"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", EntryPoint = "ReleaseMutex", CharSet = CharSet.Unicode)]
        internal static extern bool ReleaseMutex( IntPtr hMutex);
    }
}
