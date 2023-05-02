
using CollectionConsoleApp;

void Collectionweek3sube2()
{
    /*
    //var arr = new char[] { 'a', 'h', 'm', 'e', 't' };
    //var arr = "ahmet".ToArray(); //böyle de yapılabiliyor.
    var arr = "ahmet".ToList(); //böyle ise listeleştirdik. koleksiyonlaştırdık.
    foreach (var item in "parlak")
    {
        arr.Add(item);
    }

    //char'lar arasında tekrar edenleri göstermesin;

    //-----------uzun yol

    //var result = new List<char>();
    //foreach (var item in arr) 
    //{
    //    if (result.Contains(item))
    //    {
    //        continue;
    //    }
    //    result.Add(item);
    //}
    //result.ForEach(x => Console.Write(x));

    //-----------kısa yol

    var hashset = new HashSet<char>(arr);

    hashset
        .ToList()
        .ForEach(item => Console.Write(item));
    */

    //cars
    var list1 = new List<Customer>()
    {
        new Customer(){Id = 1, FullName =" Ahmet Can"},
        new Customer(){Id = 2, FullName =" Mehmet Dağ"},
        new Customer(){Id = 3, FullName =" Fatma Güneş"},
        new Customer(){Id = 4, FullName =" Can Bulut"},
        new Customer(){Id = 5, FullName =" Canan Nehir"}
    };

    // home
    var list2 = new List<Customer>()
    {
         new Customer(){Id = 1, FullName =" Ahmet Can"},
         new Customer(){Id = 4, FullName =" Can Bulut"},
         new Customer(){Id = 6, FullName =" Melike Güneş"},
    };

    // home + cars

    var result = new List<Customer>();

    foreach (Customer customer in list1)
    {
        if(list2.Select(c => c.Id).Contains(customer.Id))
        {
            result.Add(customer);
        }
    }

    result.ForEach(c => Console.WriteLine(c));
}

void Collectionweek3sube1()
{
    #region week-3-sube-1

    var g1 = new List<int>() { 10, 20, 30, 3 };
    var g2 = new List<int>() { 15, 25, 35, 10, 3 };
    var g3 = new List<int>() { 10, 15, 20, 25, 40, 50, 40, 50, 3 };

    // Tekrar etmeyecek şekilde tüm elemanlar

        #region uzunyol
        /*
        var list = new List<int>();
        list.AddRange(g1);
        list.AddRange(g2);
        list.AddRange(g3);
        for (int i = 0; i < list.Count; i++)
        {
            for (int j = i+1; j < list.Count; j++)
            {
                if (list[i].Equals(list[j]))
                {
                    list.RemoveAt(j);
                    j--;
                }
            }
        }
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }*/
        #endregion

    //-----------kısa yol (küme)
    g1
        .Union(g2)
        .Union(g3)          //bu yapıya "dot per line" denir.
        .ToList()
        .ForEach(x => Console.WriteLine(x));
    Console.WriteLine("-----------------");

    //Ortak elemanlar
    g1
        .Intersect(g2)
        .Intersect(g3)
        .ToList()
        .ForEach(x => Console.WriteLine(x));
    Console.WriteLine("-----------------");

    //g1'de olup g2'de olmayanlar
    g1
        .Except(g2)
        .ToList()
        .ForEach(x => Console.WriteLine(x));

    #endregion
}























#region Group
void Group1()
{
    var g1 = new List<int>() { 10, 25, 20, 30, 4 };
    var g2 = new List<int>() { 15, 25, 3, 35, 4 };
    var g3 = new List<int>() { 10, 15, 20, 25, 40, 50, 4 };

    // Semih : Tekrar etmeyecek şekilde tüm elemanlar
    // dot per line
    // O(n) + O(n) + O(n) = c.O(n)
    g1
        .Union(g2)
        .Union(g3)
        .ToList();
    //.ForEach(n => Console.WriteLine(n));


    // Umut Çerkezoğlu: Ortak elemanlar 
    // O(n*n*n) = O(n3) 10 * 10 * 10
    g1
        .Intersect(g2)
        .Intersect(g3)
        .ToList();
    //.ForEach(n => Console.WriteLine(n));

    g1
        .Except(g2)
        .ToList()
        .ForEach(n => Console.WriteLine(n));


    //var arr = new char[] { 'a', 'h', 'm', 'e', 't' };
    var list = "ahmet".ToList();

    foreach (var item in "parlak")
    {
        list.Add(item);
        Console.WriteLine($"{item,-4} {list.Count,-4} " +
            $"{list.Capacity,-4}");
    }

    var result = new List<char>();

    foreach (var item in list)
    {
        // item : a, h, m, e, t
        if (!result.Contains(item))
        {
            result.Add(item);
        }
    }

    result.ForEach(c => Console.Write(c));


    // 
    //  "meltem"
    //  char[] = {'m','e','l','t','e','m'}

    var list2 = "meltem".ToList();

    var hashset = new HashSet<char>(list2);

    // dot per line
    hashset
        .ToList()
        .ForEach(c => Console.Write(c));
}
#endregion