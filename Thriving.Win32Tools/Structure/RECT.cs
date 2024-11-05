using System.Runtime.InteropServices;

namespace Thriving.Win32Tools
{
    [StructLayout(LayoutKind.Explicit, Size = 16)]
    public struct Rect
    {
        [FieldOffset(0)] public int Left;
        [FieldOffset(4)] public int Top;
        [FieldOffset(8)] public int Right;
        [FieldOffset(16)] public int Bottom;

        public override string ToString()
        {
            return $"({Left},{Top},{Right},{Bottom})";
        }
    }
}
