using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Exceptions;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Rest.Messaging.V1;
using Twilio.Clients;

namespace Education_Center
{
    class msg
    {
        public void sms()
        {
            try
            {
                string accountSid = "AC23bd2e5f62c63cb8acb987a3678e9b80";
                string authToken = "0829b666de7a95b21ecc7bf2b9c2c8d8";
                TwilioClient.Init(accountSid, authToken);
                var client = new TwilioRestClient(accountSid, authToken);           

                var message = MessageResource.Create(
                    body: "working",
                    from: new Twilio.Types.PhoneNumber("(305) 694-2472"),
                    to: new Twilio.Types.PhoneNumber("+94779831139")
                );

                Console.WriteLine(message.Sid);
            }
            catch (ApiException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine($"Twilio Error {e.Code} - {e.MoreInfo}");
            }
        }
    }
}
