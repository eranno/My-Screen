using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MyScreen
{
    public class Messages
    {
        static Dictionary<String, String> data;
        public static void init()
        {
            if (data == null)
                data = new Dictionary<string, string>();
        }

        public static void write(String url)
        {
            Monitor.Enter(data);
            data.Add(url, null);
            Monitor.Exit(data);
        }

        //public static KeysCollection read(String url)
        //{
        //    if(Monitor.TryEnter(data))
        //        return data.Keys
        //    return null;
        //}
    }
}
