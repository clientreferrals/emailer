using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMail.Utility
{
    public abstract class Singleton<T> where T : Singleton<T>, new()
    {
        private static T _instance = new T();
        
        public static T Instance
        {
            get
            {
                if (_instance == null) _instance = new T();

                return _instance;
            }
        }
    }
}
