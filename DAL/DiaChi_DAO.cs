using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _102190014_NguyenHuyHoa.DTO;

namespace _102190014_NguyenHuyHoa.DAL
{
    public class DiaChi_DAO
    {
        private static DiaChi_DAO _instance = null;
        public static DiaChi_DAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DiaChi_DAO();
                }
                return _instance;
            }
        }
        private DiaChi_DAO()
        {
        }
        QLKhoHang db = new QLKhoHang();
        public List<DiaChi> GetListOfAddress_DAL()
        {
            List<DiaChi> dt = new List<DiaChi>();
            var b = from p in db.DiaChis
                    select p;
            dt = b.ToList();
            return dt;
        }
        public DiaChi GetAddressByID_DAL(string id)
        {
            DiaChi a = db.DiaChis.Single(i => i.T_Id == id);
            return a;
        }
    }
}
