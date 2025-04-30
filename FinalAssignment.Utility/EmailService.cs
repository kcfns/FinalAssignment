
using System.Net;
using System.Net.Mail;

public static class EmailSettings
{
    public const string USERNAME = "bhanukumarkashyap@gmail.com";
    public const string PASSWORD = "cbqo kbts vnvw ojel";
}
public static class EmailService
{
    public static void SendInvoiceEmail(string toEmail, string bikeNumber, decimal amount)
    {
        var message = new MailMessage("your_email@gmail.com", toEmail);
        message.Subject = "Your Bike Service Invoice";
        message.Body = $"Dear Customer,\n\n" +
                       $"Your bike ({bikeNumber}) has been successfully serviced.\n" +
                       $"Service Fee: ₹{amount}\n\n" +
                       $"Thank you for choosing Hero Service Station!";

        var client = new SmtpClient("smtp.gmail.com", 587)
        {
            Credentials = new NetworkCredential(EmailSettings.USERNAME, EmailSettings.PASSWORD),
            EnableSsl = true
        };

        client.Send(message);
        Console.WriteLine("Email sent successfully.");
    }
}
