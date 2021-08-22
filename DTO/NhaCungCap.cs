using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _102190014_NguyenHuyHoa.DTO
{
    public class NhaCungCap
    {
        public NhaCungCap()
        {
            SanPhams = new HashSet<SanPham>();
        }
        [Key]
        public int NCC_Id { get; set; }
        [MaxLength(50)]
        public string NCC_Name { get; set; }
        public string T_Id { get; set; }
        public virtual ICollection<SanPham> SanPhams { get; set; }
        [ForeignKey("T_Id")]
        public virtual DiaChi DiaChi { get; set; }
        public override string ToString()
        {
            return NCC_Name;
        }
    }
}
