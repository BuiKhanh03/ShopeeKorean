﻿using Contracts;
using AutoMapper;
using ShopeeKorean.Contracts;
using ShopeeKorean.Entities.Models;
using ShopeeKorean.Shared.Extension;
using ShopeeKorean.Service.Contracts;
using ShopeeKorean.Shared.ResultModel;
using ShopeeKorean.Shared.Constant.Authentication;
using ShopeeKorean.Shared.DataTransferObjects.User;

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
            var resultCheck = await this.GetAndCheckUser(userId, trackChanges, include);
            if (!resultCheck.IsSuccess) return Result<UserDto>.NotFound(resultCheck.Errors!);
            var userEntity = resultCheck.Value;
            var userDto = _mapper.Map<UserDto>(userEntity);
            return Result<UserDto>.Ok(userDto);
        }

        public async Task<Result> UpdateUser(Guid userId, UserForUpdateDto userUpdateForDto, bool trackChanges = false)
        {
           var resultCheck = await this.GetAndCheckUser(userId, trackChanges, include: null);
            if (!resultCheck.IsSuccess) return Result.BadRequest(resultCheck.Errors!);
            var user = resultCheck.GetValue<User>();
            _mapper.Map(userUpdateForDto, user);

            _repositoryManager.UserRepository.UpdateUser(user);
            await _repositoryManager.SaveAsync();
            return Result.NoContent();
        }

        public async Task<Result<(string? oldId, string? newImage)>> UpdateUserImage(Guid userId, bool trackChanges, string imageId, string imageUrl)
        {
            var resultCheck = await this.GetAndCheckUser(userId, trackChanges);
            if(!resultCheck.IsSuccess) return Result<(string?, string?)>.BadRequest(resultCheck.Errors!);
            var userEntity = resultCheck.GetValue<User>();
            var oldImage = userEntity.ImageId;
            userEntity.ImageId = imageId;
            userEntity.ImageLink = imageUrl;
            await _repositoryManager.SaveAsync();
            return Result<(string? oldId, string? newImage)>.Ok((oldId: oldImage, newImage: imageUrl));
        }

        private async Task<Result<User>> GetAndCheckUser(Guid userId, bool trackChanges, string? include = null)
        {
            var user = await _repositoryManager.UserRepository.GetUser(userId, trackChanges, include);
            if(user == null) return Result<User>.NotFound([UserErrors.GetUserNotFoundWithIdError(userId)]);
            return Result<User>.Ok(user);
        }
    }
}
