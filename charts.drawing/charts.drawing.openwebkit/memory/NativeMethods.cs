using System;
using System.Runtime.InteropServices;

namespace charts.drawing.webkit.memory {
    internal static class NativeMethods {
        [DllImport("kernel32.dll")]
        public static extern int SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);
    }
}
