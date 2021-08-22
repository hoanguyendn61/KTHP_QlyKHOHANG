using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _102190014_NguyenHuyHoa.DTO;
using _102190014_NguyenHuyHoa.DAL;
namespace _102190014_NguyenHuyHoa.BLL
{
    public class SanPham_BLL
    {
        public delegate int MyCompare(ProductData p1, ProductData p2);
        private static SanPham_BLL _instance = null;
        public static SanPham_BLL Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SanPham_BLL();
                }
                return _instance;
            }
        }
        private SanPham_BLL()
        {
        }
        public List<ProductData> GetListOfProducts_BLL(int n_id, string t_id)
        {
            return SanPham_DAO.Instance.GetListOfProducts_DAL(n_id, t_id);
        }
        public bool SaveProduct_BLL(SanPham b)
        {
            return SanPham_DAO.Instance.SaveProduct_DAL(b);
        }
        public SanPham GetSPByID_BLL(string spid)
        {
            return SanPham_DAO.Instance.GetSPByID_DAL(spid);
        }
        public bool DeleteBook_BLL(List<string> mSP)
        {
            return SanPham_DAO.Instance.DeleteBook_DAL(mSP);
        }
        public List<ProductData> SearchForProduct_BLL(List<ProductData> plist, string str)
        {
            var result = plist.Where(p => p.Tên_SP.Contains(str)
                                       || p.Nhà_cung_cấp.Contains(str)
                                       || p.Tỉnh_TP.Contains(str)
                                       || p.Giá_nhập.ToString().Contains(str)).ToList();
            return result;
        }
        public List<ProductData> SortListProduct_BLL(List<ProductData> LHH, MyCompare cmp)
        {
            LHH.Sort(new Comparison<ProductData>(cmp));
            return LHH;
        }
    }
}
