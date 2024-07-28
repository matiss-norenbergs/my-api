using my_api.React.User.Components;

namespace my_api.React.User
{
    public static class UserController
    {
        internal static object? HandleRequest(string type, string operation, Dictionary<string, string> postParams)
        {
            object? result = null;
            try
            {
                switch (type)
                {
                    case "list":
                        result = UserListComp.HandleRequest(operation, postParams);
                        break;
                    default:
                        throw new Exception("Error, invalid user type!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return result;
        }
    }
}
