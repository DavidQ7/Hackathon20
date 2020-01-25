using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class Statistic
    {
        public int Wins { set; get; }
        public int Losses { set; get; }
        public int NotFinished { set; get; }
        public List<GameDTO> Games { set; get; }
    }
}
