using Emeal.EFCore.Models;
using Emeal.Model;
using Emeal.Model.ViewModel;
using URF.Core.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Emeal.Service.Abstract
{
    public interface IUserService : IService<User>
    {
        public void Save(UserDto user);
        public UserDto Login(LoginViewModel loginViewModel);
        public void Registration(RegistrationViewModel registrationViewModel);
    }
}
