using EASendMail;
using System;
using System.Windows.Forms;

namespace NetMail.Utility
{
    public static class ProxyEmailHelper
    {
        public static void SendMail()
        {
            try
            {
                // SMTP server address
                SmtpServer oServer = new SmtpServer("smtp.gmail.com")
                {

                    // proxy server address, port and protocol
                    SocksProxyServer = "31.220.33.13",
                    SocksProxyPort = 1212,
                    ProxyProtocol = SocksProxyProtocol.Socks5,
                    MailFrom = "codemachsolutions@gmail.com",
                    // if your proxy doesn't requires user authentication,
                    // don't assign any value to SocksProxyUser and SocksProxyPassword properties 
                    //SocksProxyUser = "cdficwhq",
                    //SocksProxyPassword = "hlpmksatxvdt",

                    // SMTP user authentication
                    User = "codemachsolutions@gmail.com",
                    Password = "Email2@king",
                    Alias = "Wajid"
                };

                // specifies the authentication mechanism, AuthAuto is default value
                // oSmtp.AuthType = SmtpAuthType.AuthAuto;

                // Most mordern SMTP servers require SSL/TLS connection now.
                // ConnectTryTLS means if server supports SSL/TLS, SSL/TLS will be used automatically.
                oServer.ConnectType = SmtpConnectType.ConnectTryTLS;

                // set SSL/TLS connection
                // oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

                // set SMTP server port to 587, default value is 25
                 oServer.Port = 587;

                // set SMTP server port to 465, 
                // if 465 port is used, ConnectType should use ConnectSSLAuto or ConnectDirectSSL.
                // oServer.Port = 465;

                // set helo domain, default value is current machine name
                 oServer.HeloDomain = "mymachine.com";

                SmtpMail oMail = new SmtpMail("TryIt")
                {
                    From = new MailAddress("codemachsolutions@gmail.com")
                };
                oMail.To.Add(new MailAddress("email2wajidkhan@gmail.com"));

                oMail.Subject = "test email sent from C#";
                oMail.TextBody = "test body";

                SmtpClient oSmtp = new SmtpClient();
                oSmtp.SendMail(oServer, oMail);
                MessageBox.Show("This email has been submitted to server successfully!");
            }
            catch (Exception exp)
            {
                Console.WriteLine("Exception: {0}", exp.Message);
                MessageBox.Show(exp.Message.ToString()) ;
            }
        }
    }
}
