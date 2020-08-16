using System;
using System.Diagnostics;

namespace charts.drawing.webkit.memory {
    public class Utils {
        public static void FlushManagedMemory() {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public static void FlushUnManagedMemory() {
            if (Environment.OSVersion.Platform == PlatformID.Win32NT) {
                NativeMethods.SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            }
        }

        public static void FlushMemory() {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT) {
                NativeMethods.SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            }
        }

        public static void FlushMemory(long flushThreshold) {
            Process proc = Process.GetCurrentProcess();
            long usedMemory = proc.PrivateMemorySize64;
            if (usedMemory > flushThreshold) {
                Utils.FlushMemory();
            }
        }
    }
}
