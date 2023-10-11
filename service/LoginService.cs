using infrastructure;

namespace service;

public class LoginService
{
    private readonly LoginRepository _loginRepository;
    private readonly AuthenticationHelper _authenticationHelper;

    public LoginService(LoginRepository loginRepository, AuthenticationHelper authenticationHelper)
    {
        _loginRepository = loginRepository;
        _authenticationHelper = authenticationHelper;
    }

    public User AddNewUser(string username, string email)
    {
        return _loginRepository.AddNewUser(username, email);
    }

    public PasswordHash AddPasswordHashToUser(int userId, byte[] hash, byte[] salt)
    {
        return _loginRepository.AddPasswordHashToUser(userId, hash, salt);
    }

    public User GetUserByUsername(string username)
    {
        return _loginRepository.GetUserByUsername(username);
    }

    public PasswordHash GetPasswordHashByUserId(int userId)
    {
        return _loginRepository.GetPasswordHashByUserId(userId);
    }

    public bool Login(string username, string password)
    {
        User user = _loginRepository.GetUserByUsername(username);
        
        //Does User Exist??
        if (user == null)
            return false;
        
        //Is Password Correct?
        PasswordHash passwordHash = _loginRepository.GetPasswordHashByUserId(user.Id);

        if (!_authenticationHelper.VerifyPasswordHash(password, passwordHash.Hash, passwordHash.Salt))
            return false;

        return true;
    }

    public bool Register(string username, string email, string password)
    {
        byte[] passwordHash;
        byte[] passwordSalt;
        
        _authenticationHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
        User user = AddNewUser(username, email);
        PasswordHash createdHash = AddPasswordHashToUser(user.Id, passwordHash, passwordSalt);
        
        if (createdHash.Hash.Length == 0)
            return false;

        return true;
    }
}