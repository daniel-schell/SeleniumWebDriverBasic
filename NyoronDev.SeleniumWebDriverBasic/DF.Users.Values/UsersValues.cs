using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DF.Users.Entity;

namespace DF.Users.Values
{
    /// <summary>
    /// UserValues provides data users
    /// </summary>
    public static class UsersValues
    {
        //Properties
        #region .: Properties :.

        private static readonly IEnumerable<User> UserList;

        #endregion

        //Constructor
        #region .: Constructor :.

        /// <summary>
        /// Initializes the <see cref="UsersValues"/> class.
        /// </summary>
        static UsersValues()
        {
            XmlSerializer serializeUserList = new XmlSerializer(typeof(List<User>));

            var path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, Resources.String.Resource.USERS_XMLPATH);
            using (FileStream fileUserList = File.OpenRead(path))
            {
                UserList = (IEnumerable<User>) serializeUserList.Deserialize(fileUserList);
            }
        }

	    #endregion

        //Methods
        #region .: Methods :.

        /// <summary>
        /// Gets the user list.
        /// </summary>
        /// <returns><see cref="IEnumerable{User}"/></returns>
        public static IEnumerable<User> GetUserList()
        {
            return UserList;
        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <returns><see cref="User"/></returns>
        public static User GetUser()
        {
            return UserList.First();
        }

        #endregion
    }
}
