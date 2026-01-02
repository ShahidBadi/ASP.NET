using Microsoft.AspNetCore.Mvc;

namespace MOM.Controllers
{
    public class MeetingMemberController : Controller
    {
        public IActionResult MeetingMembersList()
        {
            return View();
        }
        public IActionResult MeetingMembersAddEdit()
        {
            return View();
        }
    }
}
