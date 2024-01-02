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
    public class Phong
    {
        public int songaythue;
        public double dongia;

        public Phong()
        {
            songaythue = 0;
            dongia = 0;
        }

        public Phong(string loaiphong, int songaythue, double dongia)
        {
            this.songaythue = songaythue;
            this.dongia = dongia;
        }

        public virtual void Nhap()
        {
            do
            {
                Console.Write("Nhập số ngày thuê: "); songaythue = int.Parse(Console.ReadLine());
            } while (songaythue <= 0);
        }

        public virtual string LoaiPhong()
        {
            return "";
        } 

        public virtual double TongTien()
        {
            return dongia * songaythue;
        }

        public virtual void HienThi()
        {
            Console.Write($"Loại phòng: {LoaiPhong()}\t\t Số ngày thuê: {songaythue}\t\t Trị giá hóa đơn: {TongTien()}\t\t");
        }
    }

    public class PA : Phong
    {
        public double dichvu;

        public PA() : base()
        {
            dongia = 80;
            dichvu = 0;
        }

        public PA(double dichvu) : base()
        {
            this.dichvu = dichvu;
        }

        public override void Nhap()
        {
            base.Nhap();
            do
            {
                Console.Write("Nhập số tiền dịch vụ: "); dichvu = double.Parse(Console.ReadLine());
            } while (dichvu <= 0);    
        }

        public override string LoaiPhong()
        {
            return "A";
        }

        public override double TongTien()
        {
            if (songaythue > 5)
                return dongia * songaythue * 0.9 + dichvu;
            return dongia * songaythue + dichvu;
        }

        public override void HienThi()
        {
            base.HienThi();
            Console.WriteLine($"Tiền dịch vụ: {dichvu}");
        }
    }

    public class PB : Phong
    {
        public PB() : base()
        {
            dongia = 60;
        }

        public override void Nhap()
        {
            base.Nhap();
        }

        public override string LoaiPhong()
        {
            return "B";
        }

        public override double TongTien()
        {
            if (songaythue > 5)
                return dongia * songaythue * 0.9;
            return dongia * songaythue;
        }

        public override void HienThi()
        {
            base.HienThi();
            Console.WriteLine();
        }
    }

    public class PC : Phong
    {
        public PC() : base()
        {
            dongia = 40;
        }

        public override void Nhap()
        {
            base.Nhap();
        }

        public override string LoaiPhong()
        {
            return "C";
        }

        public override double TongTien()
        {
            return dongia * songaythue;
        }

        public override void HienThi()
        {
            base.HienThi();
            Console.WriteLine();
        }
    }

    public class QuanLy
    {
        private int soluongkh;
        private Phong[] p;

        public QuanLy()
        {
            soluongkh = 0;
            p = new Phong[0];
        }

        public QuanLy(int soluongkh, int n)
        {
            this.soluongkh = soluongkh;
            p = new Phong[n];
        }

        public void Nhap()
        {
            do
            {
                Console.Write("Nhập số lượng thuê phòng: "); soluongkh = int.Parse(Console.ReadLine());
            } while (soluongkh <= 0);
            p = new Phong[soluongkh];

            for (int i = 0; i < soluongkh; i++)
            {
                int chon;
                Console.WriteLine($"Phòng thứ {i + 1}");
                do
                {
                    Console.Write("1_Loại A, 2_Loại B, 3_Loại C. Chọn (1-3): ");
                    chon = int.Parse(Console.ReadLine());
                } while (chon < 1 || chon > 3);
                switch (chon)
                {
                    case 1:
                        Phong p1 = new PA();
                        p1.Nhap();
                        p[i] = p1;
                        break;
                    case 2:
                        Phong p2 = new PB();
                        p2.Nhap();
                        p[i] = p2;
                        break;
                    case 3:
                        Phong p3 = new PC();
                        p3.Nhap();
                        p[i] = p3;
                        break;
                }
            }
        }

        public void HienThi()
        {
            Console.WriteLine("Danh sách thuê phòng: ");
            for (int i = 0; i < soluongkh; i++)
            {
                p[i].HienThi();
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