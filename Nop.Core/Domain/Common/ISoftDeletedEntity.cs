using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Core.Domain.Common
{
    public interface ISoftDeletedEntity
    {
        public bool Deleted { get; set; }

    }
}
