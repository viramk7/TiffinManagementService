using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.WebClient
{
    public sealed class WebClientHelper
    {
        private static readonly WebClientHelper instance = new WebClientHelper();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static WebClientHelper()
        {

        }

        private WebClientHelper()
        {

        }

        public static WebClientHelper Instance
        {
            get
            {
                return instance;

            }
        }
        
    }
}

