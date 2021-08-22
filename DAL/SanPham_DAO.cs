using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _102190014_NguyenHuyHoa.DTO;
namespace _102190014_NguyenHuyHoa.DAL
{
    public class SanPham_DAO
    {
        private static SanPham_DAO _instance = null;
        public static SanPham_DAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SanPham_DAO();
                }
                return _instance;
            }
        }
        private SanPham_DAO()
        {
        }
        QLKhoHang db = new QLKhoHang();
        public List<ProductData> GetListOfProducts_DAL(int n_id, string t_id)
        {
            var b = from p in db.SanPhams
                    join s in db.NhaCungCaps on p.NCC_Id equals s.NCC_Id
                    join a in db.DiaChis on s.T_Id equals a.T_Id
                    where (p.NCC_Id == n_id) && (s.T_Id == t_id)
                    select p;
            List<ProductData> dt = new List<ProductData>();
            foreach (var i in b)
            {
                dt.AddRange(new ProductData[]
                {
                    new ProductData()
                    {
                        Sp_ID = i.SP_Id,
                        Tên_SP = i.SP_Name,
                        Giá_nhập = i.SP_Gia,
                        Ngày_nhập_hàng = i.SP_Ngay,
                        Tình_trạng = Convert.ToBoolean(i.SP_SL),
                        Nhà_cung_cấp = i.NhaCungCap.NCC_Name,
                        Tỉnh_TP = i.NhaCungCap.DiaChi.T_Name
                    }
                });
            }
            return dt;
        }
        public SanPham GetSPByID_DAL(string spid)
        {
            SanPham s = db.SanPhams.Single(x => x.SP_Id == spid);
            return s;
        }
        public bool SaveProduct_DAL(SanPham b)
        {
            bool result = false;
            SanPham _b = db.SanPhams.Where(x => x.SP_Id == b.SP_Id).Select(x => x).SingleOrDefault();
            if (_b != null)
            {
                // UPDATE
                _b.SP_Name = b.SP_Name;
                _b.SP_Gia = b.SP_Gia;
                _b.SP_Ngay = b.SP_Ngay;
                _b.SP_SL = b.SP_SL;
                _b.NCC_Id = b.NCC_Id;
            }
            else
            {
                // ADD
                db.SanPhams.Add(b);
            }
            db.SaveChanges();
            result = true;
            return result;
        }
        public bool DeleteBook_DAL(List<string> mSP)
        {
            bool result = false;
            try
            {
                // REMOVE
                foreach(string i in mSP)
                {
                    SanPham _b = db.SanPhams.Where(b => b.SP_Id == i).Select(b => b).SingleOrDefault();
                    db.SanPhams.Remove(_b);
                }
            }
            catch (Exception)
            {
                return result;
            }
            finally
            {
                db.SaveChanges();
                result = true;
            }
            return result;
        }
    }
}
