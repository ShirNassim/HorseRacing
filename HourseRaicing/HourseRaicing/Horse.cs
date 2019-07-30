using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HourseRaicing
{
    class Horse
    {
        public Horse()
        {
            
            nowIn = 0;
        }

       // static Random rnd = new Random();
       // int step;
      //  int t=rnd.Next(50,150);
        int nowIn;
        
        public int progress()
        {

            nowIn += 10;
            return nowIn;
        }
        public int getProgess(Horse h)
        {
            return h.nowIn;
        }
    }
}
