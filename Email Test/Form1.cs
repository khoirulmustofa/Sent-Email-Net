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

namespace Email_Test
{
    public partial class Form1 : Form
    {
        string smtpAddress = "smtp.gmail.com";
        int portNumber = 587;
        bool enableSSL = true;

        string emailFrom = "khoirul.dev123@gmail.com";
        string password = "Jancok";
        //string emailTo = "someone@domain.com";
        //string subject = "Hello";
        //string body = "Hello, I'm just writing this to say Hi!";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnKirim_Click(object sender, EventArgs e)
        {
            string to = txtAlamatEmail.Text;
            string sub = txtSubject.Text;
            string body = txtBody.Text;
            if (String.IsNullOrEmpty(to))
                return;
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(to);
                mail.From = new MailAddress(emailFrom);
                mail.Subject = sub;

                mail.Body = body;

                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = smtpAddress; //Or Your SMTP Server Address
                smtp.Credentials = new System.Net.NetworkCredential(emailFrom, password); // ***use valid credentials***
                smtp.Port = 587;

                //Or your Smtp Email ID and Password
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            //using (MailMessage mail = new MailMessage())
            //{
            //    mail.From = new MailAddress(emailFrom);

            //    mail.To.Add(to);
            //    mail.Subject = subject;
            //    mail.Body = txtBody.Text;
            //    mail.IsBodyHtml = true;
            //    // Can set to false, if you are sending pure text.

            //   // mail.Attachments.Add(new Attachment("C:\\SomeFile.txt"));
            //   // mail.Attachments.Add(new Attachment("C:\\SomeZip.zip"));

            //    using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
            //    {
            //        smtp.Credentials = new NetworkCredential(emailFrom, password);
            //        smtp.EnableSsl = enableSSL;
            //        smtp.Send(mail);
            //    }
            //}
        }
    }
}
