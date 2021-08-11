using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.IO;

/**
 *
 * @author NgocTien.TNT
 */

namespace GiveLove
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private bool KTCancel = true;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!="")
            {                
                try
                {
                    SmtpClient mailclient = new SmtpClient("smtp.gmail.com", 587);
                    mailclient.EnableSsl = true;
                    mailclient.Credentials = new NetworkCredential("Tài khoản mail dùng để gửi lời nhắn", "Mật khẩu mail dùng để gửi lời nhắn");

                    MailMessage message = new MailMessage("Tài khoản mail dùng để gửi lời nhắn", "Tài khoản mail nhận lời nhắn");
                    message.Subject = "Give Love";
                    message.Body = textBox1.Text;

                    /*truy cập vào đường link này rồi bật lên (mail gửi lời nhắn)
                     * https://www.google.com/settings/u/1/security/lesssecureapps */

                    mailclient.Send(message);
                    KTCancel = false;
                    notifyIcon1.ShowBalloonTip(3000, "Cảm ơn cậu!", "Tớ đã nhận được lời nhắn của câu! <3", ToolTipIcon.Info);
                    MessageBox.Show("Lời nhắn của cậu đã được gửi đến tớ!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lời nhắn của cậu gửi đi không thành công!", "Không thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.Close();
            }   
            else
            {
                notifyIcon1.ShowBalloonTip(3000, "Cậu ơi!", "Cậu phải nhập lời nhắn vô chứ! <3", ToolTipIcon.Info);
            }    
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (KTCancel)
            {
                MessageBox.Show("Bạn muốn thoát thật sao?\nKhông muốn trả lời mình à? :((", "Bạn không muốn trả lời mình à! :((", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                e.Cancel = true;
            }
        }
    }
}
