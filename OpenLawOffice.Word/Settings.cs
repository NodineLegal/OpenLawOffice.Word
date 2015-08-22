using System;
using Microsoft.Win32;
using NLog;

namespace OpenLawOffice.Word
{
    public class Settings
    {
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        public string ServerUrl
        {
            get { return _serverUrl; }
            set { _serverUrl = value; }
        }
        public bool LoggingEnabled
        {
            get { return _loggingEnabled; }
            set { _loggingEnabled = value; }
        }
        public string LogPath
        {
            get { return _logPath; }
            set { _logPath = value; }
        }
        public LogLevel LogLevel
        {
            get { return _logLevel; }
            set { _logLevel = value; }
        }
        public Guid MachineId
        {
            get { return _machineId; }
        }
        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }

        private Guid _machineId = Guid.Empty;
        private string _username;
        private string _serverUrl;
        private string _logPath;
        private string _key;
        private bool _loggingEnabled;
        private LogLevel _logLevel;

        public Settings()
        {
            InitializeRegistry();
        }

        private void InitializeRegistry()
        {
            try
            {
                RegistryKey OfficeRegKey = Registry.CurrentUser.OpenSubKey(@"Software\OpenLawOffice\Office", true);
                if (OfficeRegKey == null)
                {
                    OfficeRegKey = Registry.CurrentUser.CreateSubKey(@"Software\OpenLawOffice\Office", RegistryKeyPermissionCheck.ReadWriteSubTree);
                }

                string tempGuid, tempLogLevel;

                _username = GetRegKeyString(OfficeRegKey, "Username");
                _serverUrl = GetRegKeyString(OfficeRegKey, "ServerUrl");
                _loggingEnabled = GetRegKeyBool(OfficeRegKey, "LoggingEnabled");
                _logPath = GetRegKeyString(OfficeRegKey, "LogPath");
                _key = GetRegKeyString(OfficeRegKey, "Key");
                tempGuid = GetRegKeyString(OfficeRegKey, "MachineId");

                tempLogLevel = GetRegKeyString(OfficeRegKey, "LogLevel");
                if (tempLogLevel != null)
                {
                    _logLevel = LogLevel.FromString(tempLogLevel);
                }
                else
                    _logLevel = LogLevel.Error;

                if (_serverUrl != null)
                {
                    _serverUrl = (string)OfficeRegKey.GetValue("ServerUrl");
                    if (_serverUrl.EndsWith(@"\")) _serverUrl.TrimEnd(new char[] { '\\' });
                    if (!_serverUrl.EndsWith("/")) _serverUrl += "/";
                }

                if (string.IsNullOrEmpty(tempGuid))
                {
                    _machineId = Guid.NewGuid();
                    SetRegKey(OfficeRegKey, "MachineId", _machineId);
                }
                else
                {
                    _machineId = Guid.Parse(tempGuid);
                }

                OfficeRegKey.Close();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
        }

        public void Save()
        {
            if (_serverUrl.EndsWith(@"\")) _serverUrl.TrimEnd(new char[] { '\\' });
            if (!_serverUrl.EndsWith("/")) _serverUrl += "/";

            RegistryKey OfficeRegKey = Registry.CurrentUser.OpenSubKey(@"Software\OpenLawOffice\Office", true);
            SetRegKey(OfficeRegKey, "Username", _username);
            SetRegKey(OfficeRegKey, "ServerUrl", _serverUrl);
            SetRegKey(OfficeRegKey, "LoggingEnabled", _loggingEnabled);
            SetRegKey(OfficeRegKey, "LogPath", _logPath);
            SetRegKey(OfficeRegKey, "LogLevel", _logLevel.Name);
            SetRegKey(OfficeRegKey, "Key", _key);
            OfficeRegKey.Close();
        }

        private string GetRegKeyString(RegistryKey subKey, string name)
        {
            string val;
            if (subKey.GetValue(name) != null)
            {
                val = (string)subKey.GetValue(name);
                if (!string.IsNullOrEmpty(val))
                    return val;
            }
            return null;
        }

        private bool GetRegKeyBool(RegistryKey subKey, string name)
        {
            object obj = subKey.GetValue(name);
            if (subKey.GetValue(name) != null)
                return bool.Parse((string)subKey.GetValue(name));

            return false;
        }

        private void SetRegKey(RegistryKey subKey, string name, string value)
        {
            if (value == null)
                subKey.SetValue(name, "");
            else
                subKey.SetValue(name, value);
        }

        private void SetRegKey(RegistryKey subKey, string name, bool value)
        {
            subKey.SetValue(name, value);
        }

        private void SetRegKey(RegistryKey subKey, string name, Guid value)
        {
            subKey.SetValue(name, value);
        }
    }
}
