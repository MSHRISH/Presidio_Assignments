using PizzaApi.Execptions;
using PizzaApi.Interfaces;
using PizzaApi.Models;
using PizzaApi.Models.DTO;
using System.Security.Cryptography;
using System.Text;

namespace PizzaApi.Services
{
    public class UserAuthServices : IUserAuthServices
    {
        private readonly IRepository<int, User> _userRepository;
        private readonly IRepository<int, Authentication> _authRepository;

        public UserAuthServices(IRepository<int,User> userRepository,IRepository<int,Authentication> authRepository) 
        {
            _userRepository = userRepository;
            _authRepository=authRepository;
        }
        public async Task<User> Login(LoginUserDTO loginDTO)
        {
            var userAuth = await _authRepository.Get(loginDTO.UserId);
            if (userAuth == null)
            {
                throw new InvalidCredentials();
            }
            HMACSHA512 hMACSHA = new HMACSHA512(userAuth.PasswordHashKey);
            var PasswordHash = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));
            bool isHashSame = ComparePassword(PasswordHash, userAuth.Password);
            if (isHashSame)
            {
                var user = await _userRepository.Get(loginDTO.UserId);

                return user;

            }
            throw new InvalidCredentials();
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

        public async Task<User> Register(RegisterUserDTO registerDTO)
        {
            User user = null;
            Authentication userAuthentication = null;
            try
            {
                user = registerDTO;
                userAuthentication = MapUserToUserCredential(registerDTO);
                user = await _userRepository.Add(user);
                userAuthentication.UserId = user.Id;
                userAuthentication= await _authRepository.Add(userAuthentication);
                ((RegisterUserDTO)user).Password = string.Empty;
                return user;
            }
            catch (Exception ex) { }
            if (user != null)
                await RevertUserInsert(user);
            if (userAuthentication != null && user == null)
                await RevertUserAuthenticationInsert(userAuthentication);
            throw new UnableToRegister();
        }
        private async Task RevertUserAuthenticationInsert(Authentication userCredential)
        {
            await _authRepository.Delete(userCredential.UserId);
        }
        private async Task RevertUserInsert(User user)
        {
            await _userRepository.Delete(user.Id);
        }

        private Authentication MapUserToUserCredential(RegisterUserDTO userDTO)
        {
            Authentication userAuthentication = new Authentication();
            userAuthentication.UserId = userDTO.Id;
            userAuthentication.Status = "Disabled";
            HMACSHA512 hMACSHA = new HMACSHA512();
            userAuthentication.PasswordHashKey = hMACSHA.Key;
            userAuthentication.Password = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
            return userAuthentication;
        }

    }
}
