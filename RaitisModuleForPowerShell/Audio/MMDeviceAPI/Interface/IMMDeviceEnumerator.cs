using System.Runtime.InteropServices;
using RaitisModuleForPowerShell.Audio.MMDeviceAPI.Enumerations;

// ReSharper disable UnusedMember.Global

namespace RaitisModuleForPowerShell.Audio.MMDeviceAPI.Interface {
	[Guid("A95664D2-9614-4F35-A746-DE8DB63617E6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IMMDeviceEnumerator {
		int EnumAudioEndpoints(/*未実装*/);
		int GetDefaultAudioEndpoint(EDataFlow dataFlow, ERole role, out IMMDevice endpoint);
	}
}
