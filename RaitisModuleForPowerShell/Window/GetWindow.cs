using System;
using System.Diagnostics;
using System.Management.Automation;
using System.Runtime.InteropServices;
using System.Text;

namespace RaitisModuleForPowerShell.Window {
	[CmdletBinding]
	[Cmdlet(VerbsCommon.Get, "Window")]
	// ReSharper disable once UnusedMember.Global
	public class GetWindow : PSCmdlet {


		private delegate bool _EnumWindowsDelegate(IntPtr windowHandlePtr, IntPtr lparam);

		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool EnumWindows(_EnumWindowsDelegate lpEnumFunc, IntPtr lparam);

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern int GetWindowText(IntPtr windowHandlePtr, StringBuilder lpString, int nMaxCount);

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern int GetWindowTextLength(IntPtr windowHandlePtr);

		[DllImport("user32.dll")]
		private static extern uint GetWindowThreadProcessId(IntPtr windowHandlePtr, IntPtr lpdwProcessId);

		protected override void ProcessRecord() => EnumWindows(this.EnumWindowCallBack, IntPtr.Zero);



		private bool EnumWindowCallBack(IntPtr windowHandlePtr, IntPtr lparam) {
			int textLen = GetWindowTextLength(windowHandlePtr);
			string windowTitle = "";
			if (0 < textLen) {
				StringBuilder builder = new StringBuilder(textLen + 1);
				GetWindowText(windowHandlePtr, builder, builder.Capacity);
				windowTitle = builder.ToString();
			}

			IntPtr processIdPtr = Marshal.AllocHGlobal(sizeof(ushort));
			GetWindowThreadProcessId(windowHandlePtr, processIdPtr);
			ushort processId = (ushort) Marshal.ReadInt16(processIdPtr);
			Marshal.FreeHGlobal(processIdPtr);

			using (Process process = Process.GetProcessById(processId)) {
				this.WriteObject(new WindowObject(processId, process.ProcessName, windowHandlePtr, windowTitle));
			}

			return true;
		}
	}


}
