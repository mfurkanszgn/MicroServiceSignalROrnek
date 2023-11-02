using Inveon.Web.Hubs;
using Inveon.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Inveon.Web.Areas.Message
{
    public class MessageController : Controller
    {
        private readonly IHubContext<MessageHub> _messageHub;

        public MessageController(IHubContext<MessageHub> messageHub)
        {
            _messageHub = messageHub;
        }

        [Route("[Controller]")]
        [HttpPost]
        public IActionResult Message([FromBody] MessageModel message)
        {
            //same bussines rules
            if(message != null)
            {
                _messageHub.Clients.All.SendAsync("sendMessage", message);
            }
         

            return Accepted();  
        }

        [Route("Partial")]
        [HttpPost]
        public ActionResult DisplayNewMessageBox([FromBody] MessageModel message)
        {
            return PartialView("_MessageBoxPartial", message);
        }
    }
}
