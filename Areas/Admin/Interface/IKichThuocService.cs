using System;
using System.Collections.Generic;
using AuthDemo.Models;

namespace AuthDemo.Areas.Admin.Interface
{
    public interface IKichThuocService
    {
        IEnumerable<KichThuoc> GetAll();
        KichThuoc? GetById(Guid id);
        void Add(KichThuoc entity);
        void Update(KichThuoc entity);
        void Delete(Guid id);
    }
} 