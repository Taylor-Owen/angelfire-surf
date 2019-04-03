using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace angelfire_surf
{
    class usersList
    {
        public bool fileLoaded = false;
        public String[] users;
        public String[] FileToArray(String fileLocation)
        {
            String[] tmp = File.ReadAllLines(fileLocation);
            


            return tmp;
        }
    }
}
