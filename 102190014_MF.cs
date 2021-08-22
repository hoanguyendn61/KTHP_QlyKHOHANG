using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _102190014_NguyenHuyHoa.DTO;
using _102190014_NguyenHuyHoa.BLL;
namespace _102190014_NguyenHuyHoa
{
    public partial class _102190014_MF : Form
    {
        public static string Dc_id { get; set; }
        public static NhaCungCap Ncc { get; set; }
        public _102190014_MF()
        {
            InitializeComponent();
            LoadData();
            this.dgvDS.Columns[0].Visible = false;
        }
        private void LoadData()
        {
            SetCBAddress();
            SetCBSupplier();
            LoadDSSP(Ncc.NCC_Id, Ncc.T_Id);
        }
        private void SetCBSupplier()
        {
            cbNCC.DataSource = NhaCungCap_BLL.Instance.GetListOfSuppliers_BLL(Dc_id);
            Ncc = NhaCungCap_BLL.Instance.GetNCCByNCC_Name_BLL(cbNCC.SelectedItem.ToString());
        }
        private void SetCBAddress()
        {
            cbTP.Items.Add(new CBBItem { Value = "00", Text = "All" });
            foreach (DiaChi i in DiaChi_BLL.Instance.GetListOfAddress_BLL())
            {
                cbTP.Items.Add(new CBBItem
                {
                    Value = i.T_Id,
                    Text = i.T_Name
                });
            }
            cbTP.SelectedIndex = 0;
            Dc_id = ((CBBItem)cbTP.SelectedItem).Value;
        }
        private void LoadDSSP(int n_id, string t_id)
        {
            dgvDS.DataSource = SanPham_BLL.Instance.GetListOfProducts_BLL(n_id, t_id);
        }
        private void cbTP_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dc_id = ((CBBItem)cbTP.SelectedItem).Value;
            SetCBSupplier();
        }
        private void cbNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            Ncc = NhaCungCap_BLL.Instance.GetNCCByNCC_Name_BLL(cbNCC.SelectedItem.ToString());
            LoadDSSP(Ncc.NCC_Id,Ncc.T_Id);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            _102190014_DF f = new _102190014_DF();
            f.d = new _102190014_DF.MyDel(LoadDSSP);
            f.ShowDialog();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            string id = dgvDS.CurrentRow.Cells[0].Value.ToString();
            _102190014_DF f = new _102190014_DF(id);
            f.d = new _102190014_DF.MyDel(LoadDSSP);
            f.ShowDialog();
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            List<string> LMSV = new List<string>();
            if (dgvDS.SelectedRows.Count > 0)
            {
                foreach(DataGridViewRow dr in dgvDS.SelectedRows)
                {
                    LMSV.Add(dr.Cells[0].Value.ToString());
                }
                if (SanPham_BLL.Instance.DeleteBook_BLL(LMSV))
                {
                    MessageBox.Show("Deleted successfully!", "Information", MessageBoxButtons.OK);
                } else
                {
                    MessageBox.Show("Failed to delete", "Information", MessageBoxButtons.OK);
                }
                LoadDSSP(Ncc.NCC_Id, Ncc.T_Id);
            }
        }
        private void btnSort_Click(object sender, EventArgs e)
        {
            //Tên SP, A->Z
            //Tên SP, Z->A
            //Giá, Cao->Thấp
            //Giá, Thấp->Cao
            List<ProductData> plist = new List<ProductData>();
            plist = SanPham_BLL.Instance.GetListOfProducts_BLL(Ncc.NCC_Id, Ncc.T_Id);
            switch (cbSort.SelectedIndex)
            {
                case 0:
                    dgvDS.DataSource = SanPham_BLL.Instance.SortListProduct_BLL(plist, SanPham.Compare_NameAZ);
                    break;
                case 1:
                    dgvDS.DataSource = SanPham_BLL.Instance.SortListProduct_BLL(plist, SanPham.Compare_NameZA);
                    break;
                case 2:
                    dgvDS.DataSource = SanPham_BLL.Instance.SortListProduct_BLL(plist, SanPham.Compare_PriceDesc);
                    break;
                case 3:
                    dgvDS.DataSource = SanPham_BLL.Instance.SortListProduct_BLL(plist, SanPham.Compare_PriceAsc);
                    break;
                default:
                    break;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                List<ProductData> blist = dgvDS.DataSource as List<ProductData>;
                dgvDS.DataSource = SanPham_BLL.Instance.SearchForProduct_BLL(blist, txtSearch.Text);
            } else
            {
                LoadDSSP(Ncc.NCC_Id, Ncc.T_Id);
            }
        }
    }
}
