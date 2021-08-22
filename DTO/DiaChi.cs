using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _102190014_NguyenHuyHoa.DTO
{
    public class DiaChi
    {
        public DiaChi()
        {
            NhaCungCaps = new HashSet<NhaCungCap>();
        }
        [Key][StringLength(2)]
        public string T_Id { get; set; }
        [MaxLength(50)]
        public string T_Name { get; set; }
        public virtual ICollection<NhaCungCap> NhaCungCaps { get; set; }
        public override string ToString()
        {
            return T_Name;
        }
    }
}
