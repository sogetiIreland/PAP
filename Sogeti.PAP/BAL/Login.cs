using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Sogeti.PAP.BAL
{
    public class Login
    {
        public LoginVerification VerifyLogin(string username, string password)
        {
            LoginVerification result = LoginVerification.INCORRECT_USERNAME;

            using (DataSet dsLoginAuthentication = DAL.Login.VerifyLoginDetails(username, password))
            {
                if ((dsLoginAuthentication != null) && (dsLoginAuthentication.Tables.Count > 0) && (dsLoginAuthentication.Tables[0].Rows.Count > 0))
                {
                    switch (Convert.ToInt32(dsLoginAuthentication.Tables[0].Rows[0][0]))
                    {
                        case -2:
                            result = LoginVerification.INCORRECT_PASSWORD;
                            break;
                        case -1:
                            result = LoginVerification.INCORRECT_USERNAME;
                            break;
                        case 1:
                            result = LoginVerification.LOGIN_VERIFIED;
                            break;
                    }
                }
            }
            return result;
        }
    }
}
