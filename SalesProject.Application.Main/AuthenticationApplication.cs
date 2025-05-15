using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SalesProject.Application.DTO.authentication;
using SalesProject.Application.DTO.pagination;
using SalesProject.Application.Interface;
using SalesProject.Domain.Entity.Models;
using SalesProject.Domain.Interface;
using SalesProject.Transversal.Common;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SalesProject.Application.Main
{
    public class AuthenticationApplication : IAuthenticateApplication
    {
        private readonly IAuthenticateDomain _authenticateDomain;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public AuthenticationApplication(IAuthenticateDomain authenticateDomain, 
            IMapper mapper,
            IConfiguration configuration)
        {
            _authenticateDomain = authenticateDomain;
            _mapper = mapper;
            _config = configuration;
        }
        #region async methods
        public async Task<Response<bool>> RegisterAsync(AuthenticateCreateDTO obj)
        {
            var response = new Response<bool>();

            try
            {
                var user = _mapper.Map<UserSy>(obj);
                response.Data = await _authenticateDomain.RegisterAsync(user);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Register added successfully.";
                }

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response<string>> AuthenticateAsync(AuthenticateDTO authenticateDTO)
        {
            var response = new Response<string>();

            try
            {
                var user = _mapper.Map<UserSy>(authenticateDTO);

                response.Data = await _authenticateDomain.AuthenticateAsync(user);

                if (!string.IsNullOrEmpty(response.Data))
                {
                    response.IsSuccess = true;
                    response.Message = "User authenticated.";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<Response<bool>> InsertAsync(AuthenticateCreateDTO obj)
        {
            var response = new Response<bool>();
            try
            {
                var user = _mapper.Map<UserSy>(obj);
                response.Data = await _authenticateDomain.RegisterAsync(user);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Register added successfully.";
                }
            }
            catch (Exception ex)
            {
                response.Message = $"{ex.Message}";
            }
            return response;
        }

        public async Task<Response<bool>> UpdateAsync(string code, AuthenticateUpdateDTO obj)
        {
            var response = new Response<bool>();
            try
            {
                var user = _mapper.Map<UserSy>(obj);

                response.Data = await _authenticateDomain.UpdateAsync(code, user);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Register updated successfully.";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
        public async Task<Response<bool>> DeleteAsync(string code)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _authenticateDomain.DeleteAsync(code);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Register deleted successfully.";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<IEnumerable<AuthenticateDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<AuthenticateDTO>>();
            try
            {
                var users = await _authenticateDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<AuthenticateDTO>>(users);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<PagedList<AuthenticateDTO>>> GetAllWithPagingAsync(PaginationParametersDTO paginationParameters)
        {
            var response = new Response<PagedList<AuthenticateDTO>>();
            try
            {
                var users = await _authenticateDomain.GetAllWithPagingAsync();
                IEnumerable<AuthenticateDTO> customersIE = _mapper.Map<IEnumerable<AuthenticateDTO>>(await users.ToListAsync());

                response.Data = PagedList<AuthenticateDTO>.ToPagedList(customersIE, paginationParameters.PageNumber, paginationParameters.PageSize);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = $"{ex.Message} \n {ex.InnerException}";
            }

            return response;
        }

        public async Task<Response<IEnumerable<AuthenticateDTO>>> GetAllTthatContainsNameAsync(string name)
        {
            var response = new Response<IEnumerable<AuthenticateDTO>>();
            try
            {
                var users = await _authenticateDomain.GetAllTthatContainsNameAsync(name);
                response.Data = _mapper.Map<IEnumerable<AuthenticateDTO>>(users);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<AuthenticateDTO>> GetByCodeAsync(string code)
        {
            var response = new Response<AuthenticateDTO>();
            try
            {
                var users = await _authenticateDomain.GetByCodeAsync(code);
                response.Data = _mapper.Map<AuthenticateDTO>(users);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<AuthenticateDTO>> GetByCodeAndPassword(string code, string password)
        {
            var response = new Response<AuthenticateDTO>();
            try
            {
                var users = await _authenticateDomain.GetAllAsync();

                var user = await users.FirstOrDefaultAsync(x => x.Code == code && x.Password == password);

                response.Data = _mapper.Map<AuthenticateDTO>(user);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<Response<AuthenticateDTO>> GetByNameAsync(string name)
        {
            var response = new Response<AuthenticateDTO>();
            try
            {
                var users = await _authenticateDomain.GetByNameAsync(name);
                response.Data = _mapper.Map<AuthenticateDTO>(users);
                response.IsSuccess = true;
                response.Message = "Query successfully.";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
        #endregion
    }
}
