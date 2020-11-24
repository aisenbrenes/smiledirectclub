using System;
using System.Collections.Generic;

#nullable disable

namespace SmileDirectClub.DataAccess.Models
{
    public partial class Document
    {
        public int DocumentId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public int CustomerId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
