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
    public class HoaDon
    {
        public string makh, hotenkh;

        public HoaDon()
        {
            makh = string.Empty;
            hotenkh = string.Empty;
        }

        public HoaDon(string makh, string hotenkh)
        {
            this.makh = makh;
            this.hotenkh = hotenkh;
        }

        public virtual void Nhap()
        {
            do
            {
                Console.Write("Nhập mã khách hàng: "); makh = Console.ReadLine();
            } while (makh == "");
            do
            {
                Console.Write("Nhập họ tên khách hàng: "); hotenkh = Console.ReadLine();
            } while (hotenkh == "");
        }

        public virtual double TriGia()
        {
            return 0;
        }

        public virtual string DichVu()
        {
            return "";
        }    

        public virtual void HienThi()
        {
            Console.Write($"Mã khách hàng: {makh}\t\t Họ tên khách hàng: {hotenkh}\t\t Trị giá hóa đơn: {TriGia()}\t\t Dịch vụ: {DichVu()}\t\t");
        }
    }

    public class GiatTay : HoaDon
    {
        public double kg;
        
        public GiatTay() : base()
        {
            kg = 0;
        }

        public GiatTay(double kg) : base()
        {
            this.kg = kg;
        }

        public override void Nhap()
        {
            base.Nhap();
            do
            {
                Console.Write("Nhập số kg quần áo: "); kg = double.Parse(Console.ReadLine());
            } while (kg <= 0);    
        }

        public override double TriGia()
        {
            if (kg > 10)
                return kg * 50000 * 0.95;
            return kg * 50000;
        }

        public override string DichVu()
        {
            return "Giặt tẩy";
        }

        public override void HienThi()
        {
            base.HienThi();
            Console.WriteLine($"Số kg quần áo: {kg}");
        }
    }

    public class ThueXe : HoaDon
    {
        public double hour;

        public ThueXe() : base()
        {
            hour = 0;
        }

        public ThueXe(double hour) : base()
        {
            this.hour = hour;
        }

        public override void Nhap()
        {
            base.Nhap();
            do
            {
                Console.Write("Nhập số giờ thuê xe: "); hour = double.Parse(Console.ReadLine());
            } while (hour <= 0);
        }

        public override double TriGia()
        {
            if (hour > 7)
                return hour * 50000 * 0.9;
            return hour * 50000;
        }

        public override string DichVu()
        {
            return "Thuê xe";
        }

        public override void HienThi()
        {
            base.HienThi();
            Console.WriteLine($"Số giờ thuê xe: {hour}");
        }
    }

    public class QuanLy
    {
        private int soluonghd;
        private HoaDon[] hd;

        public QuanLy()
        {
            soluonghd = 0;
            hd = new HoaDon[0];
        }

        public QuanLy(int soluonghd, int n)
        {
            this.soluonghd = soluonghd;
            hd = new HoaDon[n];
        }

        public void Nhap()
        {
            do
            {
                Console.Write("Nhập số lượng hóa đơn: "); soluonghd = int.Parse(Console.ReadLine());
            } while (soluonghd <= 0);
            hd = new HoaDon[soluonghd];

            for (int i = 0; i < soluonghd; i++)
            {
                int chon;
                Console.WriteLine($"Hóa đơn thứ {i + 1}");
                do
                {
                    Console.Write("1_Giặt tẩy, 2_Thuê xe. Chọn (1-2): ");
                    chon = int.Parse(Console.ReadLine());
                } while (chon < 1 || chon > 2);
                switch (chon)
                {
                    case 1:
                        HoaDon hd1 = new GiatTay();
                        hd1.Nhap();
                        hd[i] = hd1;
                        break;
                    case 2:
                        HoaDon hd2 = new ThueXe();
                        hd2.Nhap();
                        hd[i] = hd2;
                        break;
                }
            }
        }

        public void HienThi()
        {
            Console.WriteLine("Danh sách hóa đơn: ");
            for (int i = 0; i < soluonghd; i++)
            {
                hd[i].HienThi();
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