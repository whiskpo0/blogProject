﻿using Nop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Data
{
    public class EntityRepository<TEntity> : IRepository<TEntity> where TEntity: BaseEntity
    {

    }
}
