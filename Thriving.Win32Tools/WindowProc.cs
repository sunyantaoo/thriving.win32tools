using System;

namespace Thriving.Win32Tools
{
    /// <summary>
    /// 枚举窗体处理函数
    /// </summary>
    /// <param name="hwnd"></param>
    /// <param name="lParam"></param>
    /// <returns>返回true则继续检索，flase则停止检索</returns>
    public delegate bool EnumWindowsProc(IntPtr hwnd, IntPtr lParam);

    /// <summary>
    /// 枚举窗口站处理程序
    /// </summary>
    /// <param name="winStation"></param>
    /// <param name="lParam"></param>
    /// <returns></returns>
    public delegate bool EnumWindowStationProc(IntPtr winStation, IntPtr lParam);
    
    /// <summary>
    /// 枚举桌面处理函数
    /// </summary>
    /// <param name="desktop"></param>
    /// <param name="lParam"></param>
    /// <returns></returns>
    public delegate bool EnumDesktopProc(IntPtr desktop, IntPtr lParam);

    /// <summary>
    /// 窗口处理函数
    /// </summary>
    /// <param name="hwnd">窗体句柄</param>
    /// <param name="uMsg">消息ID</param>
    /// <param name="wParam"></param>
    /// <param name="lParam"></param>
    /// <returns></returns>
    public delegate IntPtr WindowProc(IntPtr hwnd, WindowMessage uMsg, IntPtr wParam, IntPtr lParam);
}
