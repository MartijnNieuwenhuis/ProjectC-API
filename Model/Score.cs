using Model.Core;
using Model.Interfaces;
using System;

namespace Model
{
    public class Score : BaseModel, ISaveable
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public String UserName { get; set; }

        public Int32? Rank { get; set; }

        public Int32 Points { get; set; }

        public DateTimeOffset Date { get; set; }
    }
}