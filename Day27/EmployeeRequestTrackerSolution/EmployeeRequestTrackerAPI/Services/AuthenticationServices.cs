using EmployeeRequestTrackerAPI.Execptions;
using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Models.DTOs;
using Microsoft.AspNetCore.Authentication;
using System.Security.Cryptography;
using System.Text;

namespace EmployeeRequestTrackerAPI.Services
{
    public class AuthenticationServices : IEmployeeAuthenticationServices
    {
        private readonly IRepository<int, Employee> _employeeRepository;
        private readonly IRepository<int, Authentication> _authenticationRepository;
        private readonly ITokenServices _tokenServices;

        public AuthenticationServices(IRepository<int, Employee> employeeRepository, IRepository<int, Authentication> authenticationRepository, ITokenServices tokenServices)
        {
            _employeeRepository = employeeRepository;
            _authenticationRepository = authenticationRepository;
            _tokenServices = tokenServices;
        }
        public async Task<LoginReturnDTO> Login(EmployeeLoginDTO loginDTO)
        {
            var employeeAuth = await _authenticationRepository.Get(loginDTO.EmployeeId);
            if (employeeAuth == null)
            {
                throw new InvalidCredentials();
            }
            HMACSHA512 hMACSHA = new HMACSHA512(employeeAuth.PasswordHashKey);
            var PasswordHash = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));
            bool isHashSame = ComparePassword(PasswordHash, employeeAuth.Password);
            if (isHashSame)
            {
                if (employeeAuth.Status == "Disabled")
                {
                    throw new UserNotEnabled();
                }
                var user = await _employeeRepository.Get(loginDTO.EmployeeId);
                LoginReturnDTO loginReturnDTO = MapEmployeeToLoginReturnDTO(user);
                return loginReturnDTO;
            }
            throw new InvalidCredentials();
        }
        private LoginReturnDTO MapEmployeeToLoginReturnDTO(Employee employee)
        {
            LoginReturnDTO returnDTO = new LoginReturnDTO();
            returnDTO.EmployeeID = employee.Id;

            returnDTO.Token = _tokenServices.GenerateToken(employee);
            return returnDTO;
        }
        private bool ComparePassword(byte[] encrypterPass, byte[] password)
        {
            for (int i = 0; i < encrypterPass.Length; i++)
            {
                if (encrypterPass[i] != password[i])
                {
                    return false;
                }
            }
            return true;
        }
        public async Task<Employee> Register(RegisterDTO registerDTO)
        {
            Employee employee = null;
            Authentication employeeAuthentication = null;
            try
            {
                employee = registerDTO;
                employeeAuthentication = MapUserToEmployeeCredential(registerDTO);
                employee = await _employeeRepository.Add(employee);
                employeeAuthentication.EmployeeId = employee.Id;
                employeeAuthentication = await _authenticationRepository.Add(employeeAuthentication);
                ((RegisterDTO)employee).Password = string.Empty;
                return employee;
            }
            catch (Exception ex) { }
            if (employee != null)
                await RevertEmployeeInsert(employee);
            if (employeeAuthentication != null && employee == null)
                await RevertEmployeeAuthenticationInsert(employeeAuthentication);
            throw new UnableToRegister();
        }
        private async Task RevertEmployeeAuthenticationInsert(Authentication employeeCredential)
        {
            await _authenticationRepository.Delete(employeeCredential.EmployeeId);
        }
        private async Task RevertEmployeeInsert(Employee employee)
        {
            await _employeeRepository.Delete(employee.Id);
        }
        private Authentication MapUserToEmployeeCredential(RegisterDTO employeeDTO)
        {
            Authentication employeeAuthentication = new Authentication();
            employeeAuthentication.EmployeeId = employeeDTO.Id;
            if (employeeDTO.Role == "Admin")
            {
                employeeAuthentication.Status = "Enabled";
            }
            else 
            {
                employeeAuthentication.Status = "Disabled";
            }
            HMACSHA512 hMACSHA = new HMACSHA512();
            employeeAuthentication.PasswordHashKey = hMACSHA.Key;
            employeeAuthentication.Password = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(employeeDTO.Password));
            return employeeAuthentication;
        }
    }
}
