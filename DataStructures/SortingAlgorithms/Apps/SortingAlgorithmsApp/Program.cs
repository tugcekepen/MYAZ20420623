using SortingAlgorithms;
using SortingAlgorithmsApp;
using System.Data.SQLite;

string connectionString = "Data Source=D:\\MYAZ20420623\\DataStructures\\SortingAlgorithms\\Apps\\SortingAlgorithmsApp\\Employee.db;Version=3;";
string sql = "SELECT * FROM Employees";

SQLiteConnection connection = new SQLiteConnection(connectionString);

connection.Open();

SQLiteCommand command = new SQLiteCommand(sql, connection);
SQLiteDataReader reader = command.ExecuteReader();

Employee[] employees = new Employee[1000];

int i = 0;
while (reader.Read())
{
    employees[i] = new Employee(
        int.Parse(reader["Id"].ToString()),
        reader["FirstName"].ToString(),
        reader["LastName"].ToString(),
        Convert.ToDouble(reader["Salary"]));
    i++;
}
reader.Close();

Console.WriteLine("Tüm veriler");
Console.WriteLine("---------------------------------------");
foreach (Employee employee in employees)
{
    Console.WriteLine($"{employee.FirstName} {employee.LastName} {employee.Salary}");
}
Console.WriteLine("---------------------------------------");
Console.WriteLine("Sıralama Algoritmaları");
Console.WriteLine("1 - Bubble Sort (Salary'e göre)");
Console.WriteLine("2 - Insertion Sort (FirstName'e göre)");
Console.WriteLine("3 - Merge Sort (LastName'e göre)");
Console.WriteLine("4 - Quick Sort (Salary'e göre)");

Console.Write("Sıralama algoritması seçiniz: ");
string opt = Console.ReadLine();

switch (opt)
{
    case "1":
        var salaries1 = employees.Select(e => e.Salary).ToArray();
        BubbleSort.Sort<double>(salaries1);
        foreach (var item in salaries1)
                Console.WriteLine($"{item} -> {employees.Where<Employee>(e => e.Salary == item).FirstOrDefault().FirstName} {employees.Where<Employee>(e => e.Salary == item).FirstOrDefault().LastName}");
        break;
    case "2":
        var firstNames = employees.Select(e => e.FirstName).ToArray();
        InsertionSort.Sort<string>(firstNames);
        foreach (var item in firstNames)
            Console.WriteLine($"{item} {employees.Where<Employee>(e => e.FirstName == item).FirstOrDefault().LastName} -> ID: {employees.Where<Employee>(e => e.FirstName == item).FirstOrDefault().Id}");
        break;
    case "3":
        var lastNames = employees.Select(e => e.LastName).ToArray();
        MergeSort.Sort<string>(lastNames);
        foreach (var item in lastNames)
            Console.WriteLine($"{employees.Where<Employee>(e => e.LastName == item).FirstOrDefault().FirstName} {item} -> ID: {employees.Where<Employee>(e => e.LastName == item).FirstOrDefault().Id}");
        break;
    case "4":
        var salaries2 = employees.Select(e => e.Salary).ToArray();
        QuickSort.Sort<double>(salaries2);
        foreach (var item in salaries2)
            Console.WriteLine($"{item} -> {employees.Where<Employee>(e => e.Salary == item).FirstOrDefault().FirstName} {employees.Where<Employee>(e => e.Salary == item).FirstOrDefault().LastName}");
        break;
    default: 
        Console.WriteLine("Yanlış seçim yaptınız!");
        break;
}

connection.Close();