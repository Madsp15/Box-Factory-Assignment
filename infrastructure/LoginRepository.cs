using Dapper;

namespace infrastructure;

public class LoginRepository
{
    public User AddNewUser(string username, string email)
    {
        var sql = $@"INSERT INTO tables.users(username, email)
                        VALUES(@username, @email)
                        RETURNING
                        id as {nameof(User.Id)},
                        username as {nameof(User.UserName)},
                        email as {nameof(User.Email)};";

        using (var conn = DataConnection.DataSource.OpenConnection())
        {
            return conn.QueryFirst<User>(sql, new { username = username, email = email });
        }
    }

    public PasswordHash AddPasswordHashToUser(int userId, byte[] hash, byte[] salt)
    {
        var sql = $@"INSERT INTO tables.password_hash(userid, hash, salt)
                    VALUES(@userid, @hash, @salt)
                    RETURNING
                    userid as {nameof(PasswordHash.UserId)},
                    hash as {nameof(PasswordHash.Hash)},
                    salt as {nameof(PasswordHash.Salt)};";

        using (var conn = DataConnection.DataSource.OpenConnection())
        {
            return conn.QueryFirst<PasswordHash>(sql, new { userid = userId, hash = hash, salt = salt });
        }

    }
    public User GetUserByUsername(string username)
    {
        var sql = $@"SELECT * FROM tables.users WHERE username = @username;";

        using (var conn = DataConnection.DataSource.OpenConnection())
        {
            return conn.QueryFirst<User>(sql, new { username = username });
        }
    }

    public PasswordHash GetPasswordHashByUserId(int userId)
    {
        var sql = $@"SELECT * From tables.password_hash WHERE userid = @userid;";

        using (var conn = DataConnection.DataSource.OpenConnection())
        {
            return conn.QueryFirst<PasswordHash>(sql, new { userid = userId });
        }

    }
}