using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizViewModel.ViewModels
{
    public class CouponViewModel
    {
        public int CouponId { get; set; }
        [Required]
        public string CouponCode { get; set; }
        [Required]
        public string CouponCategory { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime CouponExpiryDate { get; set; }
    }
}
