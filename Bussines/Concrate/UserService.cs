using AutoMapper;
using Bussines.Abstract;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Entities.Concrate;
using Core.Utilities.Messages;
using Core.Utilities.Response;
using DataAccess.Abstract;
using Entities.Concrate;
using Entities.Dtos.User;
using System.Linq.Expressions;

namespace Bussines.Concrate
{
    public class UserService : IUserService
    {

        private readonly IAppUserDal _userDal;
        private readonly IMapper _mapper;
        public UserService(IAppUserDal userDal, IMapper mapper)
        {
            _userDal = userDal;
            _mapper = mapper;
        }

        //public async Task<ApiDataResponse<List<UserDetailDto>>> GetListAsync(Expression<Func<User, bool>> filter = null)
        [CacheAspect(10)]
        public async Task<ApiDataResponse<List<UserDetailDto>>> GetListAsync()
        {

            //var response = filter != null ? await _userDal.GetListAsync(filter) : await _userDal.GetListAsync();
            var response = await _userDal.GetListAsync();
            List<UserDetailDto> userDetailDto = _mapper.Map<List<UserDetailDto>>(response);
            return new SuccessApiDataResponse<List<UserDetailDto>>(userDetailDto, Constants.GetList);
        }
        public async Task<ApiDataResponse<UserDto>> GetAsync(Expression<Func<AppUser, bool>> filter)
        {
            var user = await _userDal.GetAsync(filter);
            if (user != null)
            {
                var userDto = _mapper.Map<UserDto>(user);
                return new SuccessApiDataResponse<UserDto>(userDto, Constants.GetById);
            }
            return new ErrorApiDataResponse<UserDto>(null, "Error");
        }

        public async Task<ApiDataResponse<UserDto>> GetByIdAsync(int id)
        {
            var user = await _userDal.GetAsync(x => x.Id == id);
            if (user != null)
            {
                UserDto userDetailDto = _mapper.Map<UserDto>(user);
                return new SuccessApiDataResponse<UserDto>(userDetailDto, Constants.GetById);
            }
            return new ErrorApiDataResponse<UserDto>(null, "Error");

        }


        
        [CacheRemoveAspect("IUserService.GetListAsync")]
        [TransactionScopeAspect]
        public async Task<ApiDataResponse<UserDto>> AddAsync(UserAddDto userAddDto)
        {
            var user = _mapper.Map<AppUser>(userAddDto);
            //Todo  :CreateDate ve CreateID düzenlenecek
            user.CreatedDate = DateTime.Now;
            user.CreatedUserId = 1;
            user.UpdateUserId = 1;
            user.UpdatedDate = DateTime.Now;
            var userAdd = await _userDal.AddAsync(user);
            var userDto = _mapper.Map<UserDto>(userAdd);
            return new SuccessApiDataResponse<UserDto>(userDto, Constants.Add);
        }


        public async Task<ApiDataResponse<UserDetailDto>> UpdateAsync(UserUpdateDto userUpdateDto)
        {
            var getUser = await _userDal.GetAsync(x => x.Id == userUpdateDto.Id);
            var user = _mapper.Map<AppUser>(getUser);

            //user.Password = getUser.Password;
            user.CreatedUserId = 0;
            user.CreatedDate = DateTime.Now;
            user.CreatedUserId = 1;
            user.UpdateUserId = 1;
            user.UpdatedDate = DateTime.Now;
            //user.Token = userUpdateDto.Token;
            //user.TokenExpireDate = userUpdateDto.TokenExpireDate;

            var resultUpdate = await _userDal.UpdateAsync(user);
            var resultUpdateMap = _mapper.Map<UserDetailDto>(resultUpdate);
            return new SuccessApiDataResponse<UserDetailDto>(resultUpdateMap, Constants.Update);
        }

        public async Task<ApiDataResponse<bool>> DeleteAsync(int id)
        {
            return new SuccessApiDataResponse<bool>(await _userDal.DeleteAsync(id), Constants.Delete);
        }
    }
}
