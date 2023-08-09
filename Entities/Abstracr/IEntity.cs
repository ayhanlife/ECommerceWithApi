using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Abstracr
{
    /// <summary>
    /// Veritabanına karşılık gelen tabloalrda bulunacak (imza)
    /// </summary>
    public interface IEntity
    {
        int Id { get; set; }
    }
}
