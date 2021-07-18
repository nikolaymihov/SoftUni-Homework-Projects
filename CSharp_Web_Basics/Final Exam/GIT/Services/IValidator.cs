namespace GIT.Services
{
    using System.Collections.Generic;

    using Git.Models.Users;

    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserFormModel model);
    }
}