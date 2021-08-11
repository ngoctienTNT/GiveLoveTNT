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
    public partial class Form2 : Form
    {
        Button button = new Button()
        {
            Text = "Mơ à",
            Font = new Font("Maiandra GD", 16, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.Red,
            AutoSize = true,
        };
        private int x = 500;
        private int y = 177;
        private int count = 0;
        public Form2()
        {
            InitializeComponent();
            button.Location = new Point(x, y);
            this.Controls.Add(button);
        }

        private bool KTMouse = true;
        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X > x - 100 && e.X < x + 100 && e.Y > y - 100 && e.Y < y + 100 && count < 31)
            {
                Random randomX = new Random();
                Random randomY = new Random();
                do
                {
                    x = randomX.Next(0, 750);
                    y = randomY.Next(0, 450);
                } while (65 < x && x < 770 && y > 40 && y < 270);
                button.Location = new Point(x, y);
                count++;
            }
            if (count > 30 && KTMouse)
            {
                KTMouse = false;
                notifyIcon1.ShowBalloonTip(3000, "Nút \"Mơ À\" đã giận và gửi kèm lời nhắn:", "Bạn đuổi mình quá!\nMình đi đây! :((", ToolTipIcon.Info);
                this.Controls.Remove(button);
                button.Dispose();
            }
        }

        private bool KTCancel = true;
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (KTCancel)
            {
                MessageBox.Show("Bạn muốn thoát thật sao?\nKhông muốn trả lời mình à? :((", "Bạn muốn thoát à! :((", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                e.Cancel = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            KTCancel = false;
            this.Hide();
            this.Close();
            f3.ShowDialog();
        }
    }
}
