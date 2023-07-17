using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practice
{
    public partial class Practice : Form
    {
        public Practice()
        {
            InitializeComponent();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            // fLogin 폼 인스턴스 생성
            fLogin loginForm = new fLogin();
            // fLogin 폼을 보여줌
            loginForm.ShowDialog();
        }
    }
}
