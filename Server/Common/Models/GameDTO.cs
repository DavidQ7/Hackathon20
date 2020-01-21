using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class GameDTO
    {
        public int Id { set; get; }
        public bool? Won { set; get; }
        public bool Ended { set; get; }
    }
}
