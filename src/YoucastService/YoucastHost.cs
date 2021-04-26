using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceProcess;
using System.ServiceModel.Web;
using NLog;
using System.Configuration;

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
                var appSettings = ConfigurationManager.AppSettings;
                var apiName = appSettings["api_name"] ?? throw new Exception("Can't find api_name property in app.config");
                var apiKey = appSettings["api_key"] ?? throw new Exception("Can't find api_key property in app.config");

                var instance = new Service.YoutubeFeed(apiName, apiKey);
                serviceHost = new ServiceHost(instance);

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
