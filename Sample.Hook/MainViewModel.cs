using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Thriving.Win32Tools;

namespace HookTool
{
    internal class MainViewModel:NotificationObject
    {
        public MainViewModel()
        {
            SelectedItemChangedCommand = new DelegateCommand<Win32Window>(item =>
            {
                SelectedWindow = item;
                RaisePropertyChanged(nameof(SelectedWindow));
            });

            enumProc = new EnumWindowsProc((hwnd, lParam) =>
            {
                windowNodes.Add(new Win32Window(hwnd));

                return windowNodes.Count <= 100;
            });
            var res = WindowHelper.EnumWindows(enumProc, IntPtr.Zero);
           

            _callWndProcHook = new CallWndProcHook(CallWndProcMethod);
            CallWndProcHookCommand = new DelegateCommand<bool>(CallWndProcHookMethod);

            _callWndProcRetHook = new CallWndProcRetHook(CallWndRetProcMethod);
            CallWndProcRetHookCommand = new DelegateCommand<bool>(CallWndProcRetHookMethod);

            _cbTHook = new CBTHook(CBTProcMethod);
            CBTHookCommand = new DelegateCommand<bool>(CBTHookMethod);

            _foregroundIdleHook = new ForegroundIdleHook(ForegroundIdleProcMethod);
            ForegroundIdleHookCommand = new DelegateCommand<bool>(ForegroundIdleHookMethod);

            _keyboardHook = new KeyboardHook(KeyboardProcMethod);
            KeyBoardHookCommand = new DelegateCommand<bool>(KeyBoardHookMethod);

            _mouseHook = new MouseHook(MouseProcMethod);
            MouseHookCommand = new DelegateCommand<bool>(MouseHookMethod);

            _lowLevelKeyboardHook = new LowLevelKeyboardHook(LowLevelKeyboardProcMethod);
            KeyBoardLLHookCommand = new DelegateCommand<bool>(KeyBoardLLHookMethod);

            _lowLevelMouseHook = new LowLevelMouseHook(LowLevelMouseProcMethod);
            MouseLLHookCommand = new DelegateCommand<bool>(MouseLLHookMethod);

            _debugHook = new DebugHook(DebugProcMethod);
            DebugHookCommand =new DelegateCommand<bool>(DebugHookMethod);

            _journalRecordHook = new JournalRecordHook(JournalRecordProcMethod);    
            JournalRecordHookCommand=new DelegateCommand<bool>(JournalRecordHookMethod);

            _journalPlaybackHook = new JournalPlaybackHook(JournalPlaybackProcMethod);
            JournalPlaybackHookCommand = new DelegateCommand<bool>(JournalPlaybackHookMethod);

            _getMessageHook = new GetMessageHook(GetMssgProcMethod);
            GetMessageHookCommand = new DelegateCommand<bool>(GetMessageHookMethod);

            _messageHook = new MessageHook(MessageProcMethod);
            MessageHookCommand= new DelegateCommand<bool>(MessageHookMethod);

            _sysMsgHook= new SysMsgHook(SysMsgProcMethod);
            SysMsgHookCommand = new DelegateCommand<bool>(SysMsgHookMethod);

            _shellHook = new ShellHook(ShellProcMethod);
            ShellHookCommand=new DelegateCommand<bool>(ShellHookMethod);
        }

        private readonly EnumWindowsProc enumProc;

        private ObservableCollection<Win32Window> windowNodes = new ObservableCollection<Win32Window>();
        public ObservableCollection<Win32Window> WindowNodes
        {
            get { return windowNodes; }
            set
            {
                windowNodes = value;
                RaisePropertyChanged(nameof(WindowNodes));
            }
        }

        public DelegateCommand<Win32Window> SelectedItemChangedCommand { get; }
        public Win32Window SelectedWindow { get; private set; }

