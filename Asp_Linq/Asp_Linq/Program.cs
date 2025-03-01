
using System.Runtime.Intrinsics.X86;
using System.Text.Json;
using Asp_Linq;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    public async static Task Main(String[] args)
    {
        List<Student> students = new List<Student>()
                {
                    new Student
                    {
                        id = 1,
                        name = "Santnu",
                        email = "santnu@gmail.com",
                        age = 21,
                        branch="CS"
                    },
                     new Student
                    {
                        id = 2,
                        name = "Sanya",
                        email = "sanya@gmail.com",
                        age = 17,
                        branch="IT"
                    },
                    new Student
                    {
                        id = 3,
                        name = "Durgesh",
                        email = "durgesh@gmail.com",
                        age = 20,
                        branch="ME"
                    },
                    new Student
                    {
                        id = 4,
                        name = "Abhay",
                        email = "abhay@gmail.com",
                        age = 15,
                        branch="EC"
                    },
                    new Student
                    {
                        id = 5,
                        name = "Somya",
                        email = "somya@gmail.com",
                        age = 11,
                        branch="IT"
                    },
                };


         //    Serialization: Convert objects into a specific format(like JSON, XML, or binary) for storage or transfer.
         //    Deserialization: Convert that format back into objects for use in your application.


        // Serelizaion
        //var ser = JsonSerializer.Serialize(students);
        //Console.WriteLine(ser);

    //// Deserelize
    //var des = JsonSerializer.Deserialize<List<Student>>(ser);
    //Console.WriteLine(des.FirstOrDefault().name);



    // Using Newtons json.
    var s_data = JsonConvert.SerializeObject(students);
        Console.WriteLine(s_data);


        var d_data = JsonConvert.DeserializeObject<List<Student>>(s_data);
        Console.WriteLine(d_data.FirstOrDefault().name);


        //foreach (var item in students)
        //{
        //    Console.WriteLine(item.name);
        //}

        var count = students.Count();

        //var res = students.Where(x=> x.id == 2).Select(x=>x).ToList(); 



        //var res = students.Where(x => x.id >= 2).Select(x => x).ToList();
        //foreach (var item in res)
        //{
        //    Console.WriteLine(item.id + " -> "+ item.name);

        //}



        //var res = students.Where(x => x.name.StartsWith("Sa")).Select(x => x).ToList();
        //foreach (var item in res)
        //{
        //    Console.WriteLine(item.id + " -> " + item.name);
        //}



        //var res = students.Where(x => x.id >= 2).Select(x => x).ToList().Take(2);
        //foreach (var item in res)
        //{
        //    Console.WriteLine(item.id + " -> " + item.name);

        //}

        //var res = students.Where(x => x.id >= 2).Select(x => x).ToList().TakeLast(2);
        //foreach (var item in res)
        //{
        //    Console.WriteLine(item.id + " -> " + item.name);
        //}


        //var nameContainsA = students.Where(s => s.name.Contains("a")).ToList();
        //Console.WriteLine("\nStudents whose name contains 'a':");
        //nameContainsA.ForEach(s => Console.WriteLine(s.name));



        //var res = students.OrderBy(s => s.name).ToList();
        //Console.WriteLine("\nStudents sorted by name:");
        //res.ForEach(s => Console.WriteLine(s.name));



        //var groupedByBranch = students.GroupBy(s => s.branch);
        //Console.WriteLine("\nStudents grouped by branch:");
        //foreach (var group in groupedByBranch)
        //{
        //    Console.WriteLine($"Branch: {group.Key}");
        //    foreach (var student in group)
        //    {
        //        Console.WriteLine($" - {student.name}");
        //    }
        //}




        //var branchCounts = students.GroupBy(s => s.branch)
        //                          .Select(g => new { Branch = g.Key, Count = g.Count() })
        //                          .ToList();
        //Console.WriteLine("\nCount of students in each branch:");
        //branchCounts.ForEach(b => Console.WriteLine($"{b.Branch}: {b.Count} students"));



        //var firstOlder18 = students.FirstOrDefault(s => s.age > 18);
        //Console.WriteLine("\nFirst student older than 18:");
        //if (firstOlder18 != null)
        //    Console.WriteLine($"{firstOlder18.name}, Age: {firstOlder18.age}");

        //var lastITStudent = students.LastOrDefault(s => s.branch == "IT");
        //Console.WriteLine("\nLast student in IT branch:");
        //if (lastITStudent != null)
        //    Console.WriteLine($"{lastITStudent.name}, Branch: {lastITStudent.branch}");




        //var skipFirstTwo = students.Skip(2).ToList();
        //Console.WriteLine("\nAll students except first 2:");
        //skipFirstTwo.ForEach(s => Console.WriteLine(s.name)); 

        //var skipLastTwo = students.SkipLast(2).ToList();
        //Console.WriteLine("\nAll students except first 2:");
        //skipLastTwo.ForEach(s => Console.WriteLine(s.name));
    }
}


