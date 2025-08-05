using System;
using System.Collections.Generic;
using AuthDemo.Models;

namespace AuthDemo.Areas.Admin.Interface
{
    public interface IThuongHieuService
    {
        IEnumerable<ThuongHieu> GetAll();
        ThuongHieu? GetById(Guid id);
        void Add(ThuongHieu entity);
        void Update(ThuongHieu entity);
        void Delete(Guid id);
    }
} 