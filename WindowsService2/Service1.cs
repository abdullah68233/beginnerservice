using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Threading;
using System.IO;
namespace WindowsService1
{
    [RunInstaller(true)]
    public partial class Service1 : ServiceBase
    {
        int Scheduletime = Convert.ToInt32(ConfigurationSettings.AppSettings["Threadtime"]);
        public Thread worker = null;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                ThreadStart start = new ThreadStart(Working);
                worker = new Thread(start);
                worker.Start();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Working()
        {
            while (true)
            {
                String path = "c:\\sample.txt";
                using (StreamWriter writer = new StreamWriter(path, true))
                {

                    writer.WriteLine(String.Format("windows service is called on" + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt" + "")));
                    writer.Close();
                }
                Thread.Sleep(Scheduletime * 60 * 1000);
            }
        }

        protected override void OnStop()
        {
            try
            {
                if (worker != null & worker.IsAlive)
                    worker.Abort();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
