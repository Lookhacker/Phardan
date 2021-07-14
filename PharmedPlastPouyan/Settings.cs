using System;
using System.IO;
using License;
namespace PharmedPlastPouyan.Properties
{
    internal sealed partial class Settings
    {
        ServerConfig Server = new ServerConfig();

        public Settings()
        {
            this.SettingsLoaded += Settings_SettingsLoaded;
            this.SettingsSaving += Settings_SettingsSaving;
            Server.FirstRun();
        }
        private void Settings_SettingsLoaded(object sender, System.Configuration.SettingsLoadedEventArgs e)
        {
            this["PharmedPlastDBConnectionString"] = Server.ConnectionString;
        }
        private void Settings_SettingsSaving(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this["UserID"] = "";
            this["UserPassword"] = "";
            this["DataBaseName"] = "";
            this["IPServer"] = "";
        }

    }
}
