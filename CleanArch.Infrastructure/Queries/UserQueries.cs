using System.Diagnostics.CodeAnalysis;

namespace MyProject.Infrastructure.Queries
{
    [ExcludeFromCodeCoverage]
    public static class UserQueries
    {
        public static string AllUsers => "SELECT * FROM [Users] (NOLOCK)";

        public static string UserById => "SELECT * FROM [Users] (NOLOCK) WHERE [Id] = @Id";

        public static string AddUser =>
            @"INSERT INTO [Users] ([Name], [Email], [Password], [ConfirmPassword], [UserName], [IsActive], [PhoneNumber], [UserGroup]) 
              VALUES (@Name, @Email, @Password, @ConfirmPassword, @UserName, @IsActive, @PhoneNumber, @UserGroup)";

        public static string UpdateUser =>
            @"UPDATE [Users] 
              SET [Name] = @Name, 
                  [Email] = @Email, 
                  [Password] = @Password, 
                  [ConfirmPassword] = @ConfirmPassword, 
                  [UserName] = @UserName, 
                  [IsActive] = @IsActive, 
                  [PhoneNumber] = @PhoneNumber, 
                  [UserGroup] = @UserGroup
              WHERE [Id] = @Id";

        public static string DeleteUser => "DELETE FROM [Users] WHERE [Id] = @Id";
    }
}