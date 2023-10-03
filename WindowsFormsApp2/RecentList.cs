using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    class RecentList
    {
        public List<string> list = new List<string>();

        public void Add(string fileName)
        {
            if(list.Count < 5)
            {
                list.Add(fileName);
            }
            else
            {

            }
            
        }

        public void SaveData()
        {

        }

        public void LoadData()
        {

        }
    }
}
