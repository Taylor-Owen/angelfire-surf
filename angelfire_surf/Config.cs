using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace angelfire_surf
{
    class Config
    {
        public bool windowsAlwaysOnTop;
        public bool checkValidity;
        public void LoadConfig()
        {
            File.Open("config.cfg", FileMode.OpenOrCreate);

        }
    }
}
