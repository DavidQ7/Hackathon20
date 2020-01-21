using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DbModels
{
    public class Game
    {
        public int Id { set; get; }
        public bool? Won { set; get; }
        public bool Ended { set; get; }
        public int UserId { set; get; }
        public User User { set; get; }
        public List<Attempt> Attempts { set; get; }
    }
}
