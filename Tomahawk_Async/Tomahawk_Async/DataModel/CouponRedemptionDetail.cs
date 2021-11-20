using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tomahawk_Async.DataModel
{
    public class CouponRedemptionDetail
    {
        
        public int Id { get; set; }
        public int CouponId { get; set; }
        public int UserId { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public string RedeemptionCode { get; set; }
        public DateTime ReedemdOn { get; set; }
        public int ReedemdBy { get; set; }

        public virtual Coupon Broadcaster { get; set; }
    }
}
