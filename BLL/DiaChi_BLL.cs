using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _102190014_NguyenHuyHoa.DTO;
using _102190014_NguyenHuyHoa.DAL;
namespace _102190014_NguyenHuyHoa.BLL
{
    public class DiaChi_BLL
    {
        private static DiaChi_BLL _instance = null;
        public static DiaChi_BLL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DiaChi_BLL();
                }
                return _instance;
            }
        }
        private DiaChi_BLL()
        {
        }
        public List<DiaChi> GetListOfAddress_BLL()
        {
            return DiaChi_DAO.Instance.GetListOfAddress_DAL();
        }
        public DiaChi GetAddressByID_BLL(string id)
        {
            return DiaChi_DAO.Instance.GetAddressByID_DAL(id);
        }
    }
}
