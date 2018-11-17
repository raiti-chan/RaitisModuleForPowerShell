using System;
using System.Management.Automation;
using System.Runtime.InteropServices;

namespace RaitisModuleForPowerShell.Device {
	[CmdletBinding]
	[Cmdlet(VerbsCommon.Set, "MouseSensitivity")]
	// ReSharper disable once UnusedMember.Global
	public class SetMouseSensitivity : PSCmdlet{
		[DllImport("user32.dll")]
		private static extern bool SystemParametersInfo(uint uiAction, uint uiParam, IntPtr pvParam, uint fWinIni);

		private const uint  SPI_SETMOUSESPEED = 113;
		private const uint SPIF_UPDATEINIFILE = 1;
		private const uint SPIF_SENDCHANGE = 2;

		[Parameter(Mandatory = true, Position = 0, ValueFromPipeline = false)]
		public uint SensitivityLevel { get; set; }

		protected override void ProcessRecord() {
			if (this.SensitivityLevel > 20 || this.SensitivityLevel < 1) {
				throw new ArgumentException("感度レベルは1~20の間です");
			}

			SystemParametersInfo(SPI_SETMOUSESPEED, 0, new IntPtr(this.SensitivityLevel), SPIF_SENDCHANGE | SPIF_UPDATEINIFILE);
		}
	}
}
