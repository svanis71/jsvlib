// Classname: JSVLogger
// Author: Johan Svanström
// Created: 
//
// Copyright: 2007 ® Johan Svanström
// Description: 
//
// Revision history:
// 1.0 Class created
//
// License: 
/*
Copyright (c) <YEAR>, <OWNER>
All rights reserved.

Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:

    * Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
    * Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
    * Neither the name of the <ORGANIZATION> nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/

using System;
using System.Configuration;

namespace JSVLib.Logging
{
	public class JsvLogger : ILog
	{
		private readonly bool _isDebugEnabled;
		private readonly bool _isInfoEnabled;
		private readonly bool _isErrorEnabled;
		private readonly bool _isWarningEnabled;

		Type _typeToLog;

	    public JsvLogger(Type t)
	    {
	        TraceLevel = ConfigurationManager.AppSettings["TraceLevel"] ?? "Info";

	        _typeToLog = t;

			foreach (string traceLevels in TraceLevel.Split(','))
			{
				switch (traceLevels)
				{
					case "Error":
						_isErrorEnabled = true;
						break;
					case "Warning":
						_isWarningEnabled = true;
						_isErrorEnabled = true;
						break;
					case "Info":
						_isWarningEnabled = true;
						_isErrorEnabled = true;
						_isInfoEnabled = true;
						break;
					case "Debug":
						_isWarningEnabled = true;
						_isErrorEnabled = true;
						_isInfoEnabled = true;
						_isDebugEnabled = true;
						break;
				}

				if (IsDebugEnabled || IsWarnEnabled || IsInfoEnabled || IsErrorEnabled)
				{
					if (t != null)
						OutputString(string.Format("Logging initialized for object {0}", t.Name), "General");
					else
						OutputString(string.Format("Logging initialized for an unidentified object"), "General");
				}
			}
		}

		public JsvLogger()
			: this(null)
		{
		}

		#region ILog Members

		#region Debug

		public void Debug(object message)
		{
			OutputString(message, "Debug");
		}

		public void Debug(object message, Exception exception)
		{
			OutputString(message, "Debug");
			OutputString(exception.ToString(), "Debug");
		}

		public void DebugFormat(string format, params object[] args)
		{
			OutputString(string.Format(format, args), "Debug");
		}

		public void DebugFormat(string format, object arg0)
		{
			OutputString(string.Format(format, arg0), "Debug");
		}

		public void DebugFormat(string format, object arg0, object arg1)
		{
			OutputString(string.Format(format, arg0, arg1), "Debug");
		}

		public void DebugFormat(string format, object arg0, object arg1, object arg2)
		{
			OutputString(string.Format(format, arg0, arg1, arg2), "Debug");
		}

		public void DebugFormat(IFormatProvider provider, string format, params object[] args)
		{
			OutputString(string.Format(provider, format, args), "Debug");
		}

		#endregion

		#region Info

		public void Info(object message)
		{
			OutputString(message, "Info");
		}

		public void Info(object message, Exception exception)
		{
			OutputString(message, "Info");
			OutputString(exception.ToString(), "Info");
		}

		public void InfoFormat(string format, params object[] args)
		{
			OutputString(string.Format(format, args), "Info");
		}

		public void InfoFormat(string format, object arg0)
		{
			OutputString(string.Format(format, arg0), "Info");
		}

		public void InfoFormat(string format, object arg0, object arg1)
		{
			OutputString(string.Format(format, arg0, arg1), "Info");
		}

		public void InfoFormat(string format, object arg0, object arg1, object arg2)
		{
			OutputString(string.Format(format, arg0, arg1, arg2), "Info");
		}

		public void InfoFormat(IFormatProvider provider, string format, params object[] args)
		{
			OutputString(string.Format(provider, format, args), "Info");
		}

		#endregion

		#region Warning

		public void Warn(object message)
		{
			OutputString(message, "Warn");
		}

		public void Warn(object message, Exception exception)
		{
			OutputString(message, "Warn");
			OutputString(exception.ToString(), "Warn");
		}

		public void WarnFormat(string format, params object[] args)
		{
			OutputString(string.Format(format, args), "Warn");
		}

		public void WarnFormat(string format, object arg0)
		{
			OutputString(string.Format(format, arg0), "Warn");
		}

		public void WarnFormat(string format, object arg0, object arg1)
		{
			OutputString(string.Format(format, arg0, arg1), "Warn");
		}

		public void WarnFormat(string format, object arg0, object arg1, object arg2)
		{
			OutputString(string.Format(format, arg0, arg1, arg2), "Warn");
		}

		public void WarnFormat(IFormatProvider provider, string format, params object[] args)
		{
			OutputString(string.Format(provider, format, args), "Warn");
		}

		#endregion

		#region Error

		public void Error(object message)
		{
			OutputString(message, "Error");
		}

		public void Error(object message, Exception exception)
		{
			OutputString(message, "Error");
			OutputString(exception.ToString(), "Error");
		}

		public void ErrorFormat(string format, params object[] args)
		{
			OutputString(string.Format(format, args), "Error");
		}

		public void ErrorFormat(string format, object arg0)
		{
			OutputString(string.Format(format, arg0), "Error");
		}

		public void ErrorFormat(string format, object arg0, object arg1)
		{
			OutputString(string.Format(format, arg0, arg1), "Error");
		}

		public void ErrorFormat(string format, object arg0, object arg1, object arg2)
		{
			OutputString(string.Format(format, arg0, arg1, arg2), "Error");
		}

		public void ErrorFormat(IFormatProvider provider, string format, params object[] args)
		{
			OutputString(string.Format(provider, format, args), "Error");
		}
		#endregion

		#region Fatal

		public void Fatal(object message)
		{
			OutputString(message, "Fatal");
		}

		public void Fatal(object message, Exception exception)
		{
			OutputString(message, "Fatal");
			OutputString(exception.ToString(), "Fatal");
		}

		public void FatalFormat(string format, params object[] args)
		{
			OutputString(string.Format(format, args), "Fatal");
		}

		public void FatalFormat(string format, object arg0)
		{
			OutputString(string.Format(format, arg0), "Fatal");
		}

		public void FatalFormat(string format, object arg0, object arg1)
		{
			OutputString(string.Format(format, arg0, arg1), "Fatal");
		}

		public void FatalFormat(string format, object arg0, object arg1, object arg2)
		{
			OutputString(string.Format(format, arg0, arg1, arg2), "Fatal");
		}

		public void FatalFormat(IFormatProvider provider, string format, params object[] args)
		{
			OutputString(string.Format(provider, format, args), "Fatal");
		}

		#endregion

		#region Properties

		public bool IsDebugEnabled
		{
			get
			{
				return _isDebugEnabled;
			}
		}

		public bool IsInfoEnabled
		{
			get
			{
				return _isInfoEnabled;
			}
		}

		public bool IsWarnEnabled
		{
			get
			{
				return _isWarningEnabled;
			}
		}

		public bool IsErrorEnabled
		{
			get
			{
				return _isErrorEnabled;
			}
		}

		public bool IsFatalEnabled
		{
			get
			{
				return true;
			}
		}

	    public string TraceLevel { get; set; }

	    #endregion

		#endregion

		#region ILog Members


		public void DumpObject()
		{
		}

		#endregion

		private void OutputString(object s, string category)
		{
			OutputString(string.Format("{0}", s), category);
		}

		private void OutputString(string s, string category)
		{
			if ((category == "Error" && IsErrorEnabled)
				|| (category == "Warn" && IsWarnEnabled)
				|| ((category == "Info" || category == "General") && IsInfoEnabled)
				|| (category == "Debug" && IsDebugEnabled)
				|| (category == "Fatal"))
				System.Diagnostics.Debug.WriteLine(string.Format("{0}: {1}", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), s), category);

		}

	}
}
