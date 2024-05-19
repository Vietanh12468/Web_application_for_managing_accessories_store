using Microsoft.AspNetCore.Mvc;
using Web_application_for_managing_accessories_store.Utility;
using Web_application_for_managing_accessories_store.Models;

namespace Web_application_for_managing_accessories_store.Controllers
{
    public class UserController : Controller
    {
        private readonly UserUtility _userUtility;
        public UserController(UserUtility userUtility) => _userUtility = userUtility;
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ViewUsers(string id)
        {
            var users = await _userUtility.GetAsync(id);
            if (users is null)
            {
                return NotFound();
            }

            return View(users);
        }
    }
}
