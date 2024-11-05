using System;
using System.Runtime.InteropServices;

namespace Thriving.Win32Tools
{
    /// <summary>
    /// 用于进程内 内存的读写
    /// </summary>
    public unsafe class MemoryHelper
    {
        private readonly IntPtr _hProcess;
        public MemoryHelper(IntPtr hProcess)
        {
            _hProcess = hProcess;
        }

        public MemoryHelper()
        {
            _hProcess = KernelHelper.GetCurrentProcess();
        }

        public T Read<T>(IntPtr target) where T : struct
        {
            T result = default;
            var ok = ReadProcessMemory(_hProcess, target, &result, Marshal.SizeOf(typeof(T)), out int readed);
            return result;
        }

        public T[] Read<T>(IntPtr target, int size) where T : struct
        {
            T[] result = new T[size];
            var ok = ReadProcessMemory(_hProcess, target, &result, size * Marshal.SizeOf(typeof(T)), out int readed);
            return result;
        }

        public bool Write<T>(IntPtr target, T obj) where T : struct
        {
            return WriteProcessMemory(_hProcess, target, &obj, Marshal.SizeOf(typeof(T)), out int written);
        }

        /// <summary>
        /// 将结构体值写入指定的内存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target"></param>
        /// <param name="data"></param>
        public bool Write<T>(IntPtr target, T[] obj) where T : struct
        {
            return WriteProcessMemory(_hProcess, target, &obj, obj.Length * Marshal.SizeOf(typeof(T)), out int written);
        }


        [DllImport("Kernel32.dll")]
        private static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] void* lpBuffer, int dwSize, out int numberOfBytesRead);

        [DllImport("Kernel32.dll")]
        private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out] void* lpBuffer, int dwSize, out int numberOfBytesWritten);
    }

}
