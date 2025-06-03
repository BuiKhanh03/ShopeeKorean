using AutoMapper;
using Contracts;
using ShopeeKorean.Contracts;
using ShopeeKorean.Entities.Models;
using ShopeeKorean.Service.Contracts;
using ShopeeKorean.Shared.Constant.Authentication;
using ShopeeKorean.Shared.DataTransferObjects.User;
using ShopeeKorean.Shared.Extension;
using ShopeeKorean.Shared.ResultModel;
using System.Dynamic;

namespace ShopeeKorean.Service
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly IRepositoryManager _repositoryManager;

        public UserService(IMapper mapper, ILoggerManager logger, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _logger = logger;
            _repositoryManager = repositoryManager;
        }


        public async Task<Result<UserDto>> GetUserAsync(Guid userId, bool trackChanges, string? include = null)
        {
            var user = await _repositoryManager.UserRepository.GetUser(userId, trackChanges, include);
            if (user == null)
                return Result<UserDto>.NotFound([UserErrors.GetUserNotFoundWithIdError(userId)]);
            var userDto = _mapper.Map<UserDto>(user);
            return Result<UserDto>.Ok(userDto);
        }

        public async Task<Result> UpdateUser(Guid id, UserForUpdateDto userUpdateForDto, bool trackChanes = false)
        {
           var resultCheck = await GetUserAsync(id, trackChanes);
            if (!resultCheck.IsSuccess) return Result.BadRequest(resultCheck.Errors);
            var userEntity = resultCheck.GetValue<UserDto>();
            var user = _mapper.Map<User>(userEntity);
            _mapper.Map(userUpdateForDto, user);

            _repositoryManager.UserRepository.UpdateUser(user);
            return Result.NoContent();
        }
    }
}
