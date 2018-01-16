using System.Management.Automation;
using RaitisModuleForPowerShell.Audio.MMDeviceAPI;
using RaitisModuleForPowerShell.Audio.MMDeviceAPI.Enumerations;

namespace RaitisModuleForPowerShell.Audio {

	[CmdletBinding]
	[Cmdlet(VerbsCommon.Get, "AudioLevel")]
	// ReSharper disable once UnusedMember.Global
	public class GetAudioLevel : PSCmdlet {

		private float _volumeLevel;

		protected override void ProcessRecord() {
			using (MMDeviceEnumerator enumerator = new MMDeviceEnumerator())
			using (MMDevice device = enumerator.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia)) {
				this._volumeLevel = device.AudioEndpointVolume.MasterVolumeLevelScalar;
			}
		}

		protected override void EndProcessing() => this.WriteObject((int)(this._volumeLevel * 100));
	}
}
