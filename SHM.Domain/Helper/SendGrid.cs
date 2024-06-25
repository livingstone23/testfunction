using SendGrid;
using SendGrid.Helpers.Mail;



namespace SHM.Domain.Helper;



public static class SendGridCustom
{


    public static async Task<string> SendByMailConfirmTransaction(TransactionSendgridDTO data, SendgridDataDTO sendData)
    {

        try
        {

            var message = new SendGridMessage();
            message.AddTo(data.CustomerEmail);
            message.AddContent("text/html", @"Estimado cliente es un gusto saludarlo y enviarlo su token Correspondiente, Deseandolo Exitos ""FELIX"" ");
            message.SetSubject("Confirmación de moviminto.");
            message.SetFrom(Environment.GetEnvironmentVariable("EmailSendStateAccount"), "Tarjeta Felix");
            message.SetTemplateId(Environment.GetEnvironmentVariable("SendGridTemplateId"));

            message.SetTemplateData(data);

            var client = new SendGridClient(Environment.GetEnvironmentVariable("CustomSendGridKeyAppSettingName"));
            var response = await client.SendEmailAsync(message);
            var messageId = response.Headers.GetValues("X-Message-Id").FirstOrDefault();
            return messageId;

        }
        catch (Exception e)
        {
            await ElasticAlert.LogErrorToElastic(e, "SendByMailConfirmTransaction");
            throw;
        }

    }

}

public class TransactionSendgridDTO
{

    public string CustomerEmail { get; set; }

    public String CreditCardNumber { get; set; }

    public string Customer { get; set; }

    public string Datetime { get; set; }

    public string Amount { get; set; }

    public string Store { get; set; }

    public string TransactionType { get; set; }

    public string Status { get; set; }

}

public class SendgridDataDTO
{
    public string SendGridTemplateId { get; set; }
    public string CustomSendGridKeyAppSettingName { get; set; }
    public string EmailSendStateAccount { get; set; }
}

