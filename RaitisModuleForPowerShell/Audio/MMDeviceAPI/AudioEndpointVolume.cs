using System;
using System.Runtime.InteropServices;
using RaitisModuleForPowerShell.Volume.Interface;

// ReSharper disable UnusedMember.Global

namespace RaitisModuleForPowerShell.Audio.MMDeviceAPI {
	public class AudioEndpointVolume : IDisposable {
		private readonly IAudioEndpointVolume _audioEndpointVolume;

		public float MasterVolumeLevel {
			get {
				Marshal.ThrowExceptionForHR(_audioEndpointVolume.GetMasterVolumeLevel(out float result));
				return result;
			}
			set => Marshal.ThrowExceptionForHR(_audioEndpointVolume.SetMasterVolumeLevel(value, Guid.Empty));
		}

		public float MasterVolumeLevelScalar {
			get {
				Marshal.ThrowExceptionForHR(_audioEndpointVolume.GetMasterVolumeLevelScalar(out var result));
				return result;
			}
			set => Marshal.ThrowExceptionForHR(_audioEndpointVolume.SetMasterVolumeLevelScalar(value, Guid.Empty));
		}

		public bool Mute {
			get {
				Marshal.ThrowExceptionForHR(_audioEndpointVolume.GetMute(out var result));
				return result;
			}
			set => Marshal.ThrowExceptionForHR(_audioEndpointVolume.SetMute(value, Guid.Empty));
		}

		public void VolumeStepUp() {
			Marshal.ThrowExceptionForHR(_audioEndpointVolume.VolumeStepUp(Guid.Empty));
		}

		public void VolumeStepDown() {
			Marshal.ThrowExceptionForHR(_audioEndpointVolume.VolumeStepDown(Guid.Empty));
		}

		internal AudioEndpointVolume(IAudioEndpointVolume audioEndpointVolume) {
			this._audioEndpointVolume = audioEndpointVolume;
		}

		public void Dispose() { }
	}
}
