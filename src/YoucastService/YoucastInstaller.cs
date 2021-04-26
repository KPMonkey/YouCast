using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace YoucastService
{
    [RunInstaller(true)]
    public class YoucastInstaller:Installer
    {
        private ServiceProcessInstaller process;
        private ServiceInstaller service;

        public YoucastInstaller()
        {
            process = new ServiceProcessInstaller();
            process.Account = ServiceAccount.LocalSystem;
            service = new ServiceInstaller();
            service.ServiceName = "Youcast";
            service.Description = "YouCast allows you to subscribe to channels and playlists on YouTube as video and audio podcasts in any standard podcatcher";
            service.DelayedAutoStart = true;
            service.StartType = ServiceStartMode.Automatic;
            Installers.Add(process);
            Installers.Add(service);
        }
    }
}

