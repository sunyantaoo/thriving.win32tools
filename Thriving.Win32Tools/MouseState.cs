namespace Thriving.Win32Tools
{
    public enum MouseState
    {
        /// <summary>
        /// 按下了 CTRL 键
        /// </summary>
        MK_CONTROL = 0x0008,
        /// <summary>
        /// 按下了鼠标左键
        /// </summary>
        MK_LBUTTON = 0x0001,
        /// <summary>
        /// 按下了鼠标中键
        /// </summary>
        MK_MBUTTON = 0x0010,
        /// <summary>
        /// 按下了鼠标右键
        /// </summary>
        MK_RBUTTON = 0x0002,
        /// <summary>
        /// 按下了 SHIFT 键
        /// </summary>
        MK_SHIFT = 0x0004,
        /// <summary>
        /// 按下了第一个 X 按钮
        /// </summary>
        MK_XBUTTON1 = 0x0020,
        /// <summary>
        /// 按下了第二个 X 按钮
        /// </summary>
        MK_XBUTTON2 = 0x0040,
    }
}
