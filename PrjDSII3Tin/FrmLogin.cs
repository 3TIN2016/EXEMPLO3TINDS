using PrjDSII3Tin.Business_Logic_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrjDSII3Tin
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        BLLUsuario objBLLUsuario = new BLLUsuario();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (objBLLUsuario.ControlarUsuario(txtUsuario.Text,txtSenha.Text))
                {
                    MessageBox.Show("FOI");
                }
                else
                {
                    MessageBox.Show("NAO FOI");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
