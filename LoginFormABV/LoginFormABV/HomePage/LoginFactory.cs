using ABV.Models.HomePage;

namespace ABV.Factory.HomePage
{
    public static class LoginFactory
    {
        public static LoginCondition CreatLoginForm()
        {
            return new LoginCondition
            {
                UsernameField = "slavtest@abv.bg",
                PasswordField = "slavTest@",
            };
        }
    }
}
