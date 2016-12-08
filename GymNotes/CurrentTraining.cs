using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymNotes
{
    public class CurrentTraining
    {
        public static CurrentTraining Instance => _instance ?? (_instance = new CurrentTraining());
        private static CurrentTraining _instance;
        

    }
}
