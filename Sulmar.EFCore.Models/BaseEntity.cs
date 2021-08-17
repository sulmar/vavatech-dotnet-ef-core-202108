﻿using System;

namespace Sulmar.EFCore.Models
{
    public abstract class BaseEntity : Base
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

    }
}





