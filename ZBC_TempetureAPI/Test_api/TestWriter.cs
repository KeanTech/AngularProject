using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Test_api
{
    public class TestWriter : TextWriter, IDisposable
    {
        public override Encoding Encoding => GetEncoding();

        public Encoding GetEncoding()
        {
            return Encoding.UTF8;
        }
    }
}