using System;
using System.Collections.Generic;

#nullable disable

namespace SmileDirectClub.DataAccess.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Documents = new HashSet<Document>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual ICollection<Document> Documents { get; set; }
    }
}
