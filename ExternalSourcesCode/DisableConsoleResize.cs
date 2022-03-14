using System;
using System.Runtime.InteropServices;

namespace ExternalSourcesCode
{
    public class DisableConsoleResize
    {
        private const int MfBycommand = 0x00000000;
        private const int ScClose = 0xF060;
        private const int ScMinimize = 0xF020;
        private const int ScMaximize = 0xF030;
        private const int ScSize = 0xF000;

        [DllImport("user32.dll")]
        private static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        public static void SetDisableResize()
        {
            IntPtr handle = GetConsoleWindow();
            IntPtr sysMenu = GetSystemMenu(handle, false);

            if (handle != IntPtr.Zero)
            {
                DeleteMenu(sysMenu, ScClose, MfBycommand);
                DeleteMenu(sysMenu, ScMinimize, MfBycommand);
                DeleteMenu(sysMenu, ScMaximize, MfBycommand);
                DeleteMenu(sysMenu, ScSize, MfBycommand);
            }
        }
    }
}