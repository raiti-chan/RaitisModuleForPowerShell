using System;
using System.Runtime.InteropServices;
using RaitisModuleForPowerShell.Volume.Interface;

namespace RaitisModuleForPowerShell.Volume {
	public class Audio {
		private static IAudioEndpointVolume Vol() {
			IMMDeviceEnumerator enumerator = new MMDeviceEnumeratorComObject() as IMMDeviceEnumerator ?? throw new Exception();
			Marshal.ThrowExceptionForHR(enumerator.GetDefaultAudioEndpoint( /*eRender*/ 0, /*eMultimedia*/ 1, out var dev));
			var epvid = typeof(IAudioEndpointVolume).GUID;
			Marshal.ThrowExceptionForHR(dev.Activate(ref epvid, /*CLSCTX_ALL*/ 23, 0, out var epv));
			return epv;
		}

		public static float Volume {
			get {
				float v = -1;
				Marshal.ThrowExceptionForHR(Vol().GetMasterVolumeLevelScalar(out v));
				return v;
			}
			set => Marshal.ThrowExceptionForHR(Vol().SetMasterVolumeLevelScalar(value, System.Guid.Empty));
		}

		public static bool Mute {
			get {
				Marshal.ThrowExceptionForHR(Vol().GetMute(out var mute));
				return mute;
			}
			set => Marshal.ThrowExceptionForHR(Vol().SetMute(value, System.Guid.Empty));
		}
	}
}
