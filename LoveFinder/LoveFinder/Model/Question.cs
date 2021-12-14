using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoveFinder.Model
{
    public class Question
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        [MaxLength(200)]
        public string test { get; set; }

        public Question()
        {

        }
    }
}
