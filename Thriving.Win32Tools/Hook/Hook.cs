using System;
using System.Runtime.InteropServices;

namespace Thriving.Win32Tools
{
    public abstract class Hook
    {
        internal delegate int HookProc(int nCode, int wParam, IntPtr lParam);

        internal HookProc _hookProc;
        internal HookType _hookType;
        protected internal IntPtr _hookid = IntPtr.Zero;


        #region 拦截器拦截的消息
        protected internal int _nCode;
        protected internal int _wParam;
        protected internal IntPtr _lParam;
        #endregion

        /// <summary>
        /// 启用拦截器
        /// </summary>
        /// <param name="hMod"></param>
        /// <param name="threadId"></param>
        /// <returns></returns>
        public bool Set()
        {
            var threadId = KernelHelper.GetCurrentThreadId();

            _hookid = SetWindowsHookEx(_hookType, _hookProc, IntPtr.Zero, threadId);
            return _hookid != IntPtr.Zero;
        }

        protected abstract int HookMethod(int nCode, int wParam, IntPtr lParam);

        /// <summary>
        /// 卸载拦截器
        /// </summary>
        /// <returns></returns>
        public bool UnHook()
        {
            return UnhookWindowsHookEx(_hookid);
        }
        /// <summary>
        /// 继续执行消息流程
        /// </summary>
        /// <returns></returns>
        public int CallNext()
        {
            return CallNextHookEx(_hookid, _nCode, _wParam, _lParam);
        }

