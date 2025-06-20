using System.Text.Json.Serialization;

namespace Frock_backend.IAM.Domain.Model.Aggregates;

/**
 * <summary>
 *     The user aggregate
 * </summary>
 * <remarks>
 *     This class is used to represent a user
 * </remarks>
 */
public class User(string email, string username, string passwordHash)
{
    public User() : this(string.Empty, string.Empty, string.Empty)
    {
    }

    public int Id { get; }
    public string Email { get; private set; } = email;
    public string Username { get; private set; } = username;

    [JsonIgnore] public string PasswordHash { get; private set; } = passwordHash;

    /**
     * <summary>
     *     Update the email
     * </summary>
     * <param name="email">The new email</param>
     * <returns>The updated user</returns>
     */
    public User UpdateEmail(string email)
    {
        Email = email;
        return this;
    }

    /**
     * <summary>
     *     Update the username
     * </summary>
     * <param name="username">The new username</param>
     * <returns>The updated user</returns>
     */
    public User UpdateUsername(string username)
    {
        Username = username;
        return this;
    }

    /**
     * <summary>
     *     Update the password hash
     * </summary>
     * <param name="passwordHash">The new password hash</param>
     * <returns>The updated user</returns>
     */
    public User UpdatePasswordHash(string passwordHash)
    {
        PasswordHash = passwordHash;
        return this;
    }
}
