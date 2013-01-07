using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace DataHandler
{
    public class Messages
    {
        static ConcurrentQueue<String> cq;
        public static void init()
        {
            if (cq == null)
                cq = new ConcurrentQueue<String>();
        }

        public static void write(String url)
        {
            cq.Enqueue(url);
        }

        public static string read()
        {    
            string result = null;
            cq.TryDequeue(out result) ;
            return result;
        }
    }
}
