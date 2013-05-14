using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Sogeti.PAP.BAL
{
    public class User
    {
        #region members
        public string Name { get; set; }
        public string UserName { get; set; }
        #endregion

        #region Constructors
        public User():this("", "")
        {
        }

        public User(string name, string userName)
        {
            this.Name = name;
            this.UserName = userName;
        }
        #endregion

        #region SelectMethod
        public static User VerifyUser(string userName, string password, out LoginVerification verifyLogin)
        {
            User user = null;
            verifyLogin = LoginVerification.LOGIN_VERIFIED;
            using (DataSet dsUserDetails = DAL.User.VerifyUser(userName, password))
            {
                if ((dsUserDetails != null) && (dsUserDetails.Tables.Count > 0) && (dsUserDetails.Tables[0].Rows.Count > 0))
                {
                    switch (Convert.ToInt32(dsUserDetails.Tables[0].Rows[0][0]))
                    {
                        case -2:
                            verifyLogin = LoginVerification.INCORRECT_PASSWORD;
                            break;
                        case -1:
                            verifyLogin = LoginVerification.INCORRECT_USERNAME;
                            break;
                        case 1:
                            verifyLogin = LoginVerification.LOGIN_VERIFIED;
                            user = new User(dsUserDetails.Tables[0].Rows[0]["Name"].ToString(), userName);
                            break;
                    }
                }
            }
            return user;
        }
        #endregion
    }
}
