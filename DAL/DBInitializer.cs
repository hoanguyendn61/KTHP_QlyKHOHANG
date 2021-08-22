using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _102190014_NguyenHuyHoa.DTO;
namespace _102190014_NguyenHuyHoa.DAL
{
    public class DBInitializer : DropCreateDatabaseAlways<QLKhoHang>
    {
        protected override void Seed(QLKhoHang context)
        {
            context.DiaChis.AddRange(new DiaChi[]
            {
                new DiaChi{T_Id = "DN", T_Name = "Danang" },
                new DiaChi{T_Id = "SG", T_Name = "Saigon" },
                new DiaChi{T_Id = "HN", T_Name = "Hanoi" },
            });
            context.NhaCungCaps.AddRange(new NhaCungCap[]
            {
                new NhaCungCap{NCC_Id = 1, NCC_Name = "Phi Long", T_Id = "DN"},
                new NhaCungCap{NCC_Id = 2, NCC_Name = "Van Linh", T_Id = "DN"},
                new NhaCungCap{NCC_Id = 3, NCC_Name = "Vingroup", T_Id = "HN"},
                new NhaCungCap{NCC_Id = 4, NCC_Name = "Ngoc Thanh", T_Id = "HN"},
                new NhaCungCap{NCC_Id = 5, NCC_Name = "Phuc An", T_Id = "SG"},
                new NhaCungCap{NCC_Id = 6, NCC_Name = "Vinh Khang", T_Id = "SG"},
            });
            context.SanPhams.AddRange(new SanPham[]
            {
                new SanPham{SP_Id = "101", SP_Name = "Lorem ipsum", SP_Gia = 10000, SP_SL = 11,SP_Ngay = Convert.ToDateTime("2021-08-22"), NCC_Id = 1},
                new SanPham{SP_Id = "102", SP_Name = "Dolor sit amet", SP_Gia = 20000, SP_SL = 11,SP_Ngay = Convert.ToDateTime("2021-08-22"), NCC_Id = 1},
                new SanPham{SP_Id = "103", SP_Name = "Consectetur adi", SP_Gia = 14000, SP_SL = 11,SP_Ngay = Convert.ToDateTime("2021-08-22"), NCC_Id = 2},
                new SanPham{SP_Id = "104", SP_Name = "Quis nostrud", SP_Gia = 13000, SP_SL = 11,SP_Ngay = Convert.ToDateTime("2021-08-22"), NCC_Id = 2},
                new SanPham{SP_Id = "105", SP_Name = "Ea commodo", SP_Gia = 11000, SP_SL = 11,SP_Ngay = Convert.ToDateTime("2021-08-22"), NCC_Id = 3},
                new SanPham{SP_Id = "106", SP_Name = "Excepteur sint", SP_Gia = 5000, SP_SL = 11,SP_Ngay = Convert.ToDateTime("2021-08-22"), NCC_Id = 3},
                new SanPham{SP_Id = "107", SP_Name = "Occaecat", SP_Gia = 6000, SP_SL = 11,SP_Ngay = Convert.ToDateTime("2021-08-22"), NCC_Id = 4},
                new SanPham{SP_Id = "108", SP_Name = "Velit esse", SP_Gia = 7000, SP_SL = 11,SP_Ngay = Convert.ToDateTime("2021-08-22"), NCC_Id = 4},
                new SanPham{SP_Id = "109", SP_Name = "Duis aute", SP_Gia = 4000, SP_SL = 11,SP_Ngay = Convert.ToDateTime("2021-08-22"), NCC_Id = 5},
                new SanPham{SP_Id = "110", SP_Name = "Reprehenderit", SP_Gia = 3000, SP_SL = 11,SP_Ngay = Convert.ToDateTime("2021-08-22"), NCC_Id = 5},
                new SanPham{SP_Id = "111", SP_Name = "Fugiat nulla", SP_Gia = 2000, SP_SL = 11,SP_Ngay = Convert.ToDateTime("2021-08-22"), NCC_Id = 6},

            });
        }
    }
}
