using System;
using System.Data.Entity;
using System.Linq;
using _102190014_NguyenHuyHoa.DTO;
namespace _102190014_NguyenHuyHoa.DAL
{
    public class QLKhoHang : DbContext
    {
        public QLKhoHang()
            : base("name=QLKhoHang")
        {
            Database.SetInitializer<QLKhoHang>(new DBInitializer());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public virtual DbSet<DiaChi> DiaChis { get; set; }
    }
}