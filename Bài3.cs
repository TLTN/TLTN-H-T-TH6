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
    public class NhanVien
    {
        public string Hoten, Quequan;
        public double hsl, lcb;

        public NhanVien()
        {
            Hoten = string.Empty;
            Quequan = string.Empty;
            hsl = 0;
            lcb = 0;
        }

        public NhanVien(string hoten, string quequan, double hsl, double lcb)
        {
            Hoten = hoten;
            Quequan = quequan;
            this.hsl = hsl;
            this.lcb = lcb;
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
                Console.Write("Nhập hệ số lương: "); hsl = double.Parse(Console.ReadLine());
            } while (hsl < 0);
            do
            {
                Console.Write("Nhập lương cơ bản: "); lcb = double.Parse(Console.ReadLine());
            } while (lcb <= 0);
        }

        public virtual double TinhLuong()
        {
            return 0;
        }

        public void HienThi()
        {
            Console.WriteLine($"Họ tên: {Hoten}\t\t Quê quán: {Quequan}\t\t Hệ số lương: {hsl}\t\t Lương cb: {lcb} \t\t Lương: {TinhLuong()}");
        }
    }

    public class GiaoVien : NhanVien
    {
        public override void Nhap()
        {
            base.Nhap();
        }

        public override double TinhLuong()
        {
            return lcb * hsl * 1.4;
        }

        public new void HienThi()
        {
            base.HienThi();
        }
    }

    public class NVHC : NhanVien
    {
        public override void Nhap()
        {
            base.Nhap();
        }

        public override double TinhLuong()
        {
            return hsl * lcb + 300000;
        }

        public new void HienThi()
        {
            base.HienThi();
        }
    }

    public class QuanLy
    {
        private int soluongnv;
        private NhanVien[] nv;

        public QuanLy()
        {
            soluongnv = 0;
            nv = new NhanVien[0];
        }

        public QuanLy(int soluongnv, int n)
        {
            this.soluongnv = soluongnv;
            nv = new NhanVien[n];
        }

        public void Nhap()
        {
            do
            {
                Console.Write("Nhập số lượng nhân viên: "); soluongnv = int.Parse(Console.ReadLine());
            } while (soluongnv <= 0);
            nv = new NhanVien[soluongnv];

            for (int i = 0; i < soluongnv; i++)
            {
                int chon;
                Console.WriteLine($"Nhân viên thứ {i + 1}");
                do
                {
                    Console.Write("1_Giáo viên, 2_Nhân viên hành chính. Chọn (1-2): ");
                    chon = int.Parse(Console.ReadLine());
                } while (chon < 1 || chon > 2);
                switch (chon)
                {
                    case 1:
                        NhanVien gv = new GiaoVien();
                        gv.Nhap();
                        nv[i] = gv;
                        break;
                    case 2:
                        NhanVien nvhc = new NVHC();
                        nvhc.Nhap();
                        nv[i] = nvhc;
                        break;
                }
            }
        }

        public void HienThi()
        {
            Console.WriteLine("Danh sách nhân viên: ");
            for (int i = 0; i < soluongnv; i++)
            {
                nv[i].HienThi();
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