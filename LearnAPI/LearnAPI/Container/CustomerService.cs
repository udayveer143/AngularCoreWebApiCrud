using AutoMapper;
using LearnAPI.Helper;
using LearnAPI.Modal;
using LearnAPI.Repos;
using LearnAPI.Repos.Models;
using LearnAPI.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace LearnAPI.Container
{
    public class CustomerService:ICustomerService
    {
        private readonly LearndataContext context;
        private readonly IMapper _mapper;
        private readonly ILogger<CustomerService> _logger;
        public CustomerService(LearndataContext learndataContext, IMapper mapper, ILogger<CustomerService> logger)
        {
            context = learndataContext;
            _mapper = mapper;
            _logger = logger;

        }

        public async Task<APIResponse> Create(Customermodal modal)
        {
            APIResponse response = new APIResponse();
            try
            {
                _logger.LogInformation("Create Begins");
                TblCustomer customer = _mapper.Map<TblCustomer>(modal);
                await context.TblCustomers.AddAsync(customer);
                await context.SaveChangesAsync();
                response.ResponseCode = 201;
                response.Result = modal.Code;
            }
            catch (Exception ex)
            {
                response.ResponseCode = 400;
                response.ErrorMessage= ex.Message;
                _logger.LogError(ex.Message, ex);
            }
            return response;
        }

        public async Task<List<Customermodal>> GetAll()
        {
            List<Customermodal> result= new List<Customermodal>();
            var data= await context.TblCustomers.ToListAsync();
            if(data != null )
            {
                result= _mapper.Map<List<Customermodal>>(data);
            }
            return result;
        }

        public async Task<Customermodal> Getbycode(string code)
        {
            Customermodal result=new Customermodal();
            var data = await context.TblCustomers.FindAsync(code);
            if(data != null)
            {
                result=_mapper.Map<Customermodal>(data);
            }
            return result;
        }

        public async Task<APIResponse> Remove(string code)
        {
            APIResponse response = new APIResponse();
            try
            {
                var customer = await context.TblCustomers.FindAsync(code);
                if(customer != null )
                {
                    context.TblCustomers.Remove(customer);
                    await context.SaveChangesAsync();
                    response.ResponseCode = 200;
                    response.Result = code;
                }
                else
                {
                    response.ResponseCode = 404;
                    response.Result = "Data not found";
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = 400;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

        public async Task<APIResponse> Update(Customermodal modal, string code)
        {
            APIResponse response = new APIResponse();
            try
            {
                var customer = await context.TblCustomers.FindAsync(code);
                if (customer != null)
                {
                    customer.Name = modal.Name;
                    customer.Email = modal.Email;
                    customer.Phone = modal.Phone;
                    customer.IsActive = modal.IsActive;
                    customer.Creditlimit = modal.Creditlimit;
                    await context.SaveChangesAsync();
                    response.ResponseCode = 200;
                    response.Result = code;
                }
                else
                {
                    response.ResponseCode = 404;
                    response.Result = "Data not found";
                }
            }
            catch (Exception ex)
            {
                response.ResponseCode = 400;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }
    }
}
