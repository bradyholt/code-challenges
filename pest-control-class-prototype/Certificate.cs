using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class Certificate
    {
        public UserTest Test { get; set; }
        public string CertificateUri { get; set; }
        public IEnumerable<StateLicensure> StateCreditSubmissions { get; set; }
        public IEnumerable<string> SendToEmails { get; set; }
    }
