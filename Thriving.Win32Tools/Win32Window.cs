using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Thriving.Win32Tools
{
    /// <summary>
    /// 
    /// </summary>
    public class Win32Window
    {
        private readonly IntPtr _hwnd = IntPtr.Zero;
        private readonly EnumWindowsProc enumChildProc;
        private readonly IList<Win32Window> children = new List<Win32Window>();
        public Win32Window(IntPtr hwnd)
        {
            if (WindowHelper.IsWindow(hwnd))
            {
                _hwnd = hwnd;

                ThreadId = WindowHelper.GetWindowThreadProcessId(hwnd, out int processId);
                ProcessId = processId;

                enumChildProc = new EnumWindowsProc((phwnd, lParam) =>
                {
                    children.Add(new Win32Window(phwnd));
                    return true;
                });
                WindowHelper.EnumChildWindows(hwnd, enumChildProc, IntPtr.Zero);
            }
        }

        /// <summary>
        /// 窗口句柄
        /// </summary>
        public IntPtr Handle { get => _hwnd; }

        public IList<Win32Window> Children { get => children; }

        /// <summary>
        /// 线程ID
        /// </summary>
        public int ThreadId { get; }

        /// <summary>
        /// 进程ID
        /// </summary>
        public int ProcessId { get; }


        public static bool IsWin32Window(IntPtr hwnd) 
        {
            return WindowHelper.IsWindow(hwnd);
        }

        public bool Show(int nCmdShow)
        {
            return WindowHelper.ShowWindow(_hwnd, nCmdShow);
        }

        public IntPtr Focus()
        {
            return WindowHelper.SetFocus(_hwnd);
        }

        public IntPtr Active()
        {
            return WindowHelper.SetActiveWindow(_hwnd);
        }

        /// <summary>
        /// 窗口标题
        /// </summary>
        public string Title
        {
            get
            {
                var ptr = Marshal.AllocHGlobal(64);
                var size = WindowHelper.GetWindowText(_hwnd, ptr, 64);
                string title = Marshal.PtrToStringAnsi(ptr, size);
                Marshal.FreeHGlobal(ptr);
                return title;
            }
            set
            {
                WindowHelper.SetWindowText(_hwnd, value);
            }
        }

        /// <summary>
        /// 窗口类类名
        /// </summary>
        public string ClassName
        {
            get
            {
                var ptr = Marshal.AllocHGlobal(64);
                var size = WindowHelper.GetClassName(_hwnd, ptr, 64);
                var className = Marshal.PtrToStringAnsi(ptr, size);
                Marshal.FreeHGlobal(ptr);

                return className;
            }
        }

        /// <summary>
        /// 模块文件名(全路径)
        /// </summary>
        public string ModuleFileName
        {
            get
            {
                var ptr = Marshal.AllocHGlobal(128);
                var size = WindowHelper.GetWindowModuleFileName(_hwnd,  ptr, 128);
                var fileName = Marshal.PtrToStringAnsi(ptr, size);
                Marshal.FreeHGlobal(ptr);

                return fileName;
            }
        }


        public IntPtr HInstance 
        {
            get 
            {
                return WindowHelper.GetWindowLongPtr(_hwnd, WindowLongType.HINSTANCE);
            }
            set
            {
                WindowHelper.SetWindowLongPtr(_hwnd, WindowLongType.HINSTANCE, value);
            }
        }

        public IntPtr ParentWindow
        {
            get
            {
                return WindowHelper.GetWindowLongPtr(_hwnd, WindowLongType.HWNDPARENT);
            }
        }


        public Rect Rect 
        {
            get 
            {
                WindowHelper.GetWindowRect(_hwnd, out Rect result);
                return result; 
            }
        }
    }
}
