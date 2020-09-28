using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.ModelDTO;
using Microsoft.AspNetCore.Mvc;

namespace RepairShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService commentService;

        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        [HttpPost]
        [Route("CreateOrder")]
        public async Task<IActionResult> CreateCommentAsync(CommentDTO commentDTO)
        {
            var serviceActionResult = await commentService.CreateCommentAsync(commentDTO);
            return serviceActionResult.Succedeed
                       ? (IActionResult)Ok(serviceActionResult)
                       : BadRequest(serviceActionResult);
        }
    }
}