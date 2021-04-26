using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceProcess;
using System.ServiceModel.Web;
using NLog;

namespace YoucastService
{
    public partial class YoucastHost : ServiceBase
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        ServiceHost  serviceHost;
        public YoucastHost()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                serviceHost = new ServiceHost(typeof(Service.YoutubeFeed));


                Logger.Info("Opening ServiceHost");
                serviceHost.Open();
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry(ex.Message);
                Logger.Info(ex.Message);
            }
        }

        protected override void OnStop()
        {
            try
            {
                if (serviceHost != null)
                    serviceHost.Close();
            }
            catch (Exception ex)
            {
                Logger.Info(ex.Message);
            }
            finally
            {
                serviceHost = null;
            }      
        }
    }
}
