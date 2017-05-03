namespace Hotel.Web.Infrastructure.Identity
{
    using Data.Hotel.Data.Models;

    public interface ICurrentUser
    {
        ApplicationUser Get();
    }
}
