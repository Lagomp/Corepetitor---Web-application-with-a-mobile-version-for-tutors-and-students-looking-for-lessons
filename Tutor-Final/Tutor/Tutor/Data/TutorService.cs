using Microsoft.EntityFrameworkCore;
using Tutor.DataTransferObjects;

namespace Tutor.Data
{
    public interface ITutorService
    {
        Task<UserInfoViewModel> GetCurrentUser(string userName);
    }
    public class TutorService : ITutorService
    {
        private readonly ApplicationDbContext _context;
        public TutorService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<UserInfoViewModel> GetCurrentUser(string userName)
        {
            var model = await (from u in _context.Users
                               join ur in _context.UserRoles on u.Id equals ur.UserId
                               join r in _context.Roles on ur.RoleId equals r.Id
                               where u.UserName == userName
                               select new UserInfoViewModel
                               {
                                   UserEmail = u.Email,
                                   UserId = u.Id,
                                   UserImage = u.ImagePath,
                                   UserName = u.UserName,
                                   UserRole = r.Name,
                                   FullName = u.FirstName + " " + u.LastName,
                                   IsBlocked=u.IsBlocked,
                               }).FirstOrDefaultAsync();

            return model ?? new UserInfoViewModel();
        }
    }
}
