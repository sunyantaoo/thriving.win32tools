using System.Runtime.InteropServices;

namespace Thriving.Win32Tools
{
    [StructLayout(LayoutKind.Explicit, Size = 44)]
    public struct WINDOWPLACEMENT
    {
        [FieldOffset(0)] public int length;
        [FieldOffset(4)] public int flags;
        [FieldOffset(8)] public int showCmd;
        [FieldOffset(12)] public int ptMinPosition_X;
        [FieldOffset(16)] public int ptMinPosition_Y;
        [FieldOffset(20)] public int ptMaxPosition_X;
        [FieldOffset(24)] public int ptMaxPosition_Y;
        [FieldOffset(28)] public Rect rcNormalPosition;
        // MAC
        // public Rect rcDevice;
    }
}
