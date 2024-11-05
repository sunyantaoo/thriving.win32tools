using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thriving.Win32Tools
{
    /// <summary>
    /// 窗口基础样式
    /// </summary>
    [Flags]
    public enum WindowClassStyle
    {
        /// <summary>
        /// Aligns the window's client area on a byte boundary (in the x direction). This style affects the width of the window and its horizontal placement on the display.
        /// </summary>
        CS_BYTEALIGNCLIENT = 0x1000,
        /// <summary>
        /// Aligns the window on a byte boundary (in the x direction). This style affects the width of the window and its horizontal placement on the display.
        /// </summary>
        CS_BYTEALIGNWINDOW = 0x2000,
        /// <summary>
        /// Allocates one device context to be shared by all windows in the class. Because window classes are process specific, it is possible for multiple threads of an application to create a window of the same class. It is also possible for the threads to attempt to use the device context simultaneously.When this happens, the system allows only one thread to successfully finish its drawing operation.
        /// </summary>
        CS_CLASSDC = 0x0040,
        /// <summary>
        /// Sends a double-click message to the window procedure when the user double-clicks the mouse while the cursor is within a window belonging to the class.
        /// </summary>
        CS_DBLCLKS = 0x0008,
        /// <summary>
        /// Enables the drop shadow effect on a window.The effect is turned on and off through SPI_SETDROPSHADOW. Typically, this is enabled for small, short-lived windows such as menus to emphasize their Z-order relationship to other windows.Windows created from a class with this style must be top-level windows; they may not be child windows.
        /// </summary>
        CS_DROPSHADOW = 0x00020000,
        /// <summary>
        /// Indicates that the window class is an application global class. For more information, see the "Application Global Classes" section of About Window Classes.
        /// </summary>
        CS_GLOBALCLASS = 0x4000,
        /// <summary>
        /// Redraws the entire window if a movement or size adjustment changes the width of the client area.
        /// </summary>
        CS_HREDRAW = 0x0002,
        /// <summary>
        /// Disables Close on the window menu.
        /// </summary>
        CS_NOCLOSE = 0x0200,
        /// <summary>
        /// Allocates a unique device context for each window in the class.
        /// </summary>
        CS_OWNDC = 0x0020,
        /// <summary>
        /// Sets the clipping rectangle of the child window to that of the parent window so that the child can draw on the parent.A window with the CS_PARENTDC style bit receives a regular device context from the system's cache of device contexts. It does not give the child the parent's device context or device context settings.Specifying CS_PARENTDC enhances an application's performance.
        /// </summary>
        CS_PARENTDC = 0x0080,
        /// <summary>
        /// Saves, as a bitmap, the portion of the screen image obscured by a window of this class. When the window is removed, the system uses the saved bitmap to restore the screen image, including other windows that were obscured.Therefore, the system does not send WM_PAINT messages to windows that were obscured if the memory used by the bitmap has not been discarded and if other screen actions have not invalidated the stored image.
        /// This style is useful for small windows (for example, menus or dialog boxes) that are displayed briefly and then removed before other screen activity takes place.This style increases the time required to display the window, because the system must first allocate memory to store the bitmap.
        /// </summary>
        CS_SAVEBITS = 0x0800,
        /// <summary>
        /// Redraws the entire window if a movement or size adjustment changes the height of the client area.
        /// </summary>
        CS_VREDRAW = 0x0001,
    }

    /// <summary>
    /// 窗口基础样式
    /// </summary>
    [Flags]
    public enum WindowStyle : long
    {
        /// <summary>
        /// The window has a thin-line border.
        /// </summary>
        WS_BORDER = 0x00800000L,
        /// <summary>
        /// The window has a title bar (includes the WS_BORDER style).
        /// </summary>
        WS_CAPTION = 0x00C00000L,
        /// <summary>
        /// The window is a child window. A window with this style cannot have a menu bar. This style cannot be used with the WS_POPUP style.
        /// </summary>
        WS_CHILD = 0x40000000L,
        /// <summary>
        /// Same as the WS_CHILD style.
        /// </summary>
        WS_CHILDWINDOW = 0x40000000L,
        /// <summary>
        /// Excludes the area occupied by child windows when drawing occurs within the parent window. This style is used when creating the parent window.
        /// </summary>
        WS_CLIPCHILDREN = 0x02000000L,
        /// <summary>
        /// Clips child windows relative to each other; that is, when a particular child window receives a WM_PAINT message, the WS_CLIPSIBLINGS style clips all other overlapping child windows out of the region of the child window to be updated. If WS_CLIPSIBLINGS is not specified and child windows overlap, it is possible, when drawing within the client area of a child window, to draw within the client area of a neighboring child window.
        /// </summary>
        WS_CLIPSIBLINGS = 0x04000000L,
        /// <summary>
        /// The window is initially disabled. A disabled window cannot receive input from the user. To change this after a window has been created, use the EnableWindow function.
        /// </summary>
        WS_DISABLED = 0x08000000L,
        /// <summary>
        /// The window has a border of a style typically used with dialog boxes. A window with this style cannot have a title bar.
        /// </summary>
        WS_DLGFRAME = 0x00400000L,
        /// <summary>
        /// The window is the first control of a group of controls. The group consists of this first control and all controls defined after it, up to the next control with the WS_GROUP style. The first control in each group usually has the WS_TABSTOP style so that the user can move from group to group. The user can subsequently change the keyboard focus from one control in the group to the next control in the group by using the direction keys.
        ///  You can turn this style on and off to change dialog box navigation.To change this style after a window has been created, use the SetWindowLong function.
        /// </summary>
        WS_GROUP = 0x00020000L,
        /// <summary>
        /// The window has a horizontal scroll bar.
        /// </summary>
        WS_HSCROLL = 0x00100000L,
        /// <summary>
        /// The window is initially minimized. Same as the WS_MINIMIZE style.
        /// </summary>
        WS_ICONIC = 0x20000000L,
        /// <summary>
        /// The window is initially maximized.
        /// </summary>
        WS_MAXIMIZE = 0x01000000L,
        /// <summary>
        /// The window has a maximize button. Cannot be combined with the WS_EX_CONTEXTHELP style.The WS_SYSMENU style must also be specified.
        /// </summary>
        WS_MAXIMIZEBOX = 0x00010000L,
        /// <summary>
        /// The window is initially minimized. Same as the WS_ICONIC style.
        /// </summary>
        WS_MINIMIZE = 0x20000000L,
        /// <summary>
        ///     The window has a minimize button. Cannot be combined with the WS_EX_CONTEXTHELP style.The WS_SYSMENU style must also be specified.
        /// </summary>
        WS_MINIMIZEBOX = 0x00020000L,
        /// <summary>
        /// The window is an overlapped window.An overlapped window has a title bar and a border. Same as the WS_TILED style.
        /// </summary>
        WS_OVERLAPPED = 0x00000000L,
        /// <summary>
        /// (WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX)
        ///   The window is an overlapped window.Same as the WS_TILEDWINDOW style.
        /// </summary>
        WS_OVERLAPPEDWINDOW = (WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX),
        /// <summary>
        /// The window is a pop-up window.This style cannot be used with the WS_CHILD style.
        /// </summary>
        WS_POPUP = 0x80000000L,
        /// <summary>
        /// (WS_POPUP | WS_BORDER | WS_SYSMENU)
        ///   The window is a pop-up window.The WS_CAPTION and WS_POPUPWINDOW styles must be combined to make the window menu visible.
        /// </summary>
        WS_POPUPWINDOW = (WS_POPUP | WS_BORDER | WS_SYSMENU),
        /// <summary>
        /// The window has a sizing border. Same as the WS_THICKFRAME style.
        /// </summary>
        WS_SIZEBOX = 0x00040000L,
        /// <summary>
        /// The window has a window menu on its title bar. The WS_CAPTION style must also be specified.
        /// </summary>
        WS_SYSMENU = 0x00080000L,
        /// <summary>
        /// The window is a control that can receive the keyboard focus when the user presses the TAB key.Pressing the TAB key changes the keyboard focus to the next control with the WS_TABSTOP style.
        ///  You can turn this style on and off to change dialog box navigation.To change this style after a window has been created, use the SetWindowLong function. For user-created windows and modeless dialogs to work with tab stops, alter the message loop to call the IsDialogMessage function.
        /// </summary>
        WS_TABSTOP = 0x00010000L,
        /// <summary>
        /// The window has a sizing border. Same as the WS_SIZEBOX style.
        /// </summary>
        WS_THICKFRAME = 0x00040000L,
        /// <summary>
        /// The window is an overlapped window.An overlapped window has a title bar and a border. Same as the WS_OVERLAPPED style.
        /// </summary>
        WS_TILED = 0x00000000L,
        /// <summary>
        /// (WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX)
        /// The window is an overlapped window.Same as the WS_OVERLAPPEDWINDOW style.
        /// </summary>
        WS_TILEDWINDOW = (WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX),
        /// <summary>
        /// The window is initially visible.
        ///  This style can be turned on and off by using the ShowWindow or SetWindowPos function.
        /// </summary>
        WS_VISIBLE = 0x10000000L,
        /// <summary>
        /// The window has a vertical scroll bar.
        /// </summary>
        WS_VSCROLL = 0x00200000L,
    }


    /// <summary>
    /// 窗口扩展样式
    /// </summary>
    [Flags]
    public enum WindowExtentedStyle : long
    {
        /// <summary>
        /// The window accepts drag-drop files.
        /// </summary>
        WS_EX_ACCEPTFILES = 0x00000010L,
        /// <summary>
        /// Forces a top-level window onto the taskbar when the window is visible.
        /// </summary>
        WS_EX_APPWINDOW = 0x00040000L,
        /// <summary>
        /// The window has a border with a sunken edge.
        /// </summary>
        WS_EX_CLIENTEDGE = 0x00000200L,
        /// <summary>
        /// Paints all descendants of a window in bottom-to-top painting order using double-buffering.Bottom-to-top painting order allows a descendent window to have translucency(alpha) and transparency(color-key) effects, but only if the descendent window also has the WS_EX_TRANSPARENT bit set.Double-buffering allows the window and its descendents to be painted without flicker.This cannot be used if the window has a class style of either CS_OWNDC or CS_CLASSDC.
        /// Windows 2000: This style is not supported.
        /// </summary>
        WS_EX_COMPOSITED = 0x02000000L,
        /// <summary>
        /// The title bar of the window includes a question mark. When the user clicks the question mark, the cursor changes to a question mark with a pointer. If the user then clicks a child window, the child receives a WM_HELP message. The child window should pass the message to the parent window procedure, which should call the WinHelp function using the HELP_WM_HELP command.The Help application displays a pop-up window that typically contains help for the child window.
        /// WS_EX_CONTEXTHELP cannot be used with the WS_MAXIMIZEBOX or WS_MINIMIZEBOX styles.
        /// </summary>

        WS_EX_CONTEXTHELP = 0x00000400L,

        /// <summary>
        /// The window itself contains child windows that should take part in dialog box navigation.If this style is specified, the dialog manager recurses into children of this window when performing navigation operations such as handling the TAB key, an arrow key, or a keyboard mnemonic.
        /// </summary>
        WS_EX_CONTROLPARENT = 0x00010000L,
        /// <summary>
        ///    The window has a double border; the window can, optionally, be created with a title bar by specifying the WS_CAPTION style in the dwStyle parameter.
        /// </summary>
        WS_EX_DLGMODALFRAME = 0x00000001L,
        /// <summary>
        /// The window is a layered window.This style cannot be used if the window has a class style of either CS_OWNDC or CS_CLASSDC.
        /// Windows 8: The WS_EX_LAYERED style is supported for top-level windows and child windows.Previous Windows versions support WS_EX_LAYERED only for top-level windows.
        /// </summary>
        WS_EX_LAYERED = 0x00080000L,
        /// <summary>
        /// If the shell language is Hebrew, Arabic, or another language that supports reading order alignment, the horizontal origin of the window is on the right edge. Increasing horizontal values advance to the left.
        /// </summary>
        WS_EX_LAYOUTRTL = 0x00400000L,
        /// <summary>
        /// The window has generic left-aligned properties. This is the default.
        /// </summary>
        WS_EX_LEFT = 0x00000000L,
        /// <summary>
        /// If the shell language is Hebrew, Arabic, or another language that supports reading order alignment, the vertical scroll bar (if present) is to the left of the client area.For other languages, the style is ignored.
        /// </summary>
        WS_EX_LEFTSCROLLBAR = 0x00004000L,
        /// <summary>
        /// The window text is displayed using left-to-right reading-order properties.This is the default.
        /// </summary>
        WS_EX_LTRREADING = 0x00000000L,
        /// <summary>
        ///The window is a MDI child window.
        /// </summary>
        WS_EX_MDICHILD = 0x00000040L,
        /// <summary>
        /// A top-level window created with this style does not become the foreground window when the user clicks it. The system does not bring this window to the foreground when the user minimizes or closes the foreground window.
        /// The window should not be activated through programmatic access or via keyboard navigation by accessible technology, such as Narrator.
        ///To activate the window, use the SetActiveWindow or SetForegroundWindow function.
        ///The window does not appear on the taskbar by default. To force the window to appear on the taskbar, use the WS_EX_APPWINDOW style.
        /// </summary>
        WS_EX_NOACTIVATE = 0x08000000L,
        /// <summary>
        /// The window does not pass its window layout to its child windows.
        /// </summary>
        WS_EX_NOINHERITLAYOUT = 0x00100000L,
        /// <summary>
        ///The child window created with this style does not send the WM_PARENTNOTIFY message to its parent window when it is created or destroyed.
        /// </summary>
        WS_EX_NOPARENTNOTIFY = 0x00000004L,
        /// <summary>
        /// The window does not render to a redirection surface.This is for windows that do not have visible content or that use mechanisms other than surfaces to provide their visual.
        WS_EX_OVERLAPPEDWINDOW = (WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE),
        ///The window is an overlapped window.
        WS_EX_PALETTEWINDOW = (WS_EX_WINDOWEDGE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST),
        ///The window is palette window, which is a modeless dialog box that presents an array of commands.
        /// </summary>
        WS_EX_NOREDIRECTIONBITMAP = 0x00200000L,
        /// <summary>
        /// The window has generic "right-aligned" properties.This depends on the window class. This style has an effect only if the shell language is Hebrew, Arabic, or another language that supports reading-order alignment; otherwise, the style is ignored.
        ///   Using the WS_EX_RIGHT style for static or edit controls has the same effect as using the SS_RIGHT or ES_RIGHT style, respectively. Using this style with button controls has the same effect as using BS_RIGHT and BS_RIGHTBUTTON styles.
        /// </summary>

        WS_EX_RIGHT = 0x00001000L,
        /// <summary>
        /// The vertical scroll bar(if present) is to the right of the client area.This is the default.
        /// </summary>
        WS_EX_RIGHTSCROLLBAR = 0x00000000L,
        /// <summary>
        /// If the shell language is Hebrew, Arabic, or another language that supports reading-order alignment, the window text is displayed using right-to-left reading-order properties.For other languages, the style is ignored.
        /// </summary>
        WS_EX_RTLREADING = 0x00002000L,
        /// <summary>
        /// The window has a three-dimensional border style intended to be used for items that do not accept user input.
        /// </summary>
        WS_EX_STATICEDGE = 0x00020000L,
        /// <summary>
        /// The window is intended to be used as a floating toolbar.A tool window has a title bar that is shorter than a normal title bar, and the window title is drawn using a smaller font.A tool window does not appear in the taskbar or in the dialog that appears when the user presses ALT+TAB.If a tool window has a system menu, its icon is not displayed on the title bar. However, you can display the system menu by right-clicking or by typing ALT+SPACE.
        /// </summary>
        WS_EX_TOOLWINDOW = 0x00000080L,
        /// <summary>
        /// The window should be placed above all non-topmost windows and should stay above them, even when the window is deactivated.To add or remove this style, use the SetWindowPos function.
        /// </summary>
        WS_EX_TOPMOST = 0x00000008L,
        /// <summary>
        /// The window should not be painted until siblings beneath the window (that were created by the same thread) have been painted.The window appears transparent because the bits of underlying sibling windows have already been painted.
        /// To achieve transparency without these restrictions, use the SetWindowRgn function.
        /// </summary>
        WS_EX_TRANSPARENT = 0x00000020L,
        /// <summary>
        /// The window has a border with a raised edge.
        /// </summary>
        WS_EX_WINDOWEDGE = 0x00000100L,
    }

    /// <summary>
    /// MessageBox样式
    /// </summary>
    [Flags]
    public enum MessageBoxStyle:long
    {
        /// <summary>
        /// 含一个Ok按钮
        /// </summary>
        MB_OK = 0x00000000L,
        /// <summary>
        /// 含Ok和Cancel按钮
        /// </summary>
        MB_OKCANCEL = 0x00000001L,
        /// <summary>
        /// 含Abort、Retry和Ignore按钮
        /// </summary>
        MB_ABORTRETRYIGNORE = 0x00000002L,
        /// <summary>
        /// 含Yes、No和Cancel按钮
        /// </summary>
        MB_YESNOCANCEL = 0x00000003L,
        /// <summary>
        /// 含Yes和No按钮
        /// </summary>
        MB_YESNO = 0x00000004L,
        /// <summary>
        /// 含Retry和Cancel按钮
        /// </summary>
        MB_RETRYCANCEL = 0x00000005L,
        /// <summary>
        /// 含Cancel、Try Again和Continue按钮
        /// </summary>
        MB_CANCELTRYCONTINUE = 0x00000006L,

        /// <summary>
        /// 停止图标
        /// </summary>
        MB_ICONHAND = 0x00000010L,
        /// <summary>
        /// 疑问图标
        /// </summary>
        MB_ICONQUESTION = 0x00000020L,
        /// <summary>
        /// 感叹号图标
        /// </summary>
        MB_ICONEXCLAMATION = 0x00000030L,
        /// <summary>
        /// 消息图标
        /// </summary>
        MB_ICONASTERISK = 0x00000040L,

        MB_USERICON = 0x00000080L,
        //MB_ICONWARNING MB_ICONEXCLAMATION
        //MB_ICONERROR MB_ICONHAND
        //MB_ICONINFORMATION MB_ICONASTERISK
        //MB_ICONSTOP MB_ICONHAND

        /// <summary>
        /// 第一个按钮为默认选项
        /// </summary>
        MB_DEFBUTTON1 = 0x00000000L,
        /// <summary>
        /// 第二个按钮为默认选项
        /// </summary>
        MB_DEFBUTTON2 = 0x00000100L,
        /// <summary>
        /// 第三个按钮为默认选项
        /// </summary>
        MB_DEFBUTTON3 = 0x00000200L,
        /// <summary>
        /// 第四个按钮为默认选项
        /// </summary>
        MB_DEFBUTTON4 = 0x00000300L,

        /// <summary>
        /// 模态窗体，不阻止线程执行
        /// </summary>
        MB_APPLMODAL = 0x00000000L,
        /// <summary>
        /// 模态窗体，
        /// </summary>
        MB_SYSTEMMODAL = 0x00001000L,
        /// <summary>
        /// 模态窗体，
        /// </summary>
        MB_TASKMODAL = 0x00002000L,
        /// <summary>
        /// 添加帮助按钮，用户点击或按F1键则向父窗体发送一个WM_HELP消息
        /// </summary>
        MB_HELP = 0x00004000L,
        /// <summary>
        /// 
        /// </summary>
        MB_NOFOCUS = 0x00008000L,
        /// <summary>
        /// 
        /// </summary>
        MB_SETFOREGROUND = 0x00010000L,
        MB_DEFAULT_DESKTOP_ONLY = 0x00020000L,
        /// <summary>
        /// 总在最前
        /// </summary>
        MB_TOPMOST = 0x00040000L,
        /// <summary>
        /// 消息文本右对其
        /// </summary>
        MB_RIGHT = 0x00080000L,
        MB_RTLREADING = 0x00100000L,
        MB_SERVICE_NOTIFICATION = 0x00200000L,
        MB_SERVICE_NOTIFICATION_NT3X = 0x00040000L,
        MB_TYPEMASK = 0x0000000FL,
        MB_ICONMASK = 0x000000F0L,
        MB_DEFMASK = 0x00000F00L,
        MB_MODEMASK = 0x00003000L,
        MB_MISCMASK = 0x0000C000L,
    }

    /// <summary>
    /// MessageBox返回结果
    /// </summary>
    public enum MessageBoxResult
    {
        Ok = 1,
        Cancel = 2,
        Abort = 3,
        Retry = 4,
        Ignore = 5,
        Yes = 6,
        No = 7,
        TryAgain = 10,
        Continue = 11,
    }

    /// <summary>
    /// 窗体关系
    /// </summary>
    public enum WindowRelation
    {
        GW_HWNDFIRST = 0,
        GW_HWNDLAST = 1,
        GW_HWNDNEXT = 2,
        GW_HWNDPREV = 3,
        GW_OWNER = 4,
        GW_CHILD = 5,
        GW_ENABLEDPOPUP = 6,
    }

    public enum ShownStyle
    {
        /// <summary>
        /// 隐藏窗口并激活另一个窗口
        /// </summary>
        SW_HIDE = 0,
        /// <summary>
        /// 激活并显示窗口
        /// </summary>
        SW_NORMAL = 1,
        /// <summary>
        /// 激活窗口最小化显示
        /// </summary>
        SW_MINIMIZED = 2,
        /// <summary>
        /// 激活窗口最大化显示
        /// </summary>
        SW_MAXIMIZED = 3,
        /// <summary>
        /// 显示窗口不激活
        /// </summary>
        SW_SHOWNOACTIVATE = 4,
        /// <summary>
        /// 激活窗口在当前位置显示
        /// </summary>
        SW_SHOW = 5,
        /// <summary>
        /// 最小化窗口并激活下一个窗口
        /// </summary>
        SW_MINIMIZE = 6,
        /// <summary>
        /// 最小化显示不激活
        /// </summary>
        SW_SHOWMINNOACTIVE = 7,
        /// <summary>
        /// 显示窗口在当前位置，不激活
        /// </summary>
        SW_SHOWNA = 8,
        /// <summary>
        /// 激活并显示窗口
        /// </summary>
        SW_RESTORE = 9,
        /// <summary>
        /// 初始设定的默认方式显示
        /// </summary>
        SW_SHOWDEFAULT = 10,
        /// <summary>
        /// 强制最小化
        /// </summary>
        SW_FORCEMINIMIZE = 11,
    }


    public enum WindowPosStyle
    {
        SWP_ASYNCWINDOWPOS = 0x4000,
        SWP_DEFERERASE = 0x2000,
        SWP_DRAWFRAME = 0x0020,
        SWP_FRAMECHANGED = 0x0020,
        SWP_HIDEWINDOW = 0x0080,
        SWP_NOACTIVATE = 0x0010,
        SWP_NOCOPYBITS = 0x0100,
        SWP_NOMOVE = 0x0002,
        SWP_NOOWNERZORDER = 0x0200,
        SWP_NOREDRAW = 0x0008,
        SWP_NOREPOSITION = 0x0200,
        SWP_NOSENDCHANGING = 0x0400,
        SWP_NOSIZE = 0x0001,
        SWP_NOZORDER = 0x0004,
        SWP_SHOWWINDOW = 0x0040,
    }

    public enum WindowLongType
    {
        /// <summary>
        /// 窗口扩展样式
        /// </summary>
        EXSTYLE = -20,
        /// <summary>
        /// 程序实例句柄
        /// </summary>
        HINSTANCE = -6,
        /// <summary>
        /// 父窗口句柄(只读)
        /// </summary>
        HWNDPARENT = -8,
        /// <summary>
        /// 子窗口的ID
        /// </summary>
        ID = -12,
        /// <summary>
        /// 窗口样式
        /// </summary>
        STYLE = -16,
        /// <summary>
        /// 窗口管理的用户数据，初始值为0
        /// </summary>
        USERDATA = -21,
        /// <summary>
        /// 窗口处理函数
        /// </summary>
        WNDPROC = -4,
    }

    /// <summary>
    /// WM_SYSCOMMAND时wParam对应的值
    /// </summary>
    public enum SysCmdType 
    {
        /// <summary>
        /// 关闭窗体
        /// </summary>
        SC_CLOSE = 0xF060,
        /// <summary>
        /// Changes the cursor to a question mark with a pointer. If the user then clicks a control in the dialog box, the control receives a WM_HELP message.
        /// </summary>
        SC_CONTEXTHELP = 0xF180,
        /// <summary>
        /// Selects the default item; the user double-clicked the window menu.
        /// </summary>
        SC_DEFAULT = 0xF160,
        /// <summary>
        /// Activates the window associated with the application-specified hot key. The lParam parameter identifies the window to activate.
        /// </summary>
        SC_HOTKEY = 0xF150,
        /// <summary>
        /// 水平滚动
        /// </summary>
        SC_HSCROLL = 0xF080,
        /// <summary>
        /// 屏幕保护程序是否安全
        /// </summary>
        SCF_ISSECURE = 0x00000001,
        /// <summary>
        /// 检索按键点击后的窗体菜单
        /// </summary>
        SC_KEYMENU = 0xF100,
        /// <summary>
        /// 最大化窗体
        /// </summary>
        SC_MAXIMIZE = 0xF030,
        /// <summary>
        /// 最小化窗体
        /// </summary>
        SC_MINIMIZE = 0xF020,
        ///Sets the state of the display. This command supports devices that have power-saving features, such as a battery-powered personal computer.
        ///The lParam parameter can have the following values:
        ///-1 (the display is powering on)
        ///1 (the display is going to low power)
        ///2 (the display is being shut off)
        SC_MONITORPOWER = 0xF170,

        /// <summary>
        /// 检索鼠标点击后的窗体菜单
        /// </summary>
        SC_MOUSEMENU = 0xF090,
        /// <summary>
        /// 移动窗体
        /// </summary>
        SC_MOVE = 0xF010,
        /// <summary>
        /// 移动到下一个窗体
        /// </summary>
        SC_NEXTWINDOW = 0xF040,
        /// <summary>
        /// 移动到上一个窗体
        /// </summary>
        SC_PREVWINDOW = 0xF050,
        /// <summary>
        /// 恢复窗体的正常位置及尺寸
        /// </summary>
        SC_RESTORE = 0xF120,
        /// <summary>
        /// Executes the screen saver application specified in the [boot] section of the System.ini file.
        /// </summary>
        SC_SCREENSAVE = 0xF140,
        /// <summary>
        /// 更改窗体尺寸
        /// </summary>
        SC_SIZE = 0xF000,
        /// <summary>
        /// 激活开始按钮
        /// </summary>
        SC_TASKLIST = 0xF130,
        /// <summary>
        /// 垂直滚动
        /// </summary>
        SC_VSCROLL = 0xF070,

    }
}
