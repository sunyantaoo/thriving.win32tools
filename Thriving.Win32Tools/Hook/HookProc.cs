using System;

namespace Thriving.Win32Tools
{
    /// <summary>
    /// WH_CALLWNDPROC类型的Hook处理函数
    /// </summary>
    /// <param name="nCode">是否必须处理该消息</param>
    /// <param name="wParam">非0时表示消息由当前进程发送</param>
    /// <param name="lParam">指向CWPSTRUCT结构体</param>
    /// <returns></returns>
    public delegate int CallWndProc(HookCode nCode, int wParam, CWPSTRUCT lParam);
    /// <summary>
    /// WH_CALLWNDPROCRET类型的Hook处理函数
    /// </summary>
    /// <param name="wParam">非0时表示消息由当前进程发送</param>
    /// <param name="lParam">指向CWPRETSTRUCT结构体</param>
    /// <returns></returns>
    public delegate int CallWndRetProc(int wParam, CWPRETSTRUCT lParam);
    /// <summary>
    /// WH_CBT 类型的Hook处理函数
    /// computer-based training (CBT) application
    /// </summary>
    /// <param name="nCode"></param>
    /// <param name="wParam"></param>
    /// <param name="lParam"></param>
    /// <returns>返回值决定系统是否允许或阻止拦截的操作</returns>
    public delegate int CBTProc(HCBTCode nCode, int wParam, IntPtr lParam);
    /// <summary>
    /// WH_DEBUG类型的Hook处理函数
    /// </summary>
    /// <param name="nCode">是否必须处理该消息</param>
    /// <param name="lParam">指向DEBUGHOOKINFO结构体</param>
    /// <returns></returns>
    public delegate int DebugProc(HookCode nCode, HookType wParam, IntPtr lParam);
    /// <summary>
    /// WH_FOREGROUNDIDLE类型的Hook处理函数
    /// </summary>
    /// <param name="nCode">是否必须处理该消息</param>
    /// <returns></returns>
    public delegate int ForegroundIdleProc(HookCode nCode);
    /// <summary>
    /// WH_GETMESSAGE类型的Hook处理函数
    /// </summary>
    /// <param name="nCode">是否必须处理该消息</param>
    /// <param name="wParam">是否从队列中移除该消息</param>
    /// <param name="lParam">指向MSG结构体</param>
    /// <returns></returns>
    public delegate int GetMsgProc(HookCode nCode, MSGOprate wParam, MSG lParam);
    /// <summary>
    /// WH_JOURNALPLAYBACK类型的Hook处理函数
    /// </summary>
    /// <param name="nCode"></param>
    /// <param name="lParam">指向EVENTMSG结构体</param>
    /// <returns></returns>
    public delegate int JournalPlaybackProc(HookCode nCode, EVENTMSG lParam);
    /// <summary>
    /// WH_JOURNALRECORD类型的Hook处理函数
    /// </summary>
    /// <param name="nCode"></param>
    /// <param name="lParam">指向EVENTMSG结构体</param>
    /// <returns></returns>
    public delegate int JournalRecordProc(HookCode nCode, EVENTMSG lParam);
    /// <summary>
    /// WH_KEYBOARD类型的Hook处理函数
    /// </summary>
    /// <param name="lParam">按位读取重复数、扫描代码、扩展键标记、上下文代码、前一个键状态标记和转换状态</param>
    /// <returns></returns>
    public delegate int KeyboardProc(HookCode nCode, VirtualKeyCode wParam, IntPtr lParam);
    /// <summary>
    /// WH_KEYBOARD_LL类型的Hook处理函数
    /// </summary>
    /// <param name="wParam">键盘消息值</param>
    /// <param name="lParam">KBDLLHOOKSTRUCT结构体</param>
    /// <returns></returns>
    public delegate int LowLevelKeyboardProc(HookCode nCode, int wParam, KBDLLHOOKSTRUCT lParam);
    /// <summary>
    /// WH_MOUSE类型的Hook处理函数
    /// </summary>
    /// <param name="wParam">鼠标消息值</param>
    /// <param name="lParam">MOUSEHOOKSTRUCT结构体</param>
    /// <returns></returns>
    public delegate int MouseProc(HookCode nCode, int wParam, MOUSEHOOKSTRUCT lParam);
    /// <summary>
    /// WH_MOUSE_LL类型的Hook处理函数
    /// </summary>
    /// <param name="wParam">鼠标消息值</param>
    /// <param name="lParam">MSLLHOOKSTRUCT结构体</param>
    /// <returns></returns>
    public delegate int LowLevelMouseProc(HookCode nCode, int wParam, MSLLHOOKSTRUCT lParam);
    /// <summary>
    /// WH_MSGFILTER类型的Hook处理函数
    /// </summary>
    /// <param name="nCode">消息源</param>
    /// <param name="lParam">MSG结构体</param>
    /// <returns></returns>
    public delegate int MessageProc(MSGSource nCode, MSG lParam);
    /// <summary>
    /// WH_SHELL类型的Hook处理函数
    /// </summary>
    /// <returns></returns>
    public delegate int ShellProc(HShellOprate nCode, int wParam, IntPtr lParam);

    /// <summary>
    /// WH_SYSMSGFILTER类型的Hook处理函数
    /// </summary>
    /// <param name="nCode">消息源</param>
    /// <param name="lParam">MSG结构体</param>
    public delegate int SysMsgProc(MSGSource nCode, MSG lParam);
}
