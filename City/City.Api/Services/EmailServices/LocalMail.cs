using City.Api.Models.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace City.Api.Services.EmailServices
{
    public class LocalMail : IMailService
    {
        //using options pattern
        public LocalMail(IOptions<MailSettings> options)
        {
            Options = options;
            //Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IOptions<MailSettings> Options { get; }

        public async Task SendEmailAsync(string subject, string message)
        {
            //Options pattern
            var mailTo = Options.Value.MailTo;
            var mailFrom = Options.Value.MailFrom;

            Debug.WriteLine($"Mail from {mailFrom} to {mailTo} using LocalEmail");
            Debug.WriteLine($"Subject: {subject}");
            Debug.WriteLine($"Subject: {message}");

            await Task.CompletedTask;
        }
    }
}
