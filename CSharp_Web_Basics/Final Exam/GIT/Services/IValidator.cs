namespace GIT.Services
{
    using System.Collections.Generic;

    using Git.Models.Users;
    using Models.Repositories;

    public interface IValidator
    {
        ICollection<string> ValidateUser(RegisterUserFormModel model);

        ICollection<string> ValidateRepository(CreateRepositoryFormModel model);
    }
}