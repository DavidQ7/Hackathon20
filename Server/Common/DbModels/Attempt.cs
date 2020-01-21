using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DbModels
{
    public class Attempt
    {
        public int Id { set; get; }
        public bool Result { set; get; }
        public int GameId { set; get; }
        public Game Game { set; get; }
        public long SoundId { set; get; }
    }
}
