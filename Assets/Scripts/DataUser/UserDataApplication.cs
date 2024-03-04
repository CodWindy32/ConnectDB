using DatabaseManager;

namespace DataUser
{
    public static class UserDataApplication
    {
        public static string userId;
        public static string userFullName;
        public static string userAge;
        public static string userLogin;
        public static string roleId;

        public static void UserDataApplicationSaved(string title)
        {
            userLogin = title;
            userId = SqlQuery.ExecuteQuerySelect($"SELECT userId FROM Users WHERE login = '{title}'", false);
            userFullName = SqlQuery.ExecuteQuerySelect($"SELECT fullName FROM Users WHERE login = '{title}'", false);
            userAge = SqlQuery.ExecuteQuerySelect($"SELECT age FROM Users WHERE login = '{title}'", false);
            roleId = SqlQuery.ExecuteQuerySelect($"SELECT roleId FROM Users WHERE login = '{title}'", false);
        }
    }
}

