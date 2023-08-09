using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Abstracr
{
    public interface IUpdatedEntity
    {
        int UpdateUserId { get; set; }
        DateTime? UpdatedDate { get; set; }
    }
}
