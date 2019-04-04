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
        public String[] animeUsers;
        public String[] FileToArray(String fileLocation)
        {
            String[] tmp = File.ReadAllLines(fileLocation);
            return tmp;
        }
        public String[] FilterArray(String[] sourceArray, string filter)
        {
            List<String> tmp = new List<string>();
            for (int i=0;i<sourceArray.Length;i++)
            {
                if (sourceArray[i].Contains(filter))
                    tmp.Add(sourceArray[i]);
            }
            String[] tmp_ship = tmp.ToArray();
            return tmp_ship;
        }
    }
}
