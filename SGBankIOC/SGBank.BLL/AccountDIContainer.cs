using Ninject;
using SGBank.Data;
using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.BLL
{
    public static class AccountDIContainer
    {
        public static IKernel Kernel = new StandardKernel();

        static AccountDIContainer()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "FreeTest":
                    Kernel.Bind<IAccountRepository>().To<FreeAccountTestRepository>();
                    break;
                case "BasicTest":
                    Kernel.Bind<IAccountRepository>().To<BasicAccountTestRepository>();
                    break;
                case "PremiumTest":
                    Kernel.Bind<IAccountRepository>().To<PremiumAccountTestRepository>();
                    break;
                case "FileData":
                    Kernel.Bind<IAccountRepository>().To<FileAccountTestRepository>();
                    break;
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}
