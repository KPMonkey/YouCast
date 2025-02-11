﻿using System.ServiceProcess;


namespace YoucastService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new YoucastHost()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
