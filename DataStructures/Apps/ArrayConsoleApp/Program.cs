// Dependencies sağ tık -> Add Project Reference
//or
// cmd -> cd .\ArrayConsoleApp\ -> dotnet add .\ArrayConsoleApp.csproj\ reference ..\Array\

// Immutable - Değişmez!

// overloading 
var names1 = new Data_Structures.Array.Array("Ahmet", "Mehmet", "Büşra", "Can","Burcu"); // sadece Array() yazdığımızda c# kendi Array'i ile karıştırıp hangisi olduğunu çözümleyemediği için kütüphane adıyla birlikte belirttik.

var names2 = new Data_Structures.Array.Array();
names2.Add("Ahmet");
names2.Add("Mehmet");
names2.Add("Büşra");
names2.Add("Can");
names2.Add("Burcu");

var names3 = new Data_Structures.Array.Array{
    "Ahmet",
    "Mehmet",
    "Büşra",
    "Can",
    "Burcu"
};

/*
Console.WriteLine(names1.Count);        // 0 
Console.WriteLine(names1.Capasity);     // 5

Console.WriteLine(names2.Count);        // 5
Console.WriteLine(names2.Capasity);     // 8
*/
/*
var isimler = names1.Copy(1, 1);
foreach (var item in isimler)
{
    Console.WriteLine(item);
}
*/

names1.SetItem(1, "Melike");

foreach (var name in names1)
{
    Console.WriteLine(name);
}

var numbers = new int[] { 1, 2, 3 };
numbers[0] = 10;


foreach (var number in numbers)
{
    Console.WriteLine(number);
}

Console.ReadKey();
#region week-01
// array bir instance (örnektir)
var array = new Data_Structures.Array.Array();

    #region notlar
    // -  Bir sınıftan new'leme yapıyorsak ürettiğimiz şeye(burada "array") INSTANCE denir. !!!
    // -  instance üzerinden ulaştığımız bütün elemanlara ise INSTANCE MEMBER denir. !!! 
    // -  direkt Array.Array. ...  üzerinden yani sınıf üzerinden ulaştıklarımıza ise CLASS MEMBER denir. !!!
    #endregion

array.Add("Ahmet");     // 0    4       //instance member : "Ahmet"
array.Add("Mehmet");    // 1    4       //instance member : "Mehmet"
array.Add("Can");       // 2    4       //instance member : "Can"
array.Add("Filiz");     // 3    4       //instance member : "Filiz"
array.Add("Furkan");    // 4    8       //instance member : "Furkan"

//Console.WriteLine(array.RemoveItem(0));  // RemoveItem() metodu -> instance member'dır

Console.WriteLine(array.GetItem(array.Find("Can"))); ;      

foreach (var item in array)
{
    Console.WriteLine(item);
}

// _InnerArray[0]

Console.WriteLine(array.Count);
Console.WriteLine(array.GetItem(3));   
Console.Read();
#endregion