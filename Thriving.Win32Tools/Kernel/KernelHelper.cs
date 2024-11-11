using System;
using System.Runtime.InteropServices;

namespace Thriving.Win32Tools
{
    public class KernelHelper
    {
        private const string _library = "Kernel32.dll";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="LibraryName"></param>
        /// <param name="hFile"></param>
        /// <param name="dwFlags"></param>
        /// <returns>HModule</returns>
        [DllImport(_library, CharSet = CharSet.Unicode)]
        public static extern IntPtr LoadLibraryEx([MarshalAs(UnmanagedType.LPWStr)]string LibraryName, IntPtr hFile, int dwFlags);

        [DllImport(_library)]
        public static extern bool FreeLibrary(IntPtr hModule);

        [DllImport(_library)]
        public static extern IntPtr GetProcAddress(IntPtr hModule, [MarshalAs(UnmanagedType.LPStr)] string lpProcName);

        /// <summary>
        /// 获取最后一次错误代码
        /// </summary>
        /// <returns>Windows error code</returns>
        [DllImport(_library)]
        public static extern int GetLastError();

        [DllImport(_library, CharSet = CharSet.Unicode)]
        public static extern IntPtr GetModuleHandle([MarshalAs(UnmanagedType.LPWStr)] string lpModuleName);

        /// <summary>
        /// 获取当前进程ID
        /// </summary>
        /// <returns></returns>
        [DllImport(_library)]
        public static extern int GetCurrentProcessId();


        [DllImport(_library)]
        public static extern IntPtr GetCurrentProcess();


        [DllImport(_library)]
        public static extern int GetProcessId(IntPtr process);


        [DllImport(_library)]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport(_library)]
        public static extern void ExitProcess(uint exitCode);

        /// <summary>
        /// 获取当前线程ID
        /// </summary>
        /// <returns></returns>
        [DllImport(_library)]
        public static extern int GetCurrentThreadId();

        [DllImport(_library)]
        public static extern IntPtr GetCurrentThread();

        [DllImport(_library)]
        public static extern int GetThreadId(IntPtr thread);

        [DllImport(_library)]
        public static extern int GetThreadPriority(IntPtr thread);

        [DllImport(_library)]
        public static extern IntPtr OpenThread(int dwDesiredAccess, bool bInheritHandle, int dwThreadId);

        [DllImport(_library)]
        public static extern void ExitThread(int exitCode);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hHandle">可等待句柄</param>
        /// <param name="dwMilliseconds">时间：毫秒</param>
        /// <param name="bAlertable"></param>
        /// <returns></returns>
        [DllImport(_library)]
        internal static extern int WaitForSingleObjectEx(IntPtr hHandle, uint dwMilliseconds, bool bAlertable);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nCount"></param>
        /// <param name="lpHandles"></param>
        /// <param name="bWaitAll"></param>
        /// <param name="dwMilliseconds"></param>
        /// <param name="bAlertable"></param>
        /// <returns></returns>
        [DllImport(_library)]
        internal static extern int WaitForMultipleObjectsEx(int nCount, IntPtr[] lpHandles, bool bWaitAll, uint dwMilliseconds, bool bAlertable);

        /// <summary>
        /// 关闭对象，对象可为以下对象：Access token，Communications device，Console input，Console screen buffer，Event，File，
        /// File mapping，I/O completion port，Job，Mailslot，Memory resource notification，Mutex，Named pipe，Pipe，Process，Semaphore，Thread，Transaction，Waitable time
        /// </summary>
        /// <param name="hObject"></param>
        /// <returns></returns>
        [DllImport(_library)]
        internal static extern bool CloseHandle(IntPtr hObject);
    }
}
