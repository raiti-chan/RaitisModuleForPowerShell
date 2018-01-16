using System;
using System.Runtime.InteropServices;
using RaitisModuleForPowerShell.Audio.MMDeviceAPI.Enumerations;
using RaitisModuleForPowerShell.Audio.MMDeviceAPI.Interface;

namespace RaitisModuleForPowerShell.Audio.MMDeviceAPI {
	public class MMDevice : IDisposable{
		private readonly IMMDevice _realDevice;

		private AudioEndpointVolume _audioEndpointVolume;

		private void GetAudioEndpointVolume() {
			Guid guid = typeof(IAudioEndpointVolume).GUID;
			Marshal.ThrowExceptionForHR(_realDevice.Activate(ref guid, CLSCTX.ALL, IntPtr.Zero, out var result));
			_audioEndpointVolume = new AudioEndpointVolume(result as IAudioEndpointVolume);
		}


		public AudioEndpointVolume AudioEndpointVolume {
			get {
				if (this._audioEndpointVolume == null) {
					this.GetAudioEndpointVolume();
				}

				return this._audioEndpointVolume;
			}
		}
		
		internal MMDevice(IMMDevice realDevice) {
			this._realDevice = realDevice;
		}
		
		public void Dispose() {
			if (_realDevice != null) Marshal.ReleaseComObject(_realDevice);
		}
	}
}
