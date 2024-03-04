using DataUser;
using UnityEngine.SceneManagement;

namespace UserSystem
{
    public static class UserSystenSettings
    {
        public static void UserSystemScene()
        {
            SceneManager.LoadScene(System.Convert.ToInt32(UserDataApplication.roleId));
        }
    }
}

