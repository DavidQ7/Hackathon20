using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DbModels
{
    public class User
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Email { set; get; }
        public string Photo { set; get; }
        public int Score { set; get; }
        public int TotalGames {set;get;}
        public int WonGames { set; get; }
        public List<Game> Games { set; get; }
    }
}
