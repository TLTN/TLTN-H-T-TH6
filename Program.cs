using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using System.Threading;
using System.ComponentModel;

namespace TH6
{
    public class Person
    {
        public string Hoten, Quequan;
        public int Namsinh;

        public Person()
        {
            Hoten = string.Empty;
            Quequan= string.Empty;
            Namsinh = 0;
        }

        public Person(string hoten, string quequan, int namsinh)
        {
            Hoten = hoten;
            Quequan = quequan;
            Namsinh = namsinh;
        }

        public virtual void Nhap()
        {
            do
            {
                Console.Write("Nhập họ tên: "); Hoten = Console.ReadLine();
            } while (Hoten == "");
            do
            {
                Console.Write("Nhập quê quán: "); Quequan = Console.ReadLine();
            } while (Quequan == "");
            do
            {
                Console.Write("Nhập năm sinh: "); Namsinh = int.Parse(Console.ReadLine());
            } while (Namsinh < 1900);
        }

        public virtual void HienThi()
        {
            Console.Write($"Họ tên sinh viên: {Hoten}\t\t Quê quán: {Quequan}\t\t Năm sinh: {Namsinh}\t\t");
        }
    }

    public class SinhVien : Person
    {
        public int masv;
        public string lop;

        public SinhVien() : base()
        {
            masv = 0;
            lop = string.Empty;
        }

        public SinhVien(string ht, string qq, int ns, int masv, string lop) : base(ht, qq, ns)
        {
            this.masv = masv;
            this.lop = lop;
            Hoten = ht;
            Quequan = qq;
            Namsinh = ns;
        }

        public override void Nhap()
        {
            base.Nhap();
            do
            {
                Console.Write("Nhập mã sinh viên: "); masv = int.Parse(Console.ReadLine());
            } while (masv <= 0);
            do
            {
                Console.Write("Nhập lớp: "); lop = Console.ReadLine();
            } while (lop == "");
        }

        public override void HienThi()
        {
            base.HienThi();
            Console.WriteLine($"Mã sinh viên: {masv}\t Lớp: {lop}");
        }
    }

    public class QuanLy
    {
        private int soluongsv;
        private Person[] sv;

        public QuanLy()
        {
            soluongsv = 0;
            sv = new Person[0];
        }

        public QuanLy(int soluongnv, int n)
        {
            this.soluongsv = soluongnv;
            sv = new Person[n];
        }

        public void Nhap()
        {
            do
            {
                Console.Write("Nhập số lượng sinh viên: "); soluongsv = int.Parse(Console.ReadLine());
            } while (soluongsv <= 0);
            sv = new Person[soluongsv];

            for (int i = 0; i < soluongsv; i++)
            {         
                Console.WriteLine($"Sinh viên thứ {i + 1}");          
                Person sv1 = new SinhVien();
                sv1.Nhap();
                sv[i] = sv1;
            }
        }

        public void HienThi()
        {
            Console.WriteLine("Danh sách nhân viên: ");
            for (int i = 0; i < soluongsv; i++)
            {
                sv[i].HienThi();
            }
        }
    }

    class Program
    {
        public static void Main()
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.Cyan;

            QuanLy ql = new QuanLy();
            ql.Nhap();
            Console.Clear();
            ql.HienThi();

            Console.ReadKey();
        }
    }
}