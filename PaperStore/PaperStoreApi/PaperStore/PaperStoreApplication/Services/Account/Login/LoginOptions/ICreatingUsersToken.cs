using PaperStoreModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperStoreApplication.Services.Account.Login.LoginOptions
{
    internal interface ICreatingUsersToken
    {
        string CreateToken(UserCredentialsModel userData);
    }
}
