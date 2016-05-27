using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SIGHT1.model;
using System.Net.Mail;
using System.Net;
using System.ComponentModel;

namespace SIGHT1.mail
{
    public static class mailBLL
    {
        public static void sendMessage(MessageModel messageModel)
        {
            try
            {
                var body = "Hi, your friend " + messageModel.name + ", " + "\nWhose email is: " + " " + messageModel.email
                                + " " + "\nhas sent you the following message:" + "   " + messageModel.message;

                string toDisplayName = "Joel--Msg";
                var fromAddress = new MailAddress(messageModel.email, toDisplayName);
                MailAddress toAddress = null;
                string subject = "QUERY";
                string emailString = "jkapuku@sbit.co.za";
                toAddress = new MailAddress(emailString, toDisplayName);

                if (toAddress == null) throw new Exception("Delivery Address is empty.");

                var smtp = new SmtpClient
                {
                    //Host = "smtp.gmail.com",
                    Host = "smtp.office365.com",
                    Port = 25,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    //TargetName = "STARTTLS/smtp.office365.com",
                UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(toAddress.Address, "Kaspersky1")
                };


                using (var message = new MailMessage(toAddress.Address, toAddress.Address)
                {
                    Subject = subject,
                    Body = body,
                })

                {
                    smtp.Send(message);
                }


            }
            catch (Exception ex)
            {

                throw new Exception("Your Message wasn't sent following error occured" + ex.Message);
            }
        }

    }
}