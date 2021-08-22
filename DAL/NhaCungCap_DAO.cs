using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _102190014_NguyenHuyHoa.DTO;

namespace _102190014_NguyenHuyHoa.DAL
{
    public class NhaCungCap_DAO
    {
        private static NhaCungCap_DAO _instance = null;
        public static NhaCungCap_DAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new NhaCungCap_DAO();
                }
                return _instance;
            }
        }
        private NhaCungCap_DAO()
        {
        }
        QLKhoHang db = new QLKhoHang();
        public NhaCungCap GetNCCByNCC_Name_DAL(string n_name)
        {
            var s = db.NhaCungCaps.Single(i => i.NCC_Name == n_name);
            return s;
        }
        public NhaCungCap GetNCCByNCC_ID_DAL(int n_id)
        {
            var s = db.NhaCungCaps.Single(i => i.NCC_Id == n_id);
            return s;
        }
        public List<NhaCungCap> GetListOfSuppliers_DAL(string t_id)
        {
            List<NhaCungCap> dt = new List<NhaCungCap>();
            if (t_id == "00")
            {
                var b = from p in db.NhaCungCaps
                        select p;
                dt = b.ToList();
            }
            else
            {
                var b = from p in db.NhaCungCaps
                        where p.T_Id == t_id
                        select p;
                dt = b.ToList();
            }
            return dt;
        }
    }
}
