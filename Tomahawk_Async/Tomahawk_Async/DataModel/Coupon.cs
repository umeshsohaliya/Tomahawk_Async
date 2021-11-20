using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Tomahawk_Async.DataModel
{
    public class Coupon
    {
        public Coupon()
        {
            CouponRedemptionDetails = new HashSet<CouponRedemptionDetail>();
        }
        
        public int Id { get; set; }
        public string Title { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime EndDate { get; set; }
        public int MaxPerUserCount { get; set; }
        public int MaxPerSystemCount { get; set; }
        public bool bActive { get; set; }
        public Guid Createdby { get; set; }
        public DateTime Createdon { get; set; }
        public Guid? Modifiedby { get; set; }
        public DateTime? Modifiedon { get; set; }

        public virtual ICollection<CouponRedemptionDetail> CouponRedemptionDetails { get; set; }
    }

}
