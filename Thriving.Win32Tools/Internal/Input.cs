using System.Runtime.InteropServices;

namespace Thriving.Win32Tools.Internal
{
    [StructLayout(LayoutKind.Explicit,Size =40)]
    internal struct Input
    {
        [FieldOffset(0)]
        public InputType InputType;
        [FieldOffset(8)]
        public MouseInput MouseInput;
        [FieldOffset(8)]
        public KeyboardInput KeyboardInput;
        [FieldOffset(8)]
        public HardwareInput HardwardInput;
    }
}
