using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _102190014_NguyenHuyHoa.DTO;
using _102190014_NguyenHuyHoa.DAL;
namespace _102190014_NguyenHuyHoa.BLL
{
    public class NhaCungCap_BLL
    {
        private static NhaCungCap_BLL _instance = null;
        public static NhaCungCap_BLL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new NhaCungCap_BLL();
                }
                return _instance;
            }
        }
        private NhaCungCap_BLL()
        {
        }
        public NhaCungCap GetNCCByNCC_Name_BLL(string n_name)
        {
            return NhaCungCap_DAO.Instance.GetNCCByNCC_Name_DAL(n_name);
        }
        public NhaCungCap GetNCCByNCC_ID_BLL(int n_id)
        {
            return NhaCungCap_DAO.Instance.GetNCCByNCC_ID_DAL(n_id);
        }
        public List<NhaCungCap> GetListOfSuppliers_BLL(string t_id)
        {
            return NhaCungCap_DAO.Instance.GetListOfSuppliers_DAL(t_id);
        }
    }
}
