using AutoMapper;
using Emeal.EFCore.Models;
using Emeal.Model;
using Emeal.Model.ViewModel;
using Emeal.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using URF.Core.Abstractions;
using URF.Core.Abstractions.Trackable;
using URF.Core.EF;
using URF.Core.Services;

namespace Emeal.Service.Concrite
{
    public class UserService : Service<User>, IUserService
    {
        private readonly IUnitOfWork _unitOfWork; 
        protected readonly IMapper _mapper;
        public UserService(ITrackableRepository<User> repository, IMapper mapper, IUnitOfWork unitOfWork) : base(repository) 
        { 
            _mapper = mapper; 
            _unitOfWork = unitOfWork; 
        }

        public UserDto Login(LoginViewModel user)
        {
            var entity = Queryable().Where(x => x.Email == user.UserName && x.Password == user.Password).FirstOrDefault();
            if(entity != null)
            {
                return new UserDto();
            }
            return null;
        }

        public void Save(UserDto user)
        {
            throw new NotImplementedException();
        }

        public void Registration(RegistrationViewModel registrationViewModel)
        {
            var user = new User()
            {
                Name = registrationViewModel.Name,
                Email = registrationViewModel.Email,
                Password = registrationViewModel.Password,
                CompanyId = registrationViewModel.CompanyId
            };

            Insert(user);
            _unitOfWork.SaveChangesAsync();
        }
    }
}


