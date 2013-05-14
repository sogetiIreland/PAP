using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sogeti.PAP.BAL
{
    public enum Status
    {
        Alert = 'A',
        Blank = 'B',
        Excellent = 'E',
        Normal = 'N',
        Warning = 'W'
    }

    public enum Frequency
    {
        BLANK = '_',
        Daily = 'D',
        Weekly = 'W',
        Monthly = 'M',
        Quaterly = 'Q',
        Annually = 'A'
    }

    public enum CommercialTerms
    {
        BLANK = '_',
        Fixed_Price = 'F',
        Time_And_Material = 'V'
    }

    public enum SogetiDepartments
    {
        BLANK = '_',
        ADNT = 'A',
        SAP = 'S',
        Test = 'T'
    }

    public enum LoginVerification
    {
        INCORRECT_PASSWORD = -2,
        INCORRECT_USERNAME = - 1,
        LOGIN_VERIFIED = 1
    }
}
