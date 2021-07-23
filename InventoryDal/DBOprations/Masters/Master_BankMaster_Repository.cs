using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryRepository.Masters;

namespace InventoryDal.DBOprations.Masters
{
    public class Master_BankMaster_Repository
    {
        public List<InventoryRepository.Masters.BankAccMasterModel> getAllBanks()
        {
            using (var context = new MetalInventoryEntities())
            {
                var result = context.Master_BankAccountMaster
                    .Where(x => x.freez == 0)
                    .Select(x => new InventoryRepository.Masters.BankAccMasterModel()
                    {
                        Id = x.Id,
                        BankName = x.BankName,
                        Branch = x.Branch,
                        address = x.address,
                        Holder = x.Holder,
                        IFSC = x.IFSC,
                        OpeningBal = x.OpeningBal
                    })
                    .ToList();

                return result;
            }
        }

        public int CreateBank(BankAccMasterModel bnk)
        {
            using (var context = new MetalInventoryEntities())
            {
                Master_BankAccountMaster data = new Master_BankAccountMaster()
                {
                    BankName = bnk.BankName.ToUpper(),
                    Holder = bnk.Holder.ToUpper(),
                    address = bnk.address.ToUpper(),
                    IFSC = bnk.IFSC.ToUpper(),
                    Branch = bnk.Branch.ToUpper(),
                    OpeningBal = bnk.OpeningBal,
                    freez = 0
                };
                context.Master_BankAccountMaster.Add(data);
                context.SaveChanges();
                if (data.Id > 0)
                {
                    return data.Id;
                }
            }
            return 0;
        }

        public BankAccMasterModel getBank(int id)
        {
            using (var context = new MetalInventoryEntities())
            {
                var result = context.Master_BankAccountMaster
                    .Where(x => x.Id == id)
                    .Select(x => new BankAccMasterModel()
                    {
                        Id = x.Id,
                        BankName = x.BankName,
                        Holder = x.Holder,
                        address = x.address,
                        IFSC = x.IFSC,
                        Branch = x.Branch,
                        OpeningBal = x.OpeningBal
                    }).FirstOrDefault();
                return result;
            }
        }

        public bool EditBank(BankAccMasterModel bnk)
        {
            using (var context = new MetalInventoryEntities())
            {
                var result = context.Master_BankAccountMaster.FirstOrDefault(x => x.Id == bnk.Id);
                if (result != null)
                {
                    result.BankName = bnk.BankName.ToUpper();
                    result.Holder = bnk.Holder.ToUpper();
                    result.address = bnk.address.ToUpper();
                    result.Branch = bnk.Branch.ToUpper();
                    result.IFSC = bnk.IFSC.ToUpper();
                    result.OpeningBal = bnk.OpeningBal;

                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }

        }
    }
}
