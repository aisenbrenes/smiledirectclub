using System;
using System.Collections.Generic;
using System.Text;

namespace SmileDirectClub.DataAccess.Models
{
    public partial class Document : BaseCrudModel, IDocument
    {
    }

    public interface IDocument 
    {
    }
}
