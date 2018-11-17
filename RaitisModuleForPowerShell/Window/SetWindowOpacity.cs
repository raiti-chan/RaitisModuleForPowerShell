using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RaitisModuleForPowerShell.Window {
	[CmdletBinding]
	[Cmdlet(VerbsCommon.Set, "WindowOpacity")]
	// ReSharper disable once UnusedMember.Global
	public class SetWindowOpacity : PSCmdlet {

		[DllImport("user32.dll")]
		private static extern uint GetWindowLong(IntPtr windowHandlePtr, int nIndex);

		[DllImport("user32.dll")]
		private static extern uint SetWindowLong(IntPtr windowHandlePtr, int nIndex, uint dwNewLong);

		[DllImport("user32.dll")]
		private static extern bool SetLayeredWindowAttributes(IntPtr windowHandlePtr, IntPtr crKey, byte bAlpha, uint dwFlags);


		[Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
		public WindowObject Window { get; set; }

		[Parameter(Mandatory = true, Position = 0, ValueFromPipeline = false)]
		public byte Opacity { get; set; }
		

		protected override void ProcessRecord() {
			uint windowLong = GetWindowLong(this.Window.WindowHandlePtr, -20);
			SetWindowLong(this.Window.WindowHandlePtr, -20, windowLong | 0x00080000);
			SetLayeredWindowAttributes(this.Window.WindowHandlePtr, IntPtr.Zero, Opacity, 0x00000002);
		}
	}
}
