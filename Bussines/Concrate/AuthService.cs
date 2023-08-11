using AutoMapper;
using Bussines.Abstract;
using Bussines.Validations.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Messages;
using Core.Utilities.Response;
using Core.Utilities.Security.Token;
using Entities.Dtos.Auth;
using Entities.Dtos.User;

namespace Bussines.Concrate
{
    public class AuthService : IAuthService
    {

        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ITokenService _token;
        public AuthService(IUserService userService, IMapper mapper, ITokenService token = null)
        {
            _userService = userService;
            _mapper = mapper;
            _token = token;
        }


        [ValidationAspect(typeof(LoginDtoValidator))]
        public async Task<ApiDataResponse<UserDto>> LoginAsync(LoginDto loginDto)
        {
            var user = await _userService.GetAsync(x => x.UserName == loginDto.UserName && x.Password == loginDto.Password);
            if (user.Data == null)
            {
                return new ErrorApiDataResponse<UserDto>(null, "Kullanıcı bulunamadı");
            }
            if (user.Data.TokenExpireDate < DateTime.Now || string.IsNullOrEmpty(user.Data.Token))
            {
                return await UpdateToken(user);
            }
            return new SuccessApiDataResponse<UserDto>(user.Data, Constants.Login);
        }

        private async Task<ApiDataResponse<UserDto>> UpdateToken(ApiDataResponse<UserDto> user)
        {
            var accessToken = _token.CreateToken(user.Data.Id, user.Data.UserName);
            var userUpdateDto = _mapper.Map<UserUpdateDto>(user.Data);
            userUpdateDto.Token = accessToken.Token;
            userUpdateDto.TokenExpireDate = accessToken.Expiration;
            userUpdateDto.UpdateUserId = user.Data.Id;
            var resultUserUpdateDto = await _userService.UpdateAsync(userUpdateDto);
            var userDto = _mapper.Map<UserDto>(resultUserUpdateDto.Data);
            return new SuccessApiDataResponse<UserDto>(userDto, Constants.Login);
        }
    }
}
