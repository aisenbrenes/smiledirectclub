using System;
using System.Collections.Generic;
using System.Text;

namespace SmileDirectClub.DataAccess.Models
{
    public partial class Customer : BaseCrudModel, ICustomer
    {
    }

    public interface ICustomer 
    {
    }
}
