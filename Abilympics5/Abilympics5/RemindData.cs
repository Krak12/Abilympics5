namespace Abilympics5
{
    static class RemindData
    {
        public static string FilePath;

        public static void Remind(string login, string pass)
        {
            LoginData.Default.Remind = true;
            LoginData.Default.Login = login;
            LoginData.Default.Pass = pass;
            LoginData.Default.Save();
        }

        public static void Clear()
        {
            LoginData.Default.Remind = false;
            LoginData.Default.Login = "";
            LoginData.Default.Pass = "";
            LoginData.Default.Save();
        }

        public static (string login, string pass)? GetData()
        {
            if (!LoginData.Default.Remind) return null;

            return (LoginData.Default.Login, LoginData.Default.Pass);
        }
    }
}