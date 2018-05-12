using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace City.Api.Services.EmailServices
{
    public class CloudMail : IMailService
    {
        // Using Configuration Pattern.
        public CloudMail(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public async Task SendEmailAsync(string subject, string message)
        {
            var mailTo = Configuration["MailSettings:MailTo"];
            var mailFrom = Configuration["MailSettings:MailFrom"];
            //send mail - output to debug window
            Debug.WriteLine($"Mail from {mailFrom} to {mailTo} using CloudEmail");
            Debug.WriteLine($"Subject: {subject}");
            Debug.WriteLine($"Subject: {message}");

            await Task.CompletedTask;
        }
    }
}
