﻿using System;
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
        public string Hoten, Diachi;
        public int Namsinh;

        public NhanVien()
        {
            Hoten = string.Empty;
            Diachi = string.Empty;
            Namsinh = 0;
        }

        public NhanVien(string hoten, string diachi, int namsinh)
        {
            Hoten = hoten;
            Diachi = diachi;
            Namsinh = namsinh;
        }

        public virtual void Nhap()
        {
            do
            {
                Console.Write("Nhập họ tên nhân viên: "); Hoten = Console.ReadLine();
            } while (Hoten == "");
            do
            {
                Console.Write("Nhập địa chỉ nhân viên: "); Diachi = Console.ReadLine();
            } while (Diachi == "");
            do
            {
                Console.Write("Nhập năm sinh: "); Namsinh = int.Parse(Console.ReadLine());
            } while (Namsinh < 1900);
        }

        public virtual double TinhLuong()
        {
            return 0;
        }

        public virtual void HienThi()
        {
            Console.WriteLine($"Họ tên nhân viên: {Hoten}\t\t Địa chỉ: {Diachi}\t\t Năm sinh: {Namsinh}\t\t Lương: {TinhLuong()}");
        }
    }

    public class NVSX : NhanVien
    {
        public int sosanpham;

        public NVSX() : base()
        {
            sosanpham = 0;
        }

        public NVSX(int sosanpham) : base()
        {
            this.sosanpham = sosanpham;
        }

        public override void Nhap()
        {
            base.Nhap();
            do
            {
                Console.Write("Nhập số sản phẩm: "); sosanpham = int.Parse(Console.ReadLine());
            } while (sosanpham < 0);
        }

        public override double TinhLuong()
        {
            return sosanpham * 20000;
        }

        public override void HienThi()
        {
            base.HienThi();
        }
    }

    public class NVCN : NhanVien
    {
        public int songaycong;

        public NVCN() : base()
        {
            songaycong = 0;
        }

        public NVCN(int songaycong) : base()
        {
            this.songaycong = songaycong;
        }

        public override void Nhap()
        {
            base.Nhap();
            do
            {
                Console.Write("Nhập số ngày công: "); songaycong = int.Parse(Console.ReadLine());
            } while (songaycong < 0);
        }

        public override double TinhLuong()
        {
            return songaycong * 20000;
        }

        public override void HienThi()
        {
            base.HienThi();
        }
    }

    public class NVQL : NhanVien
    {
        public double hsl, lcb;

        public NVQL() : base()
        {
            hsl = 0;
            lcb = 0;
        }

        public NVQL(double hesoluong, double luongcoban) : base()
        {
            hsl = hesoluong;
            lcb = luongcoban;
        }

        public override void Nhap()
        {
            base.Nhap();
            do
            {
                Console.Write("Nhập hệ số lương: "); hsl = double.Parse(Console.ReadLine());
            } while (hsl < 0);
            do
            {
                Console.Write("Nhập lương cơ bản: "); lcb = double.Parse(Console.ReadLine());
            } while (lcb <= 0);
        }

        public override double TinhLuong()
        {
            return hsl * lcb;
        }

        public override void HienThi()
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
                Console.WriteLine($"Nhân viên thứ {i+1}");
                do
                {
                    Console.Write("1_Sản xuất, 2_Công nhật, 3_Quản lí: Chọn (1-3): ");
                    chon = int.Parse(Console.ReadLine());
                } while (chon < 1 || chon > 3);
                switch(chon)
                {
                    case 1:
                        NhanVien nvsx = new NVSX();
                        nvsx.Nhap();
                        nv[i] = nvsx;
                        break;
                    case 2:
                        NhanVien nvcn = new NVCN();
                        nvcn.Nhap();
                        nv[i] = nvcn;
                        break;
                    case 3:
                        NhanVien nvql = new NVQL();
                        nvql.Nhap();
                        nv[i] = nvql;
                        break;
                }
            }   
        }

        public void HienThi()
        {
            Console.WriteLine("Danh sách nhân viên: ");
            for (int i = 0;i < soluongnv;i++)
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