using System.ComponentModel;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Runtime.InteropServices;
using System;

namespace Crock
{
    static class Protect
    {
        // Registration DLL
        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool GetKernelObjectSecurity(IntPtr Handle, int securityInformation, 
            [Out] byte[] pSecurityDescriptor, uint nLength, out uint lpnLengthNeeded);
        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool SetKernelObjectSecurity(IntPtr Handle, int securityInformation, 
            [In] byte[] pSecurityDescriptor);
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetCurrentProcess();

        // Get description
        private static RawSecurityDescriptor GetProcessSecurityDescriptor(IntPtr processHandle)
        {
            const int daclSecurityInformation = 0x00000004;
            var psd = Array.Empty<byte>();
            GetKernelObjectSecurity(processHandle, daclSecurityInformation, psd, 0, out var bufSizeNeeded);
            if (bufSizeNeeded > short.MaxValue)
                throw new Win32Exception();
            if (!GetKernelObjectSecurity(processHandle, daclSecurityInformation,
            psd = new byte[bufSizeNeeded], bufSizeNeeded, out bufSizeNeeded))
                throw new Win32Exception();
            return new RawSecurityDescriptor(psd, 0);
        }

        // Set description
        private static void SetProcessSecurityDescriptor(IntPtr processHandle, RawSecurityDescriptor dacl)
        {
            const int daclSecurityInformation = 0x00000004;
            var rawsd = new byte[dacl.BinaryLength];
            dacl.GetBinaryForm(rawsd, 0);
            if (!SetKernelObjectSecurity(processHandle, daclSecurityInformation, rawsd))
                throw new Win32Exception();
        }

        // Update flags
        [Flags]
        private enum ProcessAccessRights
        {
            PROCESS_CREATE_PROCESS = 0x0080,
            PROCESS_CREATE_THREAD = 0x0002,
            PROCESS_DUP_HANDLE = 0x0040,
            PROCESS_QUERY_INFORMATION = 0x0400,
            PROCESS_QUERY_LIMITED_INFORMATION = 0x1000,
            PROCESS_SET_INFORMATION = 0x0200,
            PROCESS_SET_QUOTA = 0x0100,
            PROCESS_SUSPEND_RESUME = 0x0800,
            PROCESS_TERMINATE = 0x0001,
            PROCESS_VM_OPERATION = 0x0008,
            PROCESS_VM_READ = 0x0010,
            PROCESS_VM_WRITE = 0x0020,
            DELETE = 0x00010000,
            READ_CONTROL = 0x00020000,
            SYNCHRONIZE = 0x00100000,
            WRITE_DAC = 0x00040000,
            WRITE_OWNER = 0x00080000,
            STANDARD_RIGHTS_REQUIRED = 0x000f0000,
            PROCESS_ALL_ACCESS = (STANDARD_RIGHTS_REQUIRED | SYNCHRONIZE | 0xFFF),
        }

        // Start all modules in this file
        public static void Block()
        {
            var hProcess = GetCurrentProcess();
            var dacl = GetProcessSecurityDescriptor(hProcess);
            dacl.DiscretionaryAcl.InsertAce(
            0,
            new CommonAce(
            AceFlags.None,
            AceQualifier.AccessDenied,
            (int)ProcessAccessRights.PROCESS_ALL_ACCESS,
            new SecurityIdentifier(WellKnownSidType.WorldSid, null),
            false,
            null)
            );
            SetProcessSecurityDescriptor(hProcess, dacl);
        }
    }
}
