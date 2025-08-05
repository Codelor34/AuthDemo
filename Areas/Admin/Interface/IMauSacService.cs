using System;
using System.Collections.Generic;
using AuthDemo.Models;

namespace AuthDemo.Areas.Admin.Interface
{
    public interface IMauSacService
    {
        IEnumerable<MauSac> GetAll();
        MauSac? GetById(Guid id);
        void Add(MauSac entity);
        void Update(MauSac entity);
        void Delete(Guid id);
    }
} 