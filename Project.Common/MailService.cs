﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Project.Common
{
    public static class MailService
    {
        public static void Send(string receiver, string password = "*46546646", string body = "Test mesajıdır", string subject = "Email Testi", string sender = "test@gmail.com")
        {
            MailAddress senderEmail = new MailAddress(sender);
            MailAddress receiverEmail = new MailAddress(receiver);

            //Bizim Email işlemlerimiz SMTP'ye göre yapılır...
            //Kullandığınız gmail hesabının başka uygulamalar tarafından mesaj gönderme özelliğini açmalısınız...

            SmtpClient smtp = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail.Address, password)

            };

            using (MailMessage message = new MailMessage(senderEmail, receiverEmail)
            {
                Subject = subject,
                Body = body,

            })
            {
                smtp.Send(message);
            }

        }
    }
}

