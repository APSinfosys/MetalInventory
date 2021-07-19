using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace InventoryRepository.Masters
{
    public class BankAccMasterModel
    {
        
        public int Id { get; set; }
        [Display(Name ="BANK")]
        public string BankName { get; set; }
        [Display(Name = "BRANCH")]
        public string Branch { get; set; }
        [Display(Name = "ADDRESS")]
        public string address { get; set; }
        [Display(Name = "IFSC")]
        public string IFSC { get; set; }
        [Display(Name = "HOLDER")]
        public string Holder { get; set; }
        [Display(Name = "OPENING BALANCE")]
        public decimal? OpeningBal { get; set; }

    }

 
}
