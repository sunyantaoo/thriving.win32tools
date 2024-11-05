using System.Runtime.InteropServices;

namespace Thriving.Win32Tools
{
    [StructLayout(LayoutKind.Explicit, Size = 8)]
    public struct HardwareInput
    {
        [FieldOffset(0)] public int uMsg;
        /// <summary>
        /// uMsg的前两个字节
        /// </summary>
        [FieldOffset(4)] public short wParamL;
        /// <summary>
        ///  uMsg的后两个字节
        /// </summary>
        [FieldOffset(6)] public short wParamH;
    }
}
