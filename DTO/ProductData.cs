using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _102190014_NguyenHuyHoa.DTO
{
    public class ProductData
    {
        
        public string Sp_ID { get; set; }
        public string Tên_SP { get; set; }
        public float Giá_nhập { get; set; }
        public DateTime Ngày_nhập_hàng { get; set; }
        public bool Tình_trạng { get; set; }
        public string Nhà_cung_cấp { get; set; }
        public string Tỉnh_TP { get; set; }

    }
}
