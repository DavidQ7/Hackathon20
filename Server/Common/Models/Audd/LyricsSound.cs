using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class LyricsSound
    {
        public int Song_id { set; get; }
        public long Artist_id { set; get; }
        public string Title { set; get; }
        public string Title_with_featured { set; get; }
        public string Full_title { set; get; }
        public string Artist { set; get; }
        public string Lyrics { set; get; }
    }
}
