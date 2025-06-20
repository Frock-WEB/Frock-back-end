namespace Frock_backend.IAM.Domain.Model.Commands;

/**
 * <summary>
 *     The sign up command
 * </summary>
 * <remarks>
 *     This command object includes the email, username and password to sign up
 * </remarks>
 */
public record SignUpCommand(string Email, string Username, string Password);
