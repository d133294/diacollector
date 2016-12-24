//!CompilerOption:AddRef:System.ServiceModel.Web.dll
using System;
using System.Windows;
using Zeta.Common.Plugins;
using DiaCollector.Helpers;
using Zeta.Bot;
using Zeta.Common;
using System.Linq;

namespace DiaCollector
{
    public class DiaCollectorPlugin : IPlugin
    {
        private const string _author = "rrrix,d1g1t4l";
        private const string _name = "DiaCollector";
        private const string _description = "Comming Soon!!";
        private Window _displayWindow;


        public bool Equals(IPlugin other)
        {
            return Name == other.Name && Version == other.Version;
        }

        public void OnPulse()
        {
            DiaCollector.Instance.OnPulse();
        }

        public void OnInitialize()
        {
            LoggerIt.Log("version ",DiaCollector.PluginVersion," Initialized");

        }

        public void OnShutdown()
        {

        }

        public void OnEnabled()
        {
            DiaCollector.Instance.Startup();
        }

        public void OnDisabled()
        {
            DiaCollector.Instance.Shutdown();
        }

        public string Author
        {
            get { return _author; }
        }

        public Version Version
        {
            get { return DiaCollector.PluginVersion; }
        }

        public string Name
        {
            get { return _name; }
        }

        public string Description
        {
            get { return _description; }
        }

        public Window DisplayWindow
        {
            get { return _displayWindow; }
        }
    }
}
