using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/**
 *
 * @author NgocTien.TNT
 */

namespace GiveLove
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private bool KTCancel = true;

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (KTCancel)
            {
                MessageBox.Show("Bạn muốn thoát thật sao?\nKhông muốn trả lời mình à? :((", "Bạn không muốn trả lời mình à! :((", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                e.Cancel = true;
            }                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            KTCancel = false;
            f4.ShowDialog();
        }
    }
}
