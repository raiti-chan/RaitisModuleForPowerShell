using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaitisModuleForPowerShell.Window {
	public class WindowObject {

		public ushort ProcessId { get; }

		public string ProcessName { get; }

		public IntPtr WindowHandlePtr { get; }

		public string WindowTitle { get; }


		internal WindowObject(ushort processId, string processName, IntPtr ptr, string windowTitle) {
			this.ProcessId = processId;
			this.ProcessName = processName;
			this.WindowHandlePtr = ptr;
			this.WindowTitle = windowTitle;
		}

	}
}
