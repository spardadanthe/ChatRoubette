using System.Collections.Generic;

namespace Client.Controllers
{
    public class AddToConversationRequestModel
    {
        public AddToConversationRequestModel()
        {
            Ids = new List<string>();
        }

        public List<string> Ids { get; set; }
    }
}