using Model.Core;
using Model.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class User : BaseModel, ISaveable
    {
        public Guid Id { get; set; }

        public String UserName { get; set; }

        [MaxLength(12)]
        public String Password { get; set; }

        public SecurityQuestionEnum SecurityQuestion { get; set; }

        public String SecurityQuestionAnswer { get; set; }
    }
}