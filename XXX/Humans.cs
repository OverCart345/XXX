using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace XXX
{
    internal class Humans
    {
        string Name;
        string id;
        List<Humans> unders = new List<Humans>();

        public Humans(string code, Humans under, string name = "Unknown name")
        {
            Name = name;
            id = code;
            unders.Add(under);
        }

        public Humans(string code, string name = "Unknown name")
        {
            Name = name;
            id = code;
        }

        public void Append(Humans hmn)
        {
            unders.Add(hmn);
        }

        public static void ReplaceName(List<Humans> list, string code, string newName)
        {
            foreach (var item in list)
            {
                if (item.id == code && item.Name == "Unknown name") { item.Name = newName; }
                ReplaceName(item.GetListOfUnders(), code, newName);
            }
        }

        public List<Humans> GetListOfUnders() { { return unders; } }
        public string GetName() { { return Name; } }
        public void SetName(string name) { Name = name; }
        public string GetId() { return id; }
    }
}
