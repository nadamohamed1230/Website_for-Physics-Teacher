//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Http;
//using DBproject.Models; 
//using DBproject;
//namespace DBproject.Pages.Shared { 
//public class UserController : Controller
//{
//        private readonly DB _db;

//        public UserController(DB db)
//    {
//        _db = db;
//    }

//    // Sample method to get a user by email and password
//    public async Task<User> GetUserFromDatabase(string email, string password)
//    {
//        return await _db.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
//    }

//    [HttpPost]
//    public async Task<IActionResult> Login(string email, string password)
//    {
//        var user = await GetUserFromDatabase(email, password);

//        if (user != null)
//        {
//            HttpContext.Session.SetObject("CurrentUser", user);
//            return RedirectToAction("Profile");
//        }

//        // Handle login failure
//        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
//        return View();
//    }

//    public IActionResult Profile()
//    {
//        var currentUser = HttpContext.Session.GetObject<User>("CurrentUser");
//        return View(currentUser);
//    }

//    public IActionResult Logout()
//    {
//        HttpContext.Session.Clear();
//        return RedirectToAction("Index", "Home");
//    }
//}
