﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  public  class Skill
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsBackend { get; set; }
    }
}
