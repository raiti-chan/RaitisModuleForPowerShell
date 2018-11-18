using System.Runtime.InteropServices;
using RaitisLibraryForPowerShell.Audio.MMDeviceAPI.Enumerations;

// ReSharper disable UnusedMember.Global

namespace RaitisLibraryForPowerShell.Audio.MMDeviceAPI.Interface {
	[Guid("A95664D2-9614-4F35-A746-DE8DB63617E6"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IMMDeviceEnumerator {
		[PreserveSig]
		int EnumAudioEndpoints(EDataFlow dataFlow, EDeviceState stateMask, out IMMDeviceCollection device);
		
		[PreserveSig]
		int GetDefaultAudioEndpoint(EDataFlow dataFlow, ERole role, out IMMDevice endpoint);

		[PreserveSig]
		int GetDevice(string pwstrId, out IMMDevice ppDevice);
		
		[PreserveSig]
		int RegisterEndpointNotificationCallback(/*IMMNotificationClient pClient*/);
		
		[PreserveSig]
		int UnregisterEndpointNotificationCallback(/*IMMNotificationClient pClient*/);
	}
}
