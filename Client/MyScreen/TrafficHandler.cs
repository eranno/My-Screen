using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fiddler;
using System.Threading;

namespace MyScreen
{
    public class TrafficHandler
    {
        static bool isActicvated;
        static Proxy oSecureEndpoint;
        static string sSecureEndpointHostname = "localhost";
        static int iSecureEndpointPort = 7777;

        public static void DoQuit()
        {
            isActicvated = false;
            // WriteCommandResponse("Shutting down...");
            if (null != oSecureEndpoint) oSecureEndpoint.Dispose();
            Fiddler.FiddlerApplication.Shutdown();
            Thread.Sleep(500);
        }

        private static void start()
        {
            isActicvated = true;
            List<Fiddler.Session> oAllSessions = new List<Fiddler.Session>();
            List<String> list = new List<string>();

            Fiddler.FiddlerApplication.BeforeResponse += delegate(Fiddler.Session oSession)
            {
                //do stuff here.
            };

            Fiddler.CONFIG.IgnoreServerCertErrors = false;

            FiddlerApplication.Prefs.SetBoolPref("fiddler.network.streaming.abortifclientaborts", true);

            FiddlerCoreStartupFlags oFCSF = FiddlerCoreStartupFlags.Default;
            //Do no decrypt SSL traffic
            oFCSF = (oFCSF & ~FiddlerCoreStartupFlags.DecryptSSL);
            //Fiddler will auto select available port.
            Fiddler.FiddlerApplication.Startup(0, oFCSF);

            // We'll also create a HTTPS listener, useful for when FiddlerCore is masquerading as a HTTPS server
            // instead of acting as a normal CERN-style proxy server.
            oSecureEndpoint = FiddlerApplication.CreateProxyEndpoint(iSecureEndpointPort, true, sSecureEndpointHostname);
            if (null != oSecureEndpoint)
            {
                FiddlerApplication.Log.LogFormat("Created secure end point listening on port {0}, using a HTTPS certificate for '{1}'", iSecureEndpointPort, sSecureEndpointHostname);
            }

            while (isActicvated) ;
            DoQuit();
        }

        public static void activate()
        {
            Thread t = new Thread(start);
            t.Start();
        }
    }
}
