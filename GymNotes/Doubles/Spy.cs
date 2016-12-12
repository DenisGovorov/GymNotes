using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymNotes.Doubles
{
    public class Spy
    {
        public List<MethodCall> Calls = new List<MethodCall>();

        public void Add(string name)
        {
            Calls.Add(new MethodCall("Add", name));
        }
        public void Remove(string name)
        {
            Calls.Add(new MethodCall("Remove", name));
        }
        public void Request(string name)
        {
            Calls.Add(new MethodCall("Request", name));
        }
    }

    public class MethodCall
    {
        public string MethodName;
        public string ItemName;
        public MethodCall(string methodName, string itemName)
        {
            MethodName = methodName;
            ItemName = itemName;
        }
    }
}
