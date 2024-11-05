using API.DTOs;
using API.Entities;

namespace API.Interfaces;

public interface IUserRepository
{
    void Update(AppUser user);
    Task<bool> SaveAllAsync();
    Task<IEnumerable<AppUser>> GetUsersAsync();
    Task<IEnumerable<MemberDto>> GetMembersAsync();
    Task<AppUser?> GetUserByUserNameAsync(string username);
    Task<MemberDto?> GetMemberAsync(string username);
    Task<AppUser?> GetUserByIdAsync(int id);
    Task<MemberDto?> GetMemberByIdAsync(int id);
}
