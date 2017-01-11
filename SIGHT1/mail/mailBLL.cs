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

                string toDisplayName = "Sight Message";
                var fromAddress = new MailAddress(messageModel.email, toDisplayName);
                MailAddress toAddress = null;
                string subject = "QUERY";
                string emailString = "cmogodi@gmail.com";
                toAddress = new MailAddress(emailString, toDisplayName);

                if (toAddress == null) throw new Exception("Delivery Address is empty.");
                var credential = new NetworkCredential
                {
                    UserName = "cmogodi@gmail.com",  // replace with valid value
                    Password = "mcmogodi"  // replace with valid value
                };

                var smtp = new SmtpClient
                {

                    Credentials = credential,
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,

                };

                var message = new MailMessage(toAddress.Address, toAddress.Address)
                {
                    Subject = subject,
                    Body = body,
                };

                smtp.Send(message);
            }
            catch (Exception ex)
            {

                throw new Exception("Your Message wasn't sent following error occured" + ex.Message);
            }
        }

    }
}