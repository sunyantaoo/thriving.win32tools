namespace Thriving.Win32Tools
{
    /// <summary>
    /// Windows Hook Type
    /// </summary>
    public enum HookType:int
    {
        /// <summary>
        /// 拦截所有要发送到窗口处理函数的消息
        /// </summary>
        WH_CALLWNDPROC = 4,
        /// <summary>
        /// 拦截所有窗口处理函数已处理完成的消息
        /// </summary>
        WH_CALLWNDPROCRET = 12,
        /// <summary>
        /// 拦截窗口的activating, creating, destroying, minimizing, maximizing, moving或 sizing
        /// 拦截将要完成的系统命令
        /// 拦截将要从系统消息队列中删除鼠标或键盘事件
        /// 拦截设置输入焦点
        /// 拦截系统消息队列的同步
        /// </summary>
        WH_CBT = 5,
        /// <summary>
        /// 拦截Hook程序
        /// </summary>
        WH_DEBUG = 9,
        /// <summary>
        /// 前台线程空闲时
        /// </summary>
        WH_FOREGROUNDIDLE = 11,
        /// <summary>
        /// 拦截GetMessage()或PeekMessage()返回的消息
        /// </summary>
        WH_GETMESSAGE = 3,
        /// <summary>
        /// 检测和记录输入事件
        /// </summary>
        WH_JOURNALRECORD = 0,
        /// <summary>
        /// 重复执行已记录的输入事件
        /// </summary>
        WH_JOURNALPLAYBACK = 1,
        /// <summary>
        /// 拦截由GetMessage()或PeekMessage()返回的WM_KEYDOWN和WM_KEYUP
        /// </summary>
        WH_KEYBOARD = 2,
        /// <summary>
        /// 拦截将要推送到线程消息队列的键盘事件
        /// </summary>
        WH_KEYBOARD_LL = 13,
        /// <summary>
        /// 拦截由GetMessage()或PeekMessage()返回的鼠标事件
        /// </summary>
        WH_MOUSE = 7,
        /// <summary>
        /// 拦截将要推送到线程消息队列的鼠标事件
        /// </summary>
        WH_MOUSE_LL = 14,
        /// <summary>
        /// 仅处理安装Hook的程序
        /// 监视将由菜单、滚动条、消息框或对话框处理的消息，
        /// 检测当用户按下ALT+TAB或ALT+ESC组合键后，其他窗口的激活消息
        /// </summary>
        WH_MSGFILTER = -1,
        /// <summary>
        /// 可以处理所有程序
        /// 监视将由菜单、滚动条、消息框或对话框处理的消息，
        /// 检测当用户按下ALT+TAB或ALT+ESC组合键后，其他窗口的激活消息
        /// </summary>
        WH_SYSMSGFILTER = 6,
        /// <summary>
        /// 仅应用于系统shell程序，拦截shell程序的激活消息 
        /// 拦截顶级窗口的创建或销毁消息
        /// </summary>
        WH_SHELL = 10,
    }


    public enum HCBTCode
    {
        /// <summary>
        /// wParam为将要激活的窗体的窗体句柄Hwnd
        /// lParam为指向CBTACTIVATESTRUCT结构体的指针
        /// </summary>
        HCBT_ACTIVATE = 5,
        /// <summary>
        /// wParam为从消息队列删除的鼠标消息
        /// lParam为指向MOUSEHOOKSTRUCT结构体的指针
        /// </summary>
        HCBT_CLICKSKIPPED = 6,
        /// <summary>
        /// wParam为新创建的窗体的窗体句柄Hwnd
        /// lParam为指向CBT_CREATEWND结构体的指针
        /// </summary>
        HCBT_CREATEWND = 3,
        /// <summary>
        /// wParam为将要销毁的窗体的窗体句柄Hwnd
        /// lParam未定义，必须为0
        /// </summary>
        HCBT_DESTROYWND = 4,
        /// <summary>
        /// wParam为Virtual-Key Code
        /// lParam为重复数、扫描码、键转换码、前一个键状态和上下文码
        /// </summary>
        HCBT_KEYSKIPPED = 7,
        /// <summary>
        /// wParam为要最大或最小化的窗体的窗体句柄Hwnd
        /// lParam前两个字节表示"SW_"开头的窗体显示样式，用ShownStyle枚举表示
        /// </summary>
        HCBT_MINMAX = 1,
        /// <summary>
        /// wParam为要移动或改变大小的窗体的窗体句柄Hwnd
        /// lParam为指向窗体位置大小的Rect结构体的指针
        /// </summary>
        HCBT_MOVESIZE = 0,
        /// <summary>
        /// wParam和lParam未定义，必须为0
        /// </summary>
        HCBT_QS = 2,
        /// <summary>
        /// wParam为获取键盘焦点的窗体的窗体句柄Hwnd
        /// lParam为失去键盘焦点的窗体的窗体句柄Hwnd
        /// </summary>
        HCBT_SETFOCUS = 9,
        /// <summary>
        /// wParam和lParam可查看WM_SYSCOMMAND消息
        /// wParam为"SC_"开头的系统指令，用SysCmdType枚举表示
        /// lParam前两个字节表示X坐标，后两个字节表示Y坐标
        /// </summary>
        HCBT_SYSCOMMAND = 8,
    }

    public enum MSGOprate
    {
        PM_NOREMOVE = 0x0000,
        PM_REMOVE = 0x0001,
        PM_NOYIELD = 0x0002
    }

    public enum HookCode
    {
        /// <summary>
        /// 
        /// </summary>
        HC_ACTION = 0,
        /// <summary>
        ///The hook procedure must copy the current mouse or keyboard message to the EVENTMSG structure pointed to by the lParam parameter.
        /// </summary>
        HC_GETNEXT = 1,

        /// <summary>
        /// An application has called the PeekMessage function with wRemoveMsg set to PM_NOREMOVE, indicating that the message is not removed from the message queue after PeekMessage processing.
        /// </summary>
        HC_NOREMOVE = 3,

        /// <summary>
        /// The hook procedure must prepare to copy the next mouse or keyboard message to the EVENTMSG structure pointed to by lParam. Upon receiving the HC_GETNEXT code, the hook procedure must copy the message to the structure.
        /// </summary>
        HC_SKIP = 2,

        /// <summary>
        /// A system-modal dialog box has been destroyed. The hook procedure must resume playing back the messages.
        /// </summary>
        HC_SYSMODALOFF = 5,

        /// <summary>
        /// A system-modal dialog box is being displayed. Until the dialog box is destroyed, the hook procedure must stop playing back messages.
        /// </summary>
        HC_SYSMODALON = 4
    }

    public enum MSGSource
    {
        /// <summary>
        /// The input event occurred while the DDEML was waiting for a synchronous transaction to finish. For more information about DDEML, see Dynamic Data Exchange Management Library.
        /// </summary>
        MSGF_DDEMGR = 0x8001,

        /// <summary>
        /// The input event occurred in a message box or dialog box.
        /// </summary>
        MSGF_DIALOGBOX = 0,

        /// <summary>
        /// The input event occurred in a menu.
        /// </summary>
        MSGF_MENU = 2,

        /// <summary>
        /// The input event occurred in a scroll bar.
        /// </summary>
        MSGF_SCROLLBAR = 5
    }

    public enum HShellOprate
    {
        /// <summary>
        /// The accessibility state has changed.
        /// </summary>
        HSHELL_ACCESSIBILITYSTATE = 11,

        /// <summary>
        /// The shell should activate its main window.
        /// </summary>
        HSHELL_ACTIVATESHELLWINDOW = 3,

        /// <summary>
        /// The user completed an input event (for example, pressed an application command button on the mouse or an application command key on the keyboard), and the application did not handle the WM_APPCOMMAND message generated by that input.
        /// If the Shell procedure handles the WM_COMMAND message, it should not call CallNextHookEx. See the Return Value section for more information.
        /// </summary>
        HSHELL_APPCOMMAND = 12,

        /// <summary>
        /// A window is being minimized or maximized. The system needs the coordinates of the minimized rectangle for the window.
        /// </summary>
        HSHELL_GETMINRECT = 5,

        /// <summary>
        /// Keyboard language was changed or a new keyboard layout was loaded.
        /// </summary>
        HSHELL_LANGUAGE = 8,

        /// <summary>
        /// The title of a window in the task bar has been redrawn.
        /// </summary>
        HSHELL_REDRAW = 6,
        /// <summary>
        /// The user has selected the task list.A shell application that provides a task list should return TRUE to prevent Windows from starting its task list.
        /// </summary>
        HSHELL_TASKMAN = 7,

        /// <summary>
        /// The activation has changed to a different top-level, unowned window.
        /// </summary>
        HSHELL_WINDOWACTIVATED = 4,

        /// <summary>
        /// A top-level, unowned window has been created.The window exists when the system calls this hook.
        /// </summary>
        HSHELL_WINDOWCREATED = 1,
        /// <summary>
        /// A top-level, unowned window is about to be destroyed. The window still exists when the system calls this hook.
        /// </summary>

        HSHELL_WINDOWDESTROYED = 2,

        /// <summary>
        /// A top-level window is being replaced. The window exists when the system calls this hook.
        /// </summary>
        HSHELL_WINDOWREPLACED = 13,
    }
}
