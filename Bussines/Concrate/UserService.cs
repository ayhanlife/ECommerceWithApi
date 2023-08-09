using Bussines.Abstract;
using DataAccess.Abstract;
using Entities.Concrate;
using Entities.Dtos.UserDtos;

namespace Bussines.Concrate
{
    public class UserService : IUserService
    {

        private readonly IUserDal _userDal;
        public UserService(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public async Task<List<UserDetailDto>> GetListAsync()
        {
            List<UserDetailDto> userDetailDto = new List<UserDetailDto>();
            var response = await _userDal.GetListAsync();
            foreach (var item in response)
            {
                userDetailDto.Add(new UserDetailDto()
                {
                    UserName = item.UserName,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Adress = item.Adress,
                    DateOfBirth = item.DateOfBirth,
                    Email = item.Email,
                    Gender = item.Gender,
                    Password = item.Password,
                    Id = item.Id
                });
            }
            return userDetailDto;
        }
        public async Task<UserDto> GetByIdAsync(int id)
        {
            var user = await _userDal.GetAsync(x => x.Id == id);
            UserDto userDto = new UserDto()
            {
                Id = user.Id,
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Adress = user.Adress,
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                Gender = user.Gender,
                Password = user.Password
            };

            return userDto;
        }

        public async Task<UserDto> AddAsync(UserAddDto userAddDto)
        {
            User user = new User()
            {
                CreatedDate = DateTime.Now,
                CreatedUserId = 1,

                UserName = userAddDto.UserName,
                FirstName = userAddDto.FirstName,
                LastName = userAddDto.LastName,
                Adress = userAddDto.Adress,
                DateOfBirth = userAddDto.DateOfBirth,
                Email = userAddDto.Email,
                Gender = userAddDto.Gender,
                Password = userAddDto.Password
            };
            var userAdd = await _userDal.AddAsync(user);

            UserDto user2 = new UserDto()
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Adress = user.Adress,
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                Gender = user.Gender,
                Password = user.Password
            };
            return user2;

        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }



        public Task<UserDetailDto> UpdateAsync(UserUpdateDto userUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
