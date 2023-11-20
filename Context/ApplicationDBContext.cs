using Microsoft.EntityFrameworkCore;
using Ws_precotex.Models;

namespace Ws_precotex.Context
{
    public class ApplicationDBContext : DbContext

    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public virtual DbSet<User> userInfo { get; set; }
    }
}