        private string message =string.Empty;
        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                RaisePropertyChanged(nameof(Message));
            }
        }


        private void ToggleHookState(bool set,Hook hook)
        {
            if (set)
            {
                if (hook.Set())
                {
                    Message += "拦截器设置成功\n";
                }
                else
                {
                    Message += $"拦截器设置失败；错误码：{KernelHelper.GetLastError()}\n";
                }
            }
            else
            {
                if (hook.UnHook())
                {
                    Message += "拦截器卸载成功\n";
                }
                else
                {
                    Message += $"拦截器卸载失败；错误码：{KernelHelper.GetLastError()}\n";
                }
            }
        }

        #region 键盘Hook

        private readonly KeyboardHook _keyboardHook;
        private int KeyboardProcMethod(HookCode nCode, VirtualKeyCode wParam, IntPtr lParam)
        {
            Message += $"{wParam}\n";
            return _keyboardHook.CallNext();
        }
        public DelegateCommand<bool> KeyBoardHookCommand { get; }
        private void KeyBoardHookMethod(bool isChecked)
        {
            if (SelectedWindow == null)
            {
                Message += "选择的Win32Window不能为空\n";
                return;
            }
            ToggleHookState(isChecked, _keyboardHook);
        }

        #endregion

        #region 鼠标Hook
        private readonly MouseHook _mouseHook;
        private int MouseProcMethod(HookCode nCode, int wParam, MOUSEHOOKSTRUCT lParam)
        {
            Message += $"({lParam.pt_x},{lParam.pt_y})\n";
            return _mouseHook.CallNext();
        }
        public DelegateCommand<bool> MouseHookCommand { get; }
        private void MouseHookMethod(bool isChecked)
        {
            if (SelectedWindow == null)
            {
                Message += "选择的Win32Window不能为空\n";
                return;
            }
            ToggleHookState(isChecked, _mouseHook);
        }

        #endregion

        #region LowLevel键盘Hook
        private readonly LowLevelKeyboardHook _lowLevelKeyboardHook;
        private int LowLevelKeyboardProcMethod(HookCode nCode, int wParam, KBDLLHOOKSTRUCT lParam)
        {
            Message += $"{lParam.vkCode}\n";

            return _lowLevelKeyboardHook.CallNext();
        }
        public DelegateCommand<bool> KeyBoardLLHookCommand { get; }
        private void KeyBoardLLHookMethod(bool isChecked)
        {
            if (SelectedWindow == null)
            {
                Message += "选择的Win32Window不能为空\n";
                return;
            }
            ToggleHookState(isChecked, _lowLevelKeyboardHook);
        }

        #endregion

        #region LowLevel鼠标Hook

        private readonly LowLevelMouseHook _lowLevelMouseHook;
        private int LowLevelMouseProcMethod(HookCode nCode, int wParam, MSLLHOOKSTRUCT lParam)
        {
            Message += $"({lParam.pt_x},{lParam.pt_y})\n";
            return _lowLevelMouseHook.CallNext();
        }

        public DelegateCommand<bool> MouseLLHookCommand { get; }
        private void MouseLLHookMethod(bool isChecked)
        {
            if (SelectedWindow == null)
            {
                Message += "选择的Win32Window不能为空\n";
                return;
            }
            ToggleHookState(isChecked, _lowLevelMouseHook);
        }

        #endregion

        #region CBT Hook
        private readonly CBTHook _cbTHook;
        private int CBTProcMethod(HCBTCode nCode, int wParam, IntPtr lParam) 
        {
            Message += $"CBT类型{nCode}\n";
            return  _cbTHook.CallNext();
        }


        public DelegateCommand<bool> CBTHookCommand { get; }
        private void CBTHookMethod(bool isChecked)
        {
            if (SelectedWindow == null)
            {
                Message += "选择的Win32Window不能为空\n";
                return;
            }
            ToggleHookState(isChecked, _cbTHook);
        }
        #endregion

        #region Hook Debug
        private readonly DebugHook _debugHook;
        private int DebugProcMethod(HookCode nCode, HookType wParam, IntPtr lParam)
        {
            Message += $"Hook类型{wParam}\n";
            return _debugHook.CallNext();
        }

        public DelegateCommand<bool> DebugHookCommand { get; }
        private void DebugHookMethod(bool isChecked)
        {
            if (SelectedWindow == null)
            {
                Message += "选择的Win32Window不能为空\n";
                return;
            }
            ToggleHookState(isChecked, _debugHook);
        }

        #endregion

        #region 日志记录

        private readonly JournalRecordHook _journalRecordHook;
        private int JournalRecordProcMethod(HookCode nCode, EVENTMSG lParam)
        {
            Message += $"消息索引{lParam.message}\n";
            return _journalRecordHook.CallNext();
        }
        public DelegateCommand<bool> JournalRecordHookCommand { get; }
        private void JournalRecordHookMethod(bool isChecked)
        {
            if (SelectedWindow == null)
            {
                Message += "选择的Win32Window不能为空\n";
                return;
            }
            ToggleHookState(isChecked, _journalRecordHook);
        }

        #endregion

        #region 日志回放

        private readonly JournalPlaybackHook _journalPlaybackHook;
        private int JournalPlaybackProcMethod(HookCode nCode, EVENTMSG lParam)
        {
            Message += $"消息索引{lParam.message}\n";
            return _journalPlaybackHook.CallNext();
        }
        public DelegateCommand<bool> JournalPlaybackHookCommand { get; }
        private void JournalPlaybackHookMethod(bool isChecked)
        {
            if (SelectedWindow == null)
            {
                Message += "选择的Win32Window不能为空\n";
                return;
            }
            ToggleHookState(isChecked, _journalPlaybackHook);
        }

        #endregion

        #region 窗口处理程序Hook

        private readonly CallWndProcHook _callWndProcHook;
        private int CallWndProcMethod(HookCode nCode, int wParam, CWPSTRUCT lParam)
        {
            Message += $"消息索引{lParam.message}\n";
            return _callWndProcHook.CallNext();
        }

        public DelegateCommand<bool> CallWndProcHookCommand { get; }
        private void CallWndProcHookMethod(bool isChecked) 
        {
            if (SelectedWindow == null)
            {
                Message += "选择的Win32Window不能为空\n";
                return;
            }
            ToggleHookState(isChecked, _callWndProcHook);
        }

        #endregion

        #region 窗口处理程序返回Hook

        private readonly CallWndProcRetHook _callWndProcRetHook;
        private int CallWndRetProcMethod(int wParam, CWPRETSTRUCT lParam) 
        {
            Message += $"消息索引{lParam.message}\n";
            return _callWndProcHook.CallNext();
        }
        public DelegateCommand<bool> CallWndProcRetHookCommand { get; }
        private void CallWndProcRetHookMethod(bool isChecked)
        {
            if (SelectedWindow == null)
            {
                Message += "选择的Win32Window不能为空\n";
                return;
            }
            ToggleHookState(isChecked, _callWndProcRetHook);
        }

        #endregion

        #region 窗口空闲处理

        private readonly ForegroundIdleHook _foregroundIdleHook;
        private int ForegroundIdleProcMethod(HookCode nCode) 
        {
            return _foregroundIdleHook.CallNext();
        }

        public DelegateCommand<bool> ForegroundIdleHookCommand { get; }
        private void ForegroundIdleHookMethod(bool isChecked)
        {
            if (SelectedWindow == null)
            {
                Message += "选择的Win32Window不能为空\n";
                return;
            }
            ToggleHookState(isChecked, _foregroundIdleHook);
        }

        #endregion

        #region 获取消息Hook

        private readonly GetMessageHook _getMessageHook;
        private int GetMssgProcMethod(HookCode nCode,MSGOprate wParam,MSG lParam) 
        {
            Message += $"消息索引{lParam.message}\n";
            return _getMessageHook.CallNext();
        }

        public DelegateCommand<bool> GetMessageHookCommand { get; }
        private void GetMessageHookMethod(bool isChecked)
        {
            if (SelectedWindow == null)
            {
                Message += "选择的Win32Window不能为空\n";
                return;
            }
        
            ToggleHookState(isChecked, _getMessageHook);
        }

        #endregion

        #region 消息过滤Hook

        private readonly MessageHook _messageHook;
        private int MessageProcMethod(MSGSource nCode,MSG lParam)
        {
            Message += $"消息源{nCode}\n";
            return _messageHook.CallNext();
        }

        public DelegateCommand<bool> MessageHookCommand { get; }
        private void MessageHookMethod(bool isChecked)
        {
            if (SelectedWindow == null)
            {
                Message += "选择的Win32Window不能为空\n";
                return;
            }
            ToggleHookState(isChecked, _messageHook);

        }
        #endregion

        #region 系统消息过滤Hook
        private readonly SysMsgHook _sysMsgHook;
        private int SysMsgProcMethod(MSGSource nCode, MSG lParam) 
        {
            Message += $"消息源{nCode}\n";
            return _sysMsgHook.CallNext();
        }

        public DelegateCommand<bool> SysMsgHookCommand { get; }
        private void SysMsgHookMethod(bool isChecked)
        {
            if (SelectedWindow == null)
            {
                Message += "选择的Win32Window不能为空\n";
                return;
            }
            ToggleHookState(isChecked, _sysMsgHook);
        }

        #endregion

        #region Shell Hook

        private readonly ShellHook _shellHook;
        private int ShellProcMethod(HShellOprate nCode, int wParam, IntPtr lParam) 
        {
            Message += $"Shell操作{nCode}\n";
            return _shellHook.CallNext();
        }

        public DelegateCommand<bool> ShellHookCommand { get; }
        private void ShellHookMethod(bool isChecked)
        {
            if (SelectedWindow == null)
            {
                Message += "选择的Win32Window不能为空\n";
                return;
            }
            ToggleHookState(isChecked, _shellHook);
        }

        #endregion
    }
}
