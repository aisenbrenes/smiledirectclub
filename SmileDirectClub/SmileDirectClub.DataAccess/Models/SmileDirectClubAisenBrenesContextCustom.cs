using Microsoft.EntityFrameworkCore;

namespace SmileDirectClub.DataAccess.Models
{
    public partial class SmileDirectClubAisenBrenesContext : DbContext
    {
        #region Variables

        private string _sqlConnection;

        #endregion

        public SmileDirectClubAisenBrenesContext(string sqlConnection) 
        {
            _sqlConnection = sqlConnection;
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer(_sqlConnection);
        //    }
        //}
    }
}
