using System;
using System.Management.Automation;
using RaitisModuleForPowerShell.Audio.MMDeviceAPI;
using RaitisModuleForPowerShell.Audio.MMDeviceAPI.Enumerations;

namespace RaitisModuleForPowerShell.Audio {
	
	[CmdletBinding]
	[Cmdlet(VerbsCommon.Set, "AudioLevel")]
	// ReSharper disable once UnusedMember.Global
	public class SetAudioLevel : PSCmdlet {
		
		[Parameter(Mandatory = true, Position = 0, ValueFromPipeline = false)]
		// ReSharper disable once MemberCanBePrivate.Global
		// ReSharper disable once UnusedAutoPropertyAccessor.Global
		public int AudioLevel { get; set; }
		
		protected override void ProcessRecord() {
			if (this.AudioLevel >= 0 && this.AudioLevel <= 100) {
				using (MMDeviceEnumerator enumerator = new MMDeviceEnumerator())
				using (MMDevice device = enumerator.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia)) {
					device.AudioEndpointVolume.MasterVolumeLevelScalar = this.AudioLevel / 100F;
				}

			} else {
				throw new ArgumentException("音量の値は0~100の間です");
			}
		}
	}
}
