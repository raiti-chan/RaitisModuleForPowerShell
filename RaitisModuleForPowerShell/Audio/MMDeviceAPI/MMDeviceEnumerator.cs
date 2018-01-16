using System;
using System.Runtime.InteropServices;
using RaitisModuleForPowerShell.Audio.MMDeviceAPI.Enumerations;
using RaitisModuleForPowerShell.Volume.Interface;

namespace RaitisModuleForPowerShell.Audio.MMDeviceAPI {
	[ComImport, Guid("BCDE0395-E52F-467C-8E3D-C4579291692E")]
	internal class _MMDeviceEnumerator { }

	public class MMDeviceEnumerator : IDisposable {
		// ReSharper disable once SuspiciousTypeConversion.Global
		private readonly IMMDeviceEnumerator _realEnumrator = new _MMDeviceEnumerator() as IMMDeviceEnumerator;

		public MMDevice GetDefaultAudioEndpoint(EDataFlow dataFlow, ERole role) {
			Marshal.ThrowExceptionForHR(_realEnumrator.GetDefaultAudioEndpoint(dataFlow, role, out IMMDevice device));
			return new MMDevice(device);
		}

		public void Dispose() {
			if (_realEnumrator != null) {
				Marshal.ReleaseComObject(_realEnumrator);
			}
	}
	}
}
