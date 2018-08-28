using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Delivery.Models
{
    public class EmailConfig : ConfigurationSection
    {
        [ConfigurationProperty("Email")]
        public Email Email
        {
            get
            {
                return (Email)this["Email"];
            }
            set
            { this["Email"] = value; }
        }

        [ConfigurationProperty("Password")]
        public Password Password
        {
            get
            {
                return (Password)this["Password"];
            }
            set
            { this["Password"] = value; }
        }

         [ConfigurationProperty("Port")]
        public Port Port
        {
            get
            {
                return (Port)this["Port"];
            }
            set
            { this["Port"] = value; }
        }

         [ConfigurationProperty("Server")]
        public Server Server
        {
            get
            {
                return (Server)this["Server"];
            }
            set
            { this["Server"] = value; }
        }

        [ConfigurationProperty("SendTo")]
        public SendTo SendTo
        {
            get
            {
                return (SendTo)this["SendTo"];
            }
            set
            { this["SendTo"] = value; }
        }

    }

    public class Email: ConfigurationElement
    {
        [ConfigurationProperty("value", DefaultValue = "user@localhost.localdomain", IsRequired = true)]
        [StringValidator( MinLength = 3, MaxLength = 80)]
        public String Value
        {
            get
            {
                return (String)this["value"];
            }
            set
            {
                this["value"] = value;
            }
        }
    }

    public class Password : ConfigurationElement
    {
        [ConfigurationProperty("value", DefaultValue = "qwerty12345", IsRequired = true)]
        [StringValidator(MinLength = 6, MaxLength = 80)]
        public String Value
        {
            get
            {
                return (String)this["value"];
            }
            set
            {
                this["value"] = value;
            }
        }
    }

    public class Port : ConfigurationElement
    {
        [ConfigurationProperty("value", DefaultValue = 587, IsRequired = true)]

        public int Value
        {
            get
            {
                return (int)this["value"];
            }
            set
            {
                this["value"] = value;
            }
        }
    }

    public class Server : ConfigurationElement
    {
        [ConfigurationProperty("value", DefaultValue = "localhost.localdomain", IsRequired = true)]
        [StringValidator(MinLength = 3, MaxLength = 80)]
        public String Value
        {
            get
            {
                return (String)this["value"];
            }
            set
            {
                this["value"] = value;
            }
        }
    }

    public class SendTo : ConfigurationElement
    {
        [ConfigurationProperty("value", DefaultValue = "localhost.localdomain", IsRequired = true)]
        [StringValidator(MinLength = 3, MaxLength = 80)]
        public String Value
        {
            get
            {
                return (String)this["value"];
            }
            set
            {
                this["value"] = value;
            }
        }
    }
}