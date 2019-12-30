namespace effectively.ExtractAndOverride
{
    public class OrderService
    {
        public bool CanPlace(Order order)
        {
            UserService userService = GetUserService();
            if (userService.IsValidUser // Can the current user save an order
                && order.Amount >= 0)
            {
                //save order
                return true;
            }
            else
            {
                //dont add send an exception and log it
                return false;
            }
        }

        protected virtual UserService GetUserService()
        {
            return new UserService();
        }
    }
}
    