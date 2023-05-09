using System.Security.Cryptography;

namespace XXX
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Humans> list = FillCorp();


            var id = Console.ReadLine();
            var tempL = new List<Humans>();
            var temp = SearchUnders(list, id, ref tempL);
            if (temp != null)
            {
                foreach (var item in temp)
                {
                    Console.WriteLine($"{item.GetId()} {item.GetName()}");
                }
            }
            Console.ReadKey();
        }

        static List<Humans> FillCorp()
        {
            bool temp = true;
            List<Humans> listik = new List<Humans>();
            while (temp)
            {
                string bss = Console.ReadLine();
                if (bss == "end") { temp = false; break; }
                string uss = Console.ReadLine();

                if (bss.Contains(' ') && uss.Contains(' '))
                {
                    string[] bs = bss.Split(' ', 2);
                    string[] us = uss.Split(' ', 2);

                    if (listik.Exists(e => e.GetId() == bs[0]))
                    {
                        if (listik.Find(e => e.GetId() == bs[0]).GetName() == "Unknown name")
                        {
                            listik.Find(e => e.GetId() == bs[0]).SetName(bs[1]);
                        }
                        var tmpUs = new Humans(us[0], us[1]);
                        listik.Add(tmpUs);
                        listik.Find(e => e.GetId() == bs[0]).Append(tmpUs);
                    }

                    else
                    {
                        var usE = new Humans(us[0], us[1]);
                        var bsE = new Humans(bs[0], usE, bs[1]);
                        listik.Add(bsE);
                        listik.Add(usE);
                    }
                }
                else if (bss.Contains(' '))
                {
                    string[] bs = bss.Split(' ', 2);
                    if (listik.Exists(e => e.GetId() == bs[0]))
                    {
                        var tmpUs = new Humans(uss);
                        listik.Add(tmpUs);
                        listik.Find(e => e.GetId() == bs[0]).Append(tmpUs);
                    }

                    else
                    {
                        var usE = new Humans(uss);
                        var bsE = new Humans(bs[0], usE, bs[1]);
                        listik.Add(bsE);
                        listik.Add(usE);
                    }
                }
                else if (uss.Contains(' '))
                {
                    string[] us = uss.Split(' ', 2);
                    if (listik.Exists(e => e.GetId() == bss))
                    {
                        var tmpUs = new Humans(us[0], us[1]);
                        listik.Add(tmpUs);
                        listik.Find(e => e.GetId() == bss).Append(tmpUs);
                    }

                    else
                    {
                        var usE = new Humans(us[0], us[1]);
                        var bsE = new Humans(bss, usE);
                        listik.Add(bsE);
                        listik.Add(usE);
                    }
                }

                if (listik.Exists(e => e.GetId() == bss))
                {
                    var tmpUs = new Humans(uss);
                    listik.Add(tmpUs);
                    listik.Find(e => e.GetId() == bss).Append(tmpUs);
                }

                else
                {
                    var usE = new Humans(uss);
                    var bsE = new Humans(bss, usE);
                    listik.Add(bsE);
                    listik.Add(usE);
                }
            }
            return listik;
        }

        static List<Humans> SearchUnders(List<Humans> listik, string id, ref List<Humans> list)
        {
            var boss = listik.Find(e => e.GetId() == id || e.GetName() == id);
            if (boss != null)
            {
                if (boss.GetListOfUnders().Count == 0) { Console.WriteLine("No"); return null; }

                return Moving(boss.GetListOfUnders(), ref list);
            }

            Console.WriteLine("Такого работника не существует");
            return null;
        }

        static List<Humans> Moving(List<Humans> listik, ref List<Humans> list)
        {
            foreach (var item in listik)
            {
                list.Add(item);
                Moving(item.GetListOfUnders(), ref list);
            }
            return list.OrderBy(e => e.GetId()).ToList();
        }
    }
}