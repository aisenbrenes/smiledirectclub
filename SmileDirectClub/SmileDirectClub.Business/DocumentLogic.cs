using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using SmileDirectClub.Common;
using SmileDirectClub.DataAccess;
using SmileDirectClub.DataAccess.Models;

namespace SmileDirectClub.Business
{
    public class DocumentLogic
    {
        private readonly Document repo = new Document();

        private List<Document> SetDefaultAttributes(List<Document> documents, string userId)
        {
            foreach (var document in documents)
            {
                if (document.DocumentId > 0)
                {
                    document.CreatedBy = userId;
                    document.CreatedOn = DateTime.Now;
                }
                document.UpdatedBy = userId;
                document.UpdatedOn = DateTime.Now;
            }

            return documents;
        }

        public IEnumerable<Document> GetMany(ref ApiRequest<Document> request, string userId) 
        {
            return repo.Read(ref request, userId);
        }

        public IEnumerable<Document> Save(ApiRequest<Document> request, string userId)
        {
            request.Data = SetDefaultAttributes(request.Data, userId);
            return repo.Create(request, userId);
        }
    }
}
