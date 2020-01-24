using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class NewAttemptSound
    {
        public int GameId { set; get; }
        public IFormFile FormData { set; get; }
    }
}
