using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace DF.Users.Entity
{
    /// <summary>
    /// User Entity
    /// </summary>
    public class User
    {
        [XmlElement(ElementName = "UserId")]
        public string UserId { get; set; }

        [XmlElement(ElementName = "UserPassword")]
        public string UserPassword { get; set; }

        public override string ToString()
        {
            return string.Format(Resources.String.Resource.User_ToString, UserId, UserPassword);
        }
    }
}
