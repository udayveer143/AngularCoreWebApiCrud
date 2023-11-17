using LearnAPI.Helper;
using LearnAPI.Modal;
using LearnAPI.Repos.Models;

namespace LearnAPI.Service
{
    public interface ICustomerService
    {
        Task<List<Customermodal>> GetAll();
        Task<Customermodal> Getbycode(string code);
        Task<APIResponse> Remove(string code);
        Task<APIResponse> Create(Customermodal modal);
        Task<APIResponse> Update(Customermodal modal, string code);
    }
}
