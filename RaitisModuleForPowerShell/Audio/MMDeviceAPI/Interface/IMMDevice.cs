﻿using System;
using System.Runtime.InteropServices;
using RaitisModuleForPowerShell.Audio.MMDeviceAPI.Enumerations;

namespace RaitisModuleForPowerShell.Volume.Interface {
	[Guid("D666063F-1587-4E43-81F1-B948E807363F"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IMMDevice {
		[PreserveSig]
		int Activate(ref Guid id, CLSCTX clsCtx, IntPtr pActivationParams, [MarshalAs(UnmanagedType.IUnknown)] out object ppInterface);
	}
}
