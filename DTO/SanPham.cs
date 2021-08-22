using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _102190014_NguyenHuyHoa.DTO
{
    public class SanPham
    {
        [Key][Required][StringLength(10)]
        public string SP_Id { get; set; }
        [MaxLength(50)]
        public string SP_Name { get; set; }
        public float SP_Gia { get; set; }
        public int SP_SL { get; set; }
        public DateTime SP_Ngay { get; set; }
        public int NCC_Id { get; set; }
        [ForeignKey("NCC_Id")]
        public virtual NhaCungCap NhaCungCap { get; set; }
        public static int Compare_NameAZ(ProductData b1, ProductData b2)
        {
            return b1.Tên_SP.CompareTo(b2.Tên_SP);
        }
        public static int Compare_NameZA(ProductData b1, ProductData b2)
        {
            return b2.Tên_SP.CompareTo(b1.Tên_SP);
        }
        public static int Compare_PriceAsc(ProductData b1, ProductData b2)
        {
            return b1.Giá_nhập.CompareTo(b2.Giá_nhập);
        }
        public static int Compare_PriceDesc(ProductData b1, ProductData b2)
        {
            return b2.Giá_nhập.CompareTo(b1.Giá_nhập);
        }
    }
}
