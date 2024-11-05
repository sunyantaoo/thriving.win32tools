namespace Thriving.Win32Tools
{
    public struct PixelFormatDescriptor
    {
        /// <summary>
        /// 当前结构体大小
        /// </summary>
        public short nSize;
        /// <summary>
        /// 此数据结构的版本。 此值应设置为 1。
        /// </summary>
        public short nVersion;
        /// <summary>
        /// <see cref="PixelBufferProperty"/>
        /// </summary>
        public int dwFlags;
        /// <summary>
        /// 像素数据的类型
        /// </summary>
        public PixelType iPixelType;
        /// <summary>
        /// 每个颜色缓冲区中的颜色位平面数。
        /// 对于 RGBA 像素类型，它是颜色缓冲区的大小，不包括 alpha 位平面。 
        /// 对于颜色索引像素，它是颜色索引缓冲区的大小。
        /// </summary>
        public byte cColorBits;
        /// <summary>
        /// 每个 RGBA 颜色缓冲区中的红色位平面数
        /// </summary>
        public byte cRedBits;
        /// <summary>
        /// 每个 RGBA 颜色缓冲区中红色位平面的移位计数
        /// </summary>
        public byte cRedShift;
        /// <summary>
        /// 每个 RGBA 颜色缓冲区中的绿色位平面数
        /// </summary>
        public byte cGreenBits;
        /// <summary>
        /// 每个 RGBA 颜色缓冲区中绿色位平面的移位计数
        /// </summary>
        public byte cGreenShift;
        /// <summary>
        /// 每个 RGBA 颜色缓冲区中的蓝色位平面数
        /// </summary>
        public byte cBlueBits;
        /// <summary>
        /// 每个 RGBA 颜色缓冲区中蓝色位平面的移位计数
        /// </summary>
        public byte cBlueShift;
        /// <summary>
        /// 每个 RGBA 颜色缓冲区中的 alpha 位平面数
        /// </summary>
        public byte cAlphaBits;
        /// <summary>
        /// 每个 RGBA 颜色缓冲区中 alpha 位平面的移位计数
        /// </summary>
        public byte cAlphaShift;
        /// <summary>
        /// 累积缓冲区中的位平面总数
        /// </summary>
        public byte cAccumBits;
        /// <summary>
        /// 累积缓冲区中的红色位平面数
        /// </summary>
        public byte cAccumRedBits;
        /// <summary>
        /// 积缓冲区中的绿色位平面数
        /// </summary>
        public byte cAccumGreenBits;
        /// <summary>
        /// 累积缓冲区中的蓝色位平面数
        /// </summary>
        public byte cAccumBlueBits;
        /// <summary>
        /// 累积缓冲区中的 alpha 位平面数
        /// </summary>
        public byte cAccumAlphaBits;
        /// <summary>
        ///  深度缓冲区
        /// </summary>
        public byte cDepthBits;
        /// <summary>
        /// 模板缓冲区的深度
        /// </summary>
        public byte cStencilBits;
        /// <summary>
        /// 辅助缓冲区
        /// </summary>
        public byte cAuxBuffers;
        /// <summary>
        /// 已忽略
        /// </summary>
        public byte iLayerType;
        /// <summary>
        /// 覆盖平面和底层平面的数目
        /// </summary>
        public byte bReserved;
        /// <summary>
        /// 已忽略
        /// </summary>
        public int dwLayerMask;
        /// <summary>
        /// 
        /// </summary>
        public int dwVisibleMask;
        /// <summary>
        /// 已忽略
        /// </summary>
        public int dwDamageMask;
    }
}
