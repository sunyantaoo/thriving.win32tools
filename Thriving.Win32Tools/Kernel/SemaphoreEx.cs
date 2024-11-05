using System;
using System.Runtime.InteropServices;

namespace Thriving.Win32Tools
{
    /// <summary>
    /// 与EventEx类似，用于线程之间的通信，提供了一个了计数器(表示信号量)
    /// </summary>
    public class SemaphoreEx
    {
        private SemaphoreEx(IntPtr handle)
        {
            this._handle = handle;
        }
        public static SemaphoreEx CreateSemaphoreEx()
        {
            return null;
        }
        public static SemaphoreEx OpenSemaphoreEx()
        {
            return null;
        }
        private readonly IntPtr _handle;

        /// <summary>
        /// 每通过一次，信号量减1，到0时阻塞线程
        /// </summary>
        public void Wait()
        {
            KernelHelper.WaitForSingleObjectEx(_handle, 0xFFFFFFFF, true);
        }

        /// <summary>
        /// 重设信号量
        /// </summary>
        /// <returns></returns>
        public bool ReSet(int count)
        {
            var result = ReleaseSemaphore(_handle, count, out int previousCount);
            return result;
        }

        public bool Close()
        {
            return KernelHelper.CloseHandle(_handle);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lpSemaphoreAttributes"></param>
        /// <param name="lInitialCount">初始值</param>
        /// <param name="lMaximumCount">最大值</param>
        /// <param name="lpName"></param>
        /// <param name="dwFlags"></param>
        /// <param name="dwDesiredAccess"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", EntryPoint = "CreateSemaphoreEx", CharSet = CharSet.Unicode)]
        internal static extern IntPtr CreateSemaphoreEx(IntPtr lpSemaphoreAttributes, int lInitialCount, int lMaximumCount, string lpName, int dwFlags, int dwDesiredAccess);

        [DllImport("kernel32.dll", EntryPoint = "OpenSemaphore", CharSet = CharSet.Unicode)]
        internal static extern IntPtr OpenSemaphore(int dwDesiredAccess, bool bInheritHandle, string lpName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hSemaphore"></param>
        /// <param name="lReleaseCount"></param>
        /// <param name="lpPreviousCount"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", EntryPoint = "ReleaseSemaphore")]
        internal static extern bool ReleaseSemaphore( IntPtr hSemaphore,  int lReleaseCount,out  int lpPreviousCount);
    }
}
