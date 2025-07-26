namespace QLinkCleanerV2.Properties
{


    // 通过此类可以处理设置类的特定事件: 
    //  在更改某个设置的值之前将引发 SettingChanging 事件。
    //  在更改某个设置的值之后将引发 PropertyChanged 事件。
    //  在加载设置值之后将引发 SettingsLoaded 事件。
    //  在保存设置值之前将引发 SettingsSaving 事件。
    internal sealed partial class Settings
    {

        public Settings()
        {
            // // 若要为保存和更改设置添加事件处理程序，请取消注释下列行: 
            //
            this.SettingChanging += this.SettingChangingEventHandler;
            // this.PropertyChanged += this.SettingsChangedEventHandler;
            //
            // this.SettingsSaving += this.SettingsSavingEventHandler;
            //
        }

        private void SettingChangingEventHandler(object sender, System.Configuration.SettingChangingEventArgs e)
        {
            Default.Save();
            //MessageBox.Show("设置已更改，正在保存...", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // 在此处添加用于处理 SettingChangingEvent 事件的代码。
        }
        private void SettingsChangedEventHandler(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            // 在此处添加用于处理 PropertyChanged 事件的代码。
            //MessageBox.Show("设置已更改，正在保存...", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Default.Save();
        }

        private void SettingsSavingEventHandler(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // 在此处添加用于处理 SettingsSaving 事件的代码。

        }
    }
}
