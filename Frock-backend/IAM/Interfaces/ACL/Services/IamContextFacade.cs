using Frock_backend.IAM.Domain.Model.Commands;
using Frock_backend.IAM.Domain.Model.Queries;
using Frock_backend.IAM.Domain.Services;

namespace Frock_backend.IAM.Interfaces.ACL.Services;

/**
 * <summary>
 *     Provides access to IAM context operations such as user creation and retrieval.
 * </summary>
 */
public class IamContextFacade(IUserCommandService userCommandService, IUserQueryService userQueryService) : IIamContextFacade
{
    /**
     * <summary>
     *     Creates a new user with username, email, and password.
     * </summary>
     * <param name="username">The username for the new user.</param>
     * <param name="email">The email for the new user.</param>
     * <param name="password">The password for the new user.</param>
     * <returns>The ID of the newly created user.</returns>
     */
    public async Task<int> CreateUser(string username, string email, string password)
    {
        var signUpCommand = new SignUpCommand(username, email, password);
        await userCommandService.Handle(signUpCommand);

        var getUserByUsernameQuery = new GetUserByUsernameQuery(username);
        var result = await userQueryService.Handle(getUserByUsernameQuery);

        return result?.Id ?? 0;
    }

    /**
     * <summary>
     *     Fetch the user ID given a username.
     * </summary>
     * <param name="username">The username to search for.</param>
     * <returns>The ID of the user, or 0 if not found.</returns>
     */
    public async Task<int> FetchUserIdByUsername(string username)
    {
        var getUserByUsernameQuery = new GetUserByUsernameQuery(username);
        var result = await userQueryService.Handle(getUserByUsernameQuery);
        return result?.Id ?? 0;
    }

    /**
     * <summary>
     *     Fetch the username given a user ID.
     * </summary>
     * <param name="userId">The ID of the user.</param>
     * <returns>The username, or empty string if not found.</returns>
     */
    public async Task<string> FetchUsernameByUserId(int userId)
    {
        var getUserByIdQuery = new GetUserByIdQuery(userId);
        var result = await userQueryService.Handle(getUserByIdQuery);
        return result?.Username ?? string.Empty;
    }
}
