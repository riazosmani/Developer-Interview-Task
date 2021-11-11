using System;
using System.IO;
using System.Web;

namespace InterviewTask.Services
{
    public class IPAddressService : IIPAddressService
    {
        private readonly HttpContext _context;
        private readonly string _ipAddress;

        public IPAddressService()
        {
            _context = HttpContext.Current;
            _ipAddress = _context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        }

        public void Go()
        {
            if (!string.IsNullOrEmpty(_ipAddress))
            {
                string[] addresses = _ipAddress.Split(',');

                if (addresses.Length != 0)
                {
                    WriteToTextFile(addresses[0], _context.Timestamp);
                }
            }
            else
            {
                WriteToTextFile(_context.Request.ServerVariables["REMOTE_ADDR"], _context.Timestamp);
            }
        }

        private void WriteToTextFile(string address, DateTime timeStamp)
        {
            string dirPath = "C:\\MarieCurie\\";
            string fullPath = string.Format("{0}Logs.txt", dirPath);

            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            string lineToWrite;
            using (StreamWriter writer = new StreamWriter(fullPath, true))
            {
                lineToWrite = string.Format("{0},{1}", address, timeStamp.ToString());
                writer.WriteLine(lineToWrite);
            }
        }
    }
}