using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Thriving.Win32Tools;

namespace Sample.Input
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("Kernel32.dll", EntryPoint = "GetCurrentThreadId", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetCurrentThreadId();
        //private readonly int _hookId;
        //private HookHelper.HookProc _hookProc;
        private Hook _hook;
        public MainWindow()
        {
            InitializeComponent();
            //_hookProc = new HookHelper.HookProc(callWndMethod);
            //var handle = Process.GetCurrentProcess().Handle;
            var threadId = GetCurrentThreadId();
            //_hookId = HookHelper.SetWindowsHookEx(HookType.WH_KEYBOARD, _hookProc, IntPtr.Zero, threadId);
            _hook = new KeyboardHook(callWndMethod);

            _hook.Set();
        }

        private int callWndMethod(HookCode hookType, VirtualKeyCode wParam, IntPtr lParam)
        {
            return _hook.CallNext();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InputArray inputs = new InputArray
            {
                new KeyboardInput()
                {
                    wVk =VirtualKeyCode.VK_CAPITAL,
                    dwFlags =VirtualKeyEvent.KEYEVENTF_KEYDOWN
                },
                new KeyboardInput()
                {
                    wVk = VirtualKeyCode.VK_CAPITAL,
                    dwFlags = VirtualKeyEvent.KEYEVENTF_KEYUP
                }
            };
            InputHelper.SendInput(inputs);
        }

        private void Button_Click_A(object sender, RoutedEventArgs e)
        {
            tbox.Focus();
            InputArray inputs = new InputArray
            {
                new KeyboardInput()
                {
                    wVk = VirtualKeyCode.VK_A,
                    dwFlags =VirtualKeyEvent.KEYEVENTF_KEYDOWN
                },
                new KeyboardInput()
                {
                    wVk =VirtualKeyCode.VK_A,
                    dwFlags =VirtualKeyEvent.KEYEVENTF_KEYUP
                }
            };
            InputHelper.SendInput(inputs);
        }

        private void Button_Click_B(object sender, RoutedEventArgs e)
        {
            tbox.Focus();
            InputArray inputs = new InputArray
            {
                new KeyboardInput()
                {
                    wVk = VirtualKeyCode.VK_B,
                    dwFlags = VirtualKeyEvent.KEYEVENTF_KEYDOWN
                },
                new KeyboardInput()
                {
                    wVk = VirtualKeyCode.VK_B,
                    dwFlags =VirtualKeyEvent.KEYEVENTF_KEYUP
                }
            };
            InputHelper.SendInput(inputs);
        }

        private void Button_Click_C(object sender, RoutedEventArgs e)
        {
            tbox.Focus();
            char c = '我';
            InputArray inputs = new InputArray
            {
                new KeyboardInput()
                {
                    wScan=(short)c,
                    dwFlags =VirtualKeyEvent.KEYEVENTF_UNICODE
                },
            };
            InputHelper.SendInput(inputs);
        }
    }
}
