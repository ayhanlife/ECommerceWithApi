﻿namespace Core.Entities
{
    /// <summary>
    /// Veritabanına karşılık gelen tabloalrda bulunacak (imza)
    /// </summary>
    public interface IEntity
    {
        int Id { get; set; }
    }
}
