namespace my_api.React.User.Components
{
    public static class UserListComp
    {
        internal static object? HandleRequest(string operation, Dictionary<string, string> postParams)
        {
            object? result = null;
            try
            {
                switch (operation)
                {
                    case "get":
                        result = postParams;
                        break;
                    default:
                        throw new Exception("Error, invalid operation!");
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
