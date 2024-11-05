using System;
using System.Runtime.InteropServices;

namespace Thriving.Win32Tools
{
    /// <summary>
    /// gdi32.dll中的函数
    /// </summary>
    public class GDIHelper
    {
        [DllImport("gdi32.dll", EntryPoint = "SwapBuffers")]
        public static extern bool SwapBuffers(IntPtr hDC);

        [DllImport("gdi32.dll", EntryPoint = "ChoosePixelFormat")]
        public static extern int ChoosePixelFormat(IntPtr hdc, ref PixelFormatDescriptor ppfd);

        [DllImport("gdi32.dll", EntryPoint = "GetPixelFormat")]
        public static extern int GetPixelFormat(IntPtr hdc);

        [DllImport("gdi32.dll", EntryPoint = "DescribePixelFormat")]
        public static extern int DescribePixelFormat(IntPtr hdc, int iPixelFormat, uint nBytes, IntPtr ppfd);

        [DllImport("gdi32.dll", EntryPoint = "SetPixelFormat")]
        public static extern bool SetPixelFormat(IntPtr hdc, int format, ref PixelFormatDescriptor ppfd);
    }
}
