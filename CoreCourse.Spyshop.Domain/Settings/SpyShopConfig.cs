using System;
using System.Collections.Generic;
using System.Text;

namespace CoreCourse.Spyshop.Domain.Settings
{
    public class SpyShopConfig
    {
        public string FullCompanyName { get; set; }
        public SpyShopMailSettings MailSettings { get; set; }
    }

    public class SpyShopMailSettings
    {
        public string PublicInfoAddress { get; set; }
        public int MailSenderRetries { get; set; }
        public string[] AdditionalInfoAddresses { get; set; }
    }
}
