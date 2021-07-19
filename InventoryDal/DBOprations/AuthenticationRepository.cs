using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryRepository.Authentications;

namespace InventoryDal.DBOprations
{
    public class AuthenticationRepository
    {
        public int Register(RegistrationModel reg)
        {
            using (var context = new MetalInventoryEntities())
            {
                Master_Registration registration = new Master_Registration()
                {
                    CompanyName = reg.CompanyName,
                    CompanyAddress = reg.CompanyAddress,
                    CompanyContact = reg.CompanyContact,
                    CompanyAlternetNo = reg.CompanyAlternetNo,
                    CompanyEmail = reg.CompanyEmail,
                    CompanyGST = reg.CompanyGST,
                    CompanyPan = reg.CompanyPan,
                    RegStatus=0
                    //RegType=reg.RegType,
                    //CompanyCode=reg.CompanyCode
                };
                context.Master_Registration.Add(registration);
                context.SaveChanges();

                if (registration.RegId > 0)
                {
                    Master_UserMaster user = new Master_UserMaster()
                    {
                        UserName = reg.UserName,
                        UserPassword = reg.UserPassword,
                        freez = 0,
                        companyId = registration.RegId,
                        createdDate = System.DateTime.Now
                       
                    };
                    context.Master_UserMaster.Add(user);
                    context.SaveChanges();
                }

                return registration.RegId;
            }
        }

        public string Login(LoginModel lg)
        {
            using (var context = new MetalInventoryEntities())
            {
                var result = (from User in context.Master_UserMaster
                             join Reg in context.Master_Registration on User.companyId equals Reg.RegId
                             //join CV in context.Master_CommonValue on Role.RoleId equals CV.Id
                             where User.UserName == lg.UserName && User.UserPassword == lg.UserPassword
                             select new
                             {
                                 RS=Reg.RegStatus
                             }).ToList();
                if(result.Count>0)
                {
                    return result[0].RS.ToString();
                }
                else
                {
                    return null;
                }
                

            }


            //using(var context= new MetalInventoryEntities())
            //{
            //   bool isValid= context.Master_UserMaster.Any(x => x.UserName == lg.UserName && x.UserPassword == lg.UserPassword && x.freez == 0);
            //    if (isValid)
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
        }
    }
}
