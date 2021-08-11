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
    public partial class Form1 : Form
    {
        public Form1()
        {
            WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();
            player.URL = "https://x2convert.com/Thankyou?token=U2FsdGVkX1%2bqO%2f4cD6ydeBXEGjrHtokbmVx%2bBlSWVZFN3bBqT8oG7L3Hw3kFqZnWvSs0CIv7hDxMXRBbxK4Krz0Cy2ujYZGJo9iZ1C%2btiEuixIoMyzARVNJKUuf1gwwsOSTr9KYX%2f2giMmiW38nlvH6yw7nHYHgtdk9%2fCgFRToY%3d&s=youtube&id=&h=8769485682647058442";
            player.controls.play();
            InitializeComponent();            
        }

        private bool KTCancel = true;

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (KTCancel)
            {
                MessageBox.Show("Bạn muốn thoát thật sao?\nKhông muốn trả lời mình à? :((", "Bạn muốn thoát à! :((", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                e.Cancel = true;
            }             
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            KTCancel = false;
            f2.ShowDialog();
        }
    }
}
