using System;
using System.Runtime.InteropServices;

// ReSharper disable UnusedMember.Global

namespace RaitisModuleForPowerShell.Audio.MMDeviceAPI.Interface {
	[Guid("5CDF2C82-841E-4546-9722-0CF74078229A"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IAudioEndpointVolume {
		[PreserveSig]
		int RegisterControlChangeNotify( /*未実装*/);

		[PreserveSig]
		int UnregisterControlChangeNotify( /*未実装*/);

		[PreserveSig]
		int GetChannelCount(out int pnChannelCount);

		[PreserveSig]
		int SetMasterVolumeLevel(float fLevelDB, Guid pguidEventContext);

		[PreserveSig]
		int SetMasterVolumeLevelScalar(float fLevel, Guid pguidEventContext);

		[PreserveSig]
		int GetMasterVolumeLevel(out float pfLevelBD);

		[PreserveSig]
		int GetMasterVolumeLevelScalar(out float pfLevel);

		[PreserveSig]
		int SetChannelVolumeLevel(uint nChannel, float fLevelBD, Guid pguidEventContext);

		[PreserveSig]
		int SetChannelVolumeLevelScalar(uint nChannel, float fLevel, Guid pguidEventContext);

		[PreserveSig]
		int GetChannelVolumeLevel(uint nChannel, out float pfLevelDB);

		[PreserveSig]
		int GetChannelVolumeLevelScalar(uint nChannel, out float pfLevel);

		[PreserveSig]
		int SetMute([MarshalAs(UnmanagedType.Bool)] bool bMute, Guid pguidEventContext);

		[PreserveSig]
		int GetMute(out bool pbMute);

		[PreserveSig]
		int GetVolumeStepInfo(out uint pnStep, out uint pnStepCount);

		[PreserveSig]
		int VolumeStepUp(Guid pguidEventContext);

		[PreserveSig]
		int VolumeStepDown(Guid pguidEventContext);

		[PreserveSig]
		int QueryHardwareSupport(out uint pdwHardwareSupportMask);

		[PreserveSig]
		int GetVolumeRange(out float pfVolumeMindB, out float pfVolumeMaxdB, out float pfVolumeIncrmentdB);
	}
}
