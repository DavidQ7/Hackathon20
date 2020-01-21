using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class LyricsResponse
    {
        public string Status { set; get; }
        public List<LyricsSound> Result { set; get; }
    }
}
