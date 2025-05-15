using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SalesProject.Domain.Entity.Models;
using SalesProject.Domain.Interface;
using SalesProject.Infraestructure.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SalesProject.Domain.Core
{
    public class AuthenticateDomain : IAuthenticateDomain
    {
        private readonly IGenericRepositoryTwo<UserSy> _genericCustomerRepo;
        private readonly IConfiguration _configuration;
        public AuthenticateDomain(IGenericRepositoryTwo<UserSy> genericCustomerRepo, IConfiguration configuration)
        {
            _genericCustomerRepo = genericCustomerRepo;
            _configuration = configuration;
        }

        #region async methods
        public async Task<string> AuthenticateAsync(UserSy obj)
        {
            var users = await GetAllAsync();

            var user = await users.FirstOrDefaultAsync(x =>
                                  x.Code == obj.Username &&
                                  x.Password == obj.Password
                              );

            if (user == null)
                throw new Exception("Incorrect user or password.");

            return GenerateToken(obj);
        }

        public async Task<bool> RegisterAsync(UserSy obj)
        {
            var user = await GetByCodeAsync(obj.Code);  

            if (user != null)
                throw new Exception($"There is already a user created with the same code.");

            return await _genericCustomerRepo.InsertAsync(obj);
        }

        public async Task<bool> UpdateAsync(string code, UserSy obj)
        {
            return await _genericCustomerRepo.UpdateAsync(code, obj);
        }
        public Task<bool> DeleteAsync(string code)
        {
            return _genericCustomerRepo.DeleteAsync(code);
        }

        public async Task<UserSy> GetByCodeAsync(string code)
        {
            return await _genericCustomerRepo.GetByCodeAsync(code);
        }

        public async Task<UserSy> GetByNameAsync(string name)
        {
            var userQueryable = await _genericCustomerRepo.GetAllAsync();
            var user = userQueryable.FirstOrDefault(x => x.Username.Equals(name));

            return user;
        }

        public async Task<IQueryable<UserSy>> GetAllAsync()
        {
            return await _genericCustomerRepo.GetAllAsync();
        }

        public async Task<IQueryable<UserSy>> GetAllWithPagingAsync()
        {
            return await _genericCustomerRepo.GetAllAsync();
        }

        public async Task<IEnumerable<UserSy>> GetAllTthatContainsNameAsync(string name)
        {
            var userQueryable = await _genericCustomerRepo.GetAllAsync();
            var users = userQueryable.Where(x => x.Username.Contains(name)).ToList();

            return users;
        }
        #endregion

        #region sync methods
        public string GenerateToken(UserSy obj)
        {
            var securityKey = new SymmetricSecurityKey(
                                      Encoding.UTF8.GetBytes(
                                        _configuration["Jwt:Key"]    
                                      )
                                  );

            var credentials = new SigningCredentials(
                                      securityKey, 
                                      SecurityAlgorithms.HmacSha256
                                  );

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, obj.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpireMinutes"])),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token); 
        }
        #endregion
    }
}
