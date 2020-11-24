using System;
using System.Collections.Generic;
using System.Linq;
using SmileDirectClub.Common;

namespace SmileDirectClub.DataAccess.Models
{
    public class BaseCrudModel
    {
        #region CRUD methods

        public List<T> Create<T>(ApiRequest<T> request, string userId) where T : class
        {
            List<T> items = request.Data;

            try
            {
                using (var context = new SmileDirectClubAisenBrenesContext(request.ConnectionString))
                {
                    context.AddRange(items);
                    context.SaveChanges();
                }

                return items;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error creating the request records: {0}",
                    string.IsNullOrEmpty(ex.InnerException.Message) ? ex.Message : ex.InnerException.Message));
            }
        }

        public List<T> Update<T>(ApiRequest<T> request, string userId) where T : class
        {
            List<T> items = request.Data;

            try
            {
                using (var context = new SmileDirectClubAisenBrenesContext(request.ConnectionString))
                {
                    context.UpdateRange(items);
                    context.SaveChanges();
                }

                return items;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Exception thrown when creating the record: {0}", ex.Message));
            }
        }

        public List<T> Read<T>(ref ApiRequest<T> request, string p_userId) where T : class
        {
            try
            {
                // Create the context
                using (var context = new SmileDirectClubAisenBrenesContext(request.ConnectionString))
                {
                    IQueryable<T> query = context.Set<T>();

                    int totalItems = query.Count();

                    if (request.Pagination != null && request.Pagination.PageNumber > 0 && request.Pagination.PageSize > 0)
                        query = query.Skip((request.Pagination.PageNumber * request.Pagination.PageSize) - request.Pagination.PageSize).Take(request.Pagination.PageSize);

                    var page = query.ToList();

                    if (request.Pagination != null && request.Pagination.PageNumber > 0 && request.Pagination.PageSize > 0)
                        request.Pagination.ItemsCount = totalItems;
                    else
                    {
                        if (request.Pagination == null)
                            request.Pagination = new Pagination();

                        request.Pagination.PageNumber = 1;
                        request.Pagination.PageSize = page.Count;
                        request.Pagination.ItemsCount = request.Pagination.PageSize;
                    }

                    // Set model
                    return page;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error reading from database: {0}", ex.Message));
            }
        }

        #endregion
    }
}
