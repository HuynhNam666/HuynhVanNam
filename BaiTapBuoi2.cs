using System;
using System.Globalization;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
    // Lớp Student
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Đảm bảo console hỗ trợ Unicode tiếng Việt
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            // Tạo danh sách học sinh
            List<Student> students = new List<Student>
            {
                new Student { Id = 1, Name = "An", Age = 16 },
                new Student { Id = 2, Name = "Bình", Age = 17 },
                new Student { Id = 3, Name = "Anh", Age = 15 },
                new Student { Id = 4, Name = "Cường", Age = 18 },
                new Student { Id = 5, Name = "Dũng", Age = 14 }
            };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== MENU QUẢN LÝ HỌC SINH =====");
                Console.WriteLine("1. In toàn bộ danh sách học sinh");
                Console.WriteLine("2. Học sinh có tuổi từ 15 đến 18");
                Console.WriteLine("3. Học sinh có tên bắt đầu bằng chữ 'A'");
                Console.WriteLine("4. Tổng tuổi của tất cả học sinh");
                Console.WriteLine("5. Học sinh có tuổi lớn nhất");
                Console.WriteLine("6. Sắp xếp danh sách học sinh theo tuổi tăng dần");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chức năng: ");
                string choice = Console.ReadLine();

                Console.WriteLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("a. Danh sách học sinh:");
                        foreach (var s in students)
                            Console.WriteLine($"\tId: {s.Id}, Tên: {s.Name}, Tuổi: {s.Age}");
                        break;
                    case "2":
                        var tuoi1518 = students.Where(s => s.Age >= 15 && s.Age <= 18).ToList();
                        Console.WriteLine("b. Học sinh có tuổi từ 15 đến 18:");
                        foreach (var s in tuoi1518)
                            Console.WriteLine($"\tId: {s.Id}, Tên: {s.Name}, Tuổi: {s.Age}");
                        break;
                    case "3":
                        var tenA = students.Where(s => s.Name.StartsWith("A", StringComparison.OrdinalIgnoreCase)).ToList();
                        Console.WriteLine("c. Học sinh có tên bắt đầu bằng chữ 'A':");
                        foreach (var s in tenA)
                            Console.WriteLine($"\tId: {s.Id}, Tên: {s.Name}, Tuổi: {s.Age}");
                        break;
                    case "4":
                        int tongTuoi = students.Sum(s => s.Age);
                        Console.WriteLine($"d. Tổng tuổi của tất cả học sinh: {tongTuoi}");
                        break;
                    case "5":
                        int maxAge = students.Max(s => s.Age);
                        var hsLonNhat = students.Where(s => s.Age == maxAge).ToList();
                        Console.WriteLine("e. Học sinh có tuổi lớn nhất:");
                        foreach (var s in hsLonNhat)
                            Console.WriteLine($"\tId: {s.Id}, Tên: {s.Name}, Tuổi: {s.Age}");
                        break;
                    case "6":
                        var sapXepTuoi = students.OrderBy(s => s.Age).ToList();
                        Console.WriteLine("f. Danh sách học sinh theo tuổi tăng dần:");
                        foreach (var s in sapXepTuoi)
                            Console.WriteLine($"\tId: {s.Id}, Tên: {s.Name}, Tuổi: {s.Age}");
                        break;
                    case "0":
                        Console.WriteLine("Kết thúc chương trình.");
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                        break;
                }
                Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục...");
                Console.ReadKey();
            }
        }
    }
}