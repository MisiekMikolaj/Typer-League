﻿
using System.ComponentModel.DataAnnotations;

namespace TyperLeague.DataAccess.Entities
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
