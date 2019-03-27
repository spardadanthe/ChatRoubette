using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Persistence.Interfaces;

namespace Chatman.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversationsController : ControllerBase
    {
        private readonly IRepository<Conversation> convRepository;

        public ConversationsController(IRepository<Conversation> convRepository)
        {
            this.convRepository = convRepository;
        }

        [HttpGet]
        public ActionResult<ICollection<Conversation>> Get()
        {
            ICollection<Conversation> allConvs = convRepository.GetAll();

            return Ok(allConvs);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Conversation> Get(string id)
        {
            var conversation = convRepository.GetAll().SingleOrDefault(x => x.Id.Value == id);
            return Ok(conversation);
        }

        [HttpPost()]
        public ActionResult Post(Conversation conv)
        {
            bool found = convRepository.GetAll().Any(x => x.Id == conv.Id);
            if (found)
            {
                convRepository.GetAll().ToHashSet().RemoveWhere(x => x.Id.Value == conv.Id.Value);
                convRepository.Add(conv);
            }
            return Ok();
        }


    }
}