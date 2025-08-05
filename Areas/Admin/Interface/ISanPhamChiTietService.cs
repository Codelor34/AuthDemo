using System;
using System.Collections.Generic;
using AuthDemo.Models;
using static AuthDemo.Models.ViewModels.ChiTietGiayVM;

namespace AuthDemo.Areas.Admin.Interface
{
    public interface IChiTietGiayService
    {
        IEnumerable<ChiTietGiay> GetAll();
        ChiTietGiay? GetById(Guid id);
        void Add(ChiTietGiay entity);
        void Update(EditVM entity);
        void Delete(Guid id);
    }
} 