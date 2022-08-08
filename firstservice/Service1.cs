using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.ServiceProcess;
using System.Timers;
using Helper;
using SqlTest_CSharp;

namespace firstservice
{
    public partial class Service1 : ServiceBase
    {
        readonly int Scheduletime = Convert.ToInt32(ConfigurationManager.AppSettings["Threadtime"]);
        private Timer _timer = new Timer();
        public Service1()
        {
            InitializeComponent();
        }
        public void OnDebug()
        {
            Working();
        }
        protected override void OnStart(string[] args)
        {
            try
            {
                _timer.Interval = 1000;
                _timer.Elapsed += ElapsedEventHandler;
                _timer.Enabled = true;
                _timer.Start();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void ElapsedEventHandler(object sender, ElapsedEventArgs e)
        {
            Working();
        }
        public void Working()

        {
            _timer.Enabled = false;

            EmployeeDAL employeeDAL = new EmployeeDAL();
            List<Employee> employees = employeeDAL.GetEmployeeData();
            String path = "c:\\sample.txt";
            using (StreamWriter writer = new StreamWriter(path, true))
            {

                writer.WriteLine(String.Format("windows service is called on" + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt" + "")));
                writer.Close();
            }
            _timer.Enabled = true;

        }

        protected override void OnStop()
        {
        }
    }
}
