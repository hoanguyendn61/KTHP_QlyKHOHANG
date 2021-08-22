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
using System.Globalization;

namespace _102190014_NguyenHuyHoa
{
    public partial class _102190014_DF : Form
    {
        public string P_ID { get; set; }
        public _102190014_DF()
        {
            InitializeComponent();
            SetCBAddress();
        }
        public _102190014_DF(string s_id)
        {
            InitializeComponent();
            SetCBAddress();
            P_ID = s_id;
            SetGUI();
        }
        public delegate void MyDel(int n_id, string t_id);
        public MyDel d { get; set; }
       
        public void SetGUI()
        {
            txtID.Enabled = false;
            SanPham p = SanPham_BLL.Instance.GetSPByID_BLL(P_ID);
            NhaCungCap s = NhaCungCap_BLL.Instance.GetNCCByNCC_ID_BLL(p.NCC_Id);
            DiaChi a = DiaChi_BLL.Instance.GetAddressByID_BLL(s.T_Id);
            txtID.Text = p.SP_Id;
            txtName.Text = p.SP_Name;
            txtGia.Text = p.SP_Gia.ToString();
            nmSL.Value = p.SP_SL;
            dtpNgay.Value = p.SP_Ngay;
            cbTP.SelectedIndex = cbTP.FindStringExact(a.T_Name);
            cbNCC.SelectedItem = cbNCC.FindStringExact(s.NCC_Name);
        }
        private void SetCBAddress()
        {
            foreach (DiaChi i in DiaChi_BLL.Instance.GetListOfAddress_BLL())
            {
                cbTP.Items.Add(new CBBItem
                {
                    Value = i.T_Id,
                    Text = i.T_Name
                });
            }
            cbTP.SelectedIndex = 0;
            SetCBSupplier();
        }
        private void SetCBSupplier()
        {
            cbNCC.DataSource = NhaCungCap_BLL.Instance.GetListOfSuppliers_BLL(((CBBItem)cbTP.SelectedItem).Value);
        }
        private void cbTP_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetCBSupplier();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            SanPham p = new SanPham();
            NhaCungCap s = NhaCungCap_BLL.Instance.GetNCCByNCC_Name_BLL(cbNCC.SelectedItem.ToString());
            try {
                p.SP_Id = txtID.Text;
                p.SP_Name = txtName.Text;
                p.SP_Ngay = dtpNgay.Value;
                p.SP_SL = Convert.ToInt32(nmSL.Value);
                p.SP_Gia = float.Parse(txtGia.Text);
                p.NCC_Id = s.NCC_Id;
                if (SanPham_BLL.Instance.SaveProduct_BLL(p))
                {
                    MessageBox.Show("Saved successfully!", "Information", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Failed to save", "Information", MessageBoxButtons.OK);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to save", "Information", MessageBoxButtons.OK);
            }
            d(_102190014_MF.Ncc.NCC_Id,_102190014_MF.Ncc.T_Id);
            this.Dispose();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            d(_102190014_MF.Ncc.NCC_Id,_102190014_MF.Ncc.T_Id);
            this.Dispose();
        }
    }
}
