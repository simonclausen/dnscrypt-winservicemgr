using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceProcess;

namespace dnscrypt_winservicemgr
{
    class ServiceMgr
    {
        public static void stopService(string serviceName, int timeoutMilliseconds)
        {
            ServiceController service = new ServiceController(serviceName);
            try
            {
                TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);

                service.Stop();
                service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
            }
            catch
            {
                // ...
            }
        }
    }
}
