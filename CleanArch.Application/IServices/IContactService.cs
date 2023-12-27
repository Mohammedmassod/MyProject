using MyProject.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyProject.Application.IServices
{
    public interface IContactService
    {
        Task<ApiResponse<List<User>>> GetAllContacts();
        Task<ApiResponse<User>> GetContactById(int id);
        Task<ApiResponse<string>> AddContact(User contact);
        Task<ApiResponse<string>> UpdateContact(User contact);
        Task<ApiResponse<string>> DeleteContact(int id);
    }
}
