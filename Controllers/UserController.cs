using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace BlazorCookieAuth.Controllers
{

	[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        // /api/User/GetUser
        [HttpGet("[action]")]
        public UserModel GetUser()
        {
            // Instantiate a UserModel
            var userModel = new UserModel
            {
                UserName = "[]",
                IsAuthenticated = false
            };
            // Detect if the user is authenticated
            if (User.Identity.IsAuthenticated)
            {
                // Set the username of the authenticated user
                userModel.UserName =
                    User.Identity.Name;
                userModel.IsAuthenticated =
                    User.Identity.IsAuthenticated;
            };
            return userModel;
        }
    }
    // Class to hold the UserModel
    public class UserModel
    {
        public string UserName { get; set; }
        public bool IsAuthenticated { get; set; }

		public string Token { get; set; }
    }
}