using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace QLinkCleanerV2.Core
{
    public class AdminOperations
    {
        public static void RunAdminOperation()
        {
            // 检查是否以管理员身份运行
            if (!IsRunAsAdmin())
            {
                // 以管理员身份重新启动当前应用程序
                RestartAsAdmin();
                return;
            }

            // 执行需要管理员权限的操作
            MessageBox.Show("应用程序以管理员身份运行。");
            // 例如，修改系统文件或注册表
        }

        private static bool IsRunAsAdmin()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private static void RestartAsAdmin()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                Verb = "runas",
                FileName = Application.ExecutablePath,
                Arguments = "AdminOperation"
            };

            try
            {
                Process.Start(startInfo);
                Application.Exit(); // 退出当前应用程序
            }
            catch (Exception ex)
            {
                // 用户取消或出现其他错误
                MessageBox.Show("无法以管理员身份启动应用程序: " + ex.Message);
            }
        }
    }
}
