using System.Linq;
using System.Runtime.InteropServices;

namespace Thriving.Win32Tools
{
    public class InputHelper
    {
        public static int SendInput(InputArray inputArray)
        {
            var size = inputArray.Count();
            var array = inputArray.ToArray();
            var bsize = Marshal.SizeOf<Internal.Input>();
            return SendInput(size, array, bsize);
        }

        /// <summary>
        /// 向系统发送输入消息
        /// </summary>
        /// <param name="nInputs">Input结构体数组的个数</param>
        /// <param name="pInputs">Input结构体数组</param>
        /// <param name="cbSize">Input结构体的字节大小</param>
        /// <returns>返回模拟成功的个数</returns>
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern int SendInput(int nInputs,Internal.Input[] pInputs, int cbSize);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern VirtualKeyEvent GetAsyncKeyState(VirtualKeyCode vKey);
    }
}
