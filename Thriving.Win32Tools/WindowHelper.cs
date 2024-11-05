using System;
using System.Runtime.InteropServices;

namespace Thriving.Win32Tools
{
    /// <summary>
    /// 窗口帮助类
    /// </summary>
    public class WindowHelper
    {
        /// <summary>
        /// 消息提示框
        /// </summary>
        /// <param name="hWnd">父窗体</param>
        /// <param name="lpText">消息内容</param>
        /// <param name="lpCaption">标题</param>
        /// <param name="uType">样式，按位或("|")合并样式</param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "MessageBox", CharSet = CharSet.Unicode)]
        public static extern MessageBoxResult MessageBox(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)]string lpText, [MarshalAs(UnmanagedType.LPWStr)] string lpCaption, int uType);

        /// <summary>
        /// 默认窗口处理函数
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="uMsg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "DefWindowProc", CharSet = CharSet.Unicode)]
        public static extern IntPtr DefWindowProc(IntPtr hWnd, WindowMessage uMsg, IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// 注册窗口类
        /// </summary>
        /// <param name="wndClass"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "RegisterClassEx", CharSet = CharSet.Unicode)]
        public static extern short RegisterClassEx(ref WNDCLASSEX wndClass);

        /// <summary>
        /// 注销窗口类
        /// </summary>
        /// <param name="lpClassName">唯一名称</param>
        /// <param name="hInstance"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "UnregisterClass", CharSet = CharSet.Unicode)]
        public static extern short UnregisterClass([MarshalAs(UnmanagedType.LPWStr)] string lpClassName,IntPtr hInstance);

        /// <summary>
        /// 创建窗口
        /// </summary>
        /// <param name="dwExStyle">扩展样式 <see cref="WindowExtentedStyle"/></param>
        /// <param name="lpszClassName">窗口类类名</param>
        /// <param name="lpszWindowName">窗口标题</param>
        /// <param name="style">基础样式 <see cref="WindowStyle"/></param>
        /// <param name="x">左上角X坐标</param>
        /// <param name="y">左上角Y坐标</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <param name="hwndParent">父窗口</param>
        /// <param name="hMenu">菜单</param>
        /// <param name="hInstance"></param>
        /// <param name="pvParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "CreateWindowEx", CharSet = CharSet.Unicode)]
        public static extern IntPtr CreateWindowEx(WindowExtentedStyle dwExStyle,
            [MarshalAs(UnmanagedType.LPWStr)] string lpszClassName,
            [MarshalAs(UnmanagedType.LPWStr)] string lpszWindowName,
            WindowStyle style,
            int x, int y, int width, int height,
            IntPtr hwndParent,
            IntPtr hMenu,
            IntPtr hInstance,
            IntPtr lParam);

        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nCmdShow">程序第一次调用时忽略</param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "ShowWindow")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
       
        /// <summary>
        /// 摧毁窗口
        /// </summary>
        /// <param name="hwnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "DestroyWindow", CharSet = CharSet.Unicode)]
        public static extern bool DestroyWindow(IntPtr hwnd);

        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "CloseWindow")]
        public static extern bool CloseWindow(IntPtr hWnd);

        /// <summary>
        /// 查找窗口
        /// </summary>
        /// <param name="hWndParent">父窗口，可选</param>
        /// <param name="hWndChildAfter"></param>
        /// <param name="lpszClass">窗口类类名</param>
        /// <param name="lpszWindow">窗口标题</param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "FindWindowEx", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindowEx(IntPtr hWndParent,
            IntPtr hWndChildAfter,
            [MarshalAs(UnmanagedType.LPWStr)] string lpszClass,
            [MarshalAs(UnmanagedType.LPWStr)] string lpszWindow);

        /// <summary>
        /// 获取窗口标题的长度
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "GetWindowTextLength")]
        public static extern int GetWindowTextLength(IntPtr hWnd);

        /// <summary>
        /// 获取窗口标题
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="name">存储标题的地址</param>
        /// <param name="maxCount">假定最大长度</param>
        /// <returns>获取成功返回长度，通过地址和长度获取转为字符串</returns>
        [DllImport("user32.dll", EntryPoint = "GetWindowText")]
        public static extern int GetWindowText(IntPtr hWnd, IntPtr name, int maxCount);

        /// <summary>
        /// 设置窗口标题
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lpString"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "SetWindowText",CharSet =CharSet.Unicode)]
        public static extern bool SetWindowText(IntPtr hWnd, [MarshalAs(UnmanagedType.LPWStr)] string lpString);

        [DllImport("user32.dll", EntryPoint = "SetWindowPos", CharSet = CharSet.Unicode)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, WindowPosStyle uFlags);

        /// <summary>
        /// 获取值类型窗口信息
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="nIndex"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        public static extern int GetWindowLong(IntPtr hwnd, WindowLongType nIndex);
       /// <summary>
       /// 设置值类型窗口信息
       /// </summary>
       /// <param name="hwnd"></param>
       /// <param name="nIndex"></param>
       /// <param name="dwNewLong"></param>
       /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
        public static extern int SetWindowLong(IntPtr hwnd, WindowLongType nIndex,int dwNewLong);
        /// <summary>
        /// 获取窗口引用类型信息
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nIndex"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "GetWindowLongPtr")]
        public static extern IntPtr GetWindowLongPtr( IntPtr hWnd, WindowLongType nIndex);
        /// <summary>
        /// 设置窗口引用类型信息
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="nIndex"></param>
        /// <param name="dwNewLong"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr")]
        public static extern IntPtr SetWindowLongPtr(IntPtr hWnd, WindowLongType nIndex,IntPtr dwNewLong);

        /// <summary>
        /// 获取窗口模块的文件名(全路径)
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="pszFileName">存储文件路径的地址</param>
        /// <param name="cchFileNameMax">假定最大长度</param>
        /// <returns>获取成功返回长度，通过地址和长度获取转为字符串</returns>
        [DllImport("user32.dll", EntryPoint = "GetWindowModuleFileName")]
        public static extern int GetWindowModuleFileName(IntPtr hwnd, IntPtr pszFileName, int cchFileNameMax);

        /// <summary>
        /// 获取窗口线程进程ID
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="processId">存储进程ID的地址</param>
        /// <returns>返回创建窗口的线程ID</returns>
        [DllImport("user32.dll", EntryPoint = "GetWindowThreadProcessId")]
        public static extern int GetWindowThreadProcessId(IntPtr hWnd,out int processId);

        /// <summary>
        /// 获取显示状态和恢复、最小化和最大化的位置
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lpwndpl"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "GetWindowPlacement")]
        public static extern bool GetWindowPlacement(IntPtr hWnd, out WINDOWPLACEMENT lpwndpl);

        /// <summary>
        /// 设置显示状态和恢复、最小化和最大化的位置
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lpwndpl"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "SetWindowPlacement")]
        public static extern bool SetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

        /// <summary>
        /// 获取窗口边框
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lpRect">指向RECT结构体</param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "GetWindowRect")]
        public static extern bool GetWindowRect(IntPtr hWnd,out Rect lpRect);

        /// <summary>
        /// 获取窗口类类名
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="lpClassName">存储类名的地址</param>
        /// <param name="nMaxCount">假定最大长度</param>
        /// <returns>获取成功返回长度，通过地址和长度获取转为字符串</returns>
        [DllImport("user32.dll", EntryPoint = "GetClassName")]
        public static extern int GetClassName(IntPtr hWnd, IntPtr lpClassName, int nMaxCount);

        /// <summary>
        /// 给定窗口句柄是否指向已存在的窗口
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "IsWindow")]
        public static extern bool IsWindow(IntPtr hWnd);


        [DllImport("user32.dll", EntryPoint = "SetActiveWindow")]
        public static extern IntPtr SetActiveWindow(IntPtr hWnd);

        /// <summary>
        /// 将键盘输入
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "SetFocus")]
        public static extern IntPtr SetFocus(IntPtr hWnd);

        /// <summary>
        /// 将鼠标捕获设置为属于当前线程的指定窗口
        /// </summary>
        /// <param name="hWnd">上一个</param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "SetCapture")]
        public static extern IntPtr SetCapture(IntPtr hWnd);


        [DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);


        [DllImport("user32.dll", EntryPoint = "BringWindowToTop")]
        public static extern bool BringWindowToTop(IntPtr hWnd);


        /// <summary>
        /// 检索窗体
        /// </summary>
        /// <param name="lpEnumFunc"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "EnumWindows")]
        public static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        /// <summary>
        /// 检索子窗体
        /// </summary>
        /// <param name="hWndParent"></param>
        /// <param name="lpEnumFunc"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "EnumChildWindows")]
        public static extern bool EnumChildWindows(IntPtr hWndParent, EnumWindowsProc lpEnumFunc,IntPtr lParam);

        /// <summary>
        /// 检索窗口工作站
        /// </summary>
        /// <param name="lpEnumFunc"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "EnumWindowStations")]
        public static extern bool EnumWindowStations(EnumWindowStationProc lpEnumFunc, IntPtr lParam);

        /// <summary>
        /// 获取当前进程窗口工作站
        /// </summary>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "GetProcessWindowStation")]
        public static extern IntPtr GetProcessWindowStation();

        /// <summary>
        /// 检索当前窗口工作站的桌面
        /// </summary>
        /// <param name="winStation"></param>
        /// <param name="lpEnumFunc"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "EnumDesktops")]
        public static extern bool EnumDesktops(IntPtr winStation, EnumDesktopProc lpEnumFunc, IntPtr lParam);

        /// <summary>
        /// 检索当前桌面的窗体
        /// </summary>
        /// <param name="desktop"></param>
        /// <param name="lpEnumFunc"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "EnumDesktopWindows")]
        public static extern bool EnumDesktopWindows(IntPtr desktop, EnumWindowsProc lpEnumFunc, IntPtr lParam);

        /// <summary>
        /// 获取桌面窗口
        /// </summary>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "GetDesktopWindow")]
        public static extern IntPtr GetDesktopWindow();

        /// <summary>
        /// 获取指定窗口对应关系的窗口，没有则为空
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="uCmd"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "GetWindow")]
        public static extern IntPtr GetWindow(IntPtr hwnd, WindowRelation uCmd);

        /// <summary>
        /// Device Context
        /// </summary>
        /// <param name="hWnd"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "GetDC", CharSet = CharSet.Unicode)]
        public static extern IntPtr GetDC(IntPtr hWnd);

        /// <summary>
        /// Device Context
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="hDC"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "ReleaseDC", CharSet = CharSet.Unicode)]
        public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Unicode)]
        public static extern int SendMessage(IntPtr hWnd,  WindowMessage Msg,  IntPtr wParam, IntPtr lParam);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nVirtKey"></param>
        /// <returns>
        /// <code>高阶位为1则按下状态，否则为抬起状态</code>
        /// <code>低阶位为1则开启状态，否则为关闭状态，如大小写锁定</code>
        /// </returns>
        [DllImport("user32.dll", EntryPoint = "GetKeyState", CharSet = CharSet.Unicode)]
        public static extern short GetKeyState(VirtualKeyCode nVirtKey);

    }
}