        /// <summary>
        ///  设置拦截器
        /// </summary>
        /// <param name="hookType">拦截器类型</param>
        /// <param name="hookProc"> 
        /// <code>拦截器处理函数</code> 
        /// <code>如果线程Id为0或由不同进程创建的线程，则拦截器函数必须指定为某个dll动态库中的函数</code>
        /// <code>否则拦截器函数可以指定为当前进程关联的函数</code> </param>
        /// <param name="hMod">
        /// <code>拦截器处理函数所在的dll动态库</code>
        /// <code>如果线程Id为当前进程创建的线程或拦截器函数为当前进程关联的函数则必须为NULL</code></param>
        /// <param name="threadId">与拦截器函数关联的线程Id</param>
        /// <returns>hookId</returns>
        [DllImport("user32.dll", EntryPoint = "SetWindowsHookEx", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        internal static extern IntPtr SetWindowsHookEx(HookType hookType, HookProc hookProc, IntPtr hMod, int threadId);

        /// <summary>
        /// 移除拦截器
        /// </summary>
        /// <param name="hookId"></param>
        /// <returns></returns>
        [DllImport("user32.dll", EntryPoint = "UnhookWindowsHookEx", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        internal static extern bool UnhookWindowsHookEx(IntPtr hookId);

        [DllImport("user32.dll", EntryPoint = "CallNextHookEx", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        internal static extern int CallNextHookEx(IntPtr hookId, int nCode, int wParam, IntPtr lParam);
    }

    public sealed class KeyboardHook : Hook
    {
        public KeyboardHook(KeyboardProc keyboardProc)
        {
            _midHookProc = keyboardProc;
            _hookType = HookType.WH_KEYBOARD;
            _hookProc = new HookProc(HookMethod);
        }
        private readonly KeyboardProc _midHookProc;
        protected override int HookMethod(int nCode, int wParam, IntPtr lParam)
        {
            _nCode = nCode;
            _wParam = wParam;
            _lParam = lParam;
            return _midHookProc.Invoke((HookCode)nCode, (VirtualKeyCode)wParam, lParam);
        }
    }

    public sealed class LowLevelKeyboardHook : Hook
    {
        public LowLevelKeyboardHook(LowLevelKeyboardProc lowLevelKeyboardProc)
        {
            _midHookProc = lowLevelKeyboardProc;
            _hookType = HookType.WH_KEYBOARD_LL;
            _hookProc = new HookProc(HookMethod);
        }
        private readonly LowLevelKeyboardProc _midHookProc;
        protected override int HookMethod(int nCode, int wParam, IntPtr lParam)
        {
            _nCode = nCode;
            _wParam = wParam; 
            _lParam = lParam;
            return _midHookProc.Invoke((HookCode)nCode, wParam, Marshal.PtrToStructure<KBDLLHOOKSTRUCT>(lParam));
        }
    }

    public sealed class MouseHook : Hook
    {
        public MouseHook(MouseProc mouseProc)
        {
            _midHookProc = mouseProc;
            _hookType = HookType.WH_MOUSE;
            _hookProc = new HookProc(HookMethod);
        }
        private readonly MouseProc _midHookProc;
        protected override int HookMethod(int nCode, int wParam, IntPtr lParam)
        {
            _nCode = nCode; _wParam = wParam; _lParam = lParam;
            return _midHookProc.Invoke((HookCode)nCode, wParam, Marshal.PtrToStructure<MOUSEHOOKSTRUCT>(lParam));
        }
    }

    public sealed class LowLevelMouseHook : Hook
    {
        public LowLevelMouseHook(LowLevelMouseProc lowLevelMouseProc)
        {
            _midHookProc = lowLevelMouseProc;
            _hookType = HookType.WH_MOUSE;
            _hookProc = new HookProc(HookMethod);
        }
        private readonly LowLevelMouseProc _midHookProc;
        protected override int HookMethod(int nCode, int wParam, IntPtr lParam)
        {
            _nCode = nCode; _wParam = wParam; _lParam = lParam;
            return _midHookProc.Invoke((HookCode)nCode, wParam, Marshal.PtrToStructure<MSLLHOOKSTRUCT>(lParam));
        }
    }

    public sealed class CallWndProcHook : Hook
    {
        public CallWndProcHook(CallWndProc callWndProc)
        {
            _midHookProc = callWndProc;
            _hookType = HookType.WH_CALLWNDPROC;
            _hookProc = new HookProc(HookMethod);
        }
        private readonly CallWndProc _midHookProc;
        protected override int HookMethod(int nCode, int wParam, IntPtr lParam)
        {
            _nCode = nCode; _wParam = wParam; _lParam = lParam;
            return _midHookProc.Invoke((HookCode)nCode, wParam, Marshal.PtrToStructure<CWPSTRUCT>(lParam));
        }
    }

    public sealed class CallWndProcRetHook : Hook
    {
        public CallWndProcRetHook(CallWndRetProc callWndRetProc)
        {
            _midHookProc = callWndRetProc;
            _hookType = HookType.WH_CALLWNDPROCRET;
            _hookProc = new HookProc(HookMethod);
        }
        private readonly CallWndRetProc _midHookProc;
        protected override int HookMethod(int nCode, int wParam, IntPtr lParam)
        {
            _nCode = nCode; _wParam = wParam; _lParam = lParam;
            return _midHookProc.Invoke(wParam, Marshal.PtrToStructure<CWPRETSTRUCT>(lParam));
        }
    }

    public sealed class GetMessageHook : Hook
    {
        public GetMessageHook(GetMsgProc getMsgProc)
        {
            _midHookProc = getMsgProc;
            _hookType = HookType.WH_GETMESSAGE;
            _hookProc = new HookProc(HookMethod);
        }
        private readonly GetMsgProc _midHookProc;
        protected override int HookMethod(int nCode, int wParam, IntPtr lParam)
        {
            _nCode = nCode; _wParam = wParam; _lParam = lParam;
            return _midHookProc.Invoke((HookCode)nCode,(MSGOprate)wParam, Marshal.PtrToStructure<MSG>(lParam));
        }
    }

    public sealed class ForegroundIdleHook : Hook
    {
        public ForegroundIdleHook(ForegroundIdleProc foregroundIdleProc)
        {
            _midHookProc = foregroundIdleProc;
            _hookType = HookType.WH_FOREGROUNDIDLE;
            _hookProc = new HookProc(HookMethod);
        }
        private readonly ForegroundIdleProc _midHookProc;
        protected override int HookMethod(int nCode, int wParam, IntPtr lParam)
        {
            _nCode = nCode; _wParam = wParam; _lParam = lParam;
            return _midHookProc.Invoke((HookCode)nCode);
        }
    }

    public sealed class JournalRecordHook : Hook
    {
        public JournalRecordHook(JournalRecordProc foregroundIdleProc)
        {
            _midHookProc = foregroundIdleProc;
            _hookType = HookType.WH_JOURNALRECORD;
            _hookProc = new HookProc(HookMethod);
        }
        private readonly JournalRecordProc _midHookProc;
        protected override int HookMethod(int nCode, int wParam, IntPtr lParam)
        {
            _nCode = nCode; _wParam = wParam; _lParam = lParam;
            return _midHookProc.Invoke((HookCode)nCode, Marshal.PtrToStructure<EVENTMSG>(lParam));
        }
    }

    public sealed class JournalPlaybackHook : Hook
    {
        public JournalPlaybackHook(JournalPlaybackProc foregroundIdleProc)
        {
            _midHookProc = foregroundIdleProc;
            _hookType = HookType.WH_JOURNALPLAYBACK;
            _hookProc = new HookProc(HookMethod);
        }
        private readonly JournalPlaybackProc _midHookProc;
        protected override int HookMethod(int nCode, int wParam, IntPtr lParam)
        {
            _nCode = nCode; _wParam = wParam; _lParam = lParam;
            return _midHookProc.Invoke((HookCode)nCode, Marshal.PtrToStructure<EVENTMSG>(lParam));
        }
    }

    public sealed class MessageHook : Hook
    {
        public MessageHook(MessageProc sysMsgProc)
        {
            _midHookProc = sysMsgProc;
            _hookType = HookType.WH_MSGFILTER;
            _hookProc = new HookProc(HookMethod);
        }
        private readonly MessageProc _midHookProc;
        protected override int HookMethod(int nCode, int wParam, IntPtr lParam)
        {
            _nCode = nCode; _wParam = wParam; _lParam = lParam;
            return _midHookProc.Invoke((MSGSource)nCode, Marshal.PtrToStructure<MSG>(lParam));
        }
    }

    public sealed class SysMsgHook : Hook
    {
        public SysMsgHook(SysMsgProc sysMsgProc)
        {
            _midHookProc = sysMsgProc;
            _hookType = HookType.WH_SYSMSGFILTER;
            _hookProc = new HookProc(HookMethod);
        }
        private readonly SysMsgProc _midHookProc;
        protected override int HookMethod(int nCode, int wParam, IntPtr lParam)
        {
            _nCode = nCode; _wParam = wParam; _lParam = lParam;
            return _midHookProc.Invoke((MSGSource)nCode, Marshal.PtrToStructure<MSG>(lParam));
        }
    }

    public sealed class ShellHook : Hook
    {
        public ShellHook(ShellProc shellProc)
        {
            _midHookProc = shellProc;
            _hookType = HookType.WH_SHELL;
            _hookProc = new HookProc(HookMethod);
        }
        private readonly ShellProc _midHookProc;
        protected override int HookMethod(int nCode, int wParam, IntPtr lParam)
        {
            _nCode = nCode; _wParam = wParam; _lParam = lParam;
            return _midHookProc.Invoke((HShellOprate)nCode, wParam,lParam);
        }
    }

    public sealed class DebugHook : Hook
    {
        public DebugHook(DebugProc debugProc)
        {
            _midHookProc = debugProc;
            _hookType = HookType.WH_DEBUG;
            _hookProc = new HookProc(HookMethod);
        }
        private readonly DebugProc _midHookProc;
        protected override int HookMethod(int nCode, int wParam, IntPtr lParam)
        {
            _nCode = nCode; _wParam = wParam; _lParam = lParam;
            return _midHookProc.Invoke((HookCode)nCode, (HookType)wParam, lParam);
        }
    }

    public sealed class CBTHook : Hook
    {
        public CBTHook(CBTProc cbtProc)
        {
            _midHookProc = cbtProc;
            _hookType = HookType.WH_CBT;
            _hookProc = new HookProc(HookMethod);
        }
        private readonly CBTProc _midHookProc;
        protected override int HookMethod(int nCode, int wParam, IntPtr lParam)
        {
            _nCode = nCode; _wParam = wParam; _lParam = lParam;
            return _midHookProc.Invoke((HCBTCode)nCode, wParam, lParam);
        }
    }
}
