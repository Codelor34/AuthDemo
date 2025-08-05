using System;
using System.Collections.Generic;
using AuthDemo.Models;

namespace AuthDemo.Areas.Admin.Interface
{
    public interface IChatLieuService
    {
        IEnumerable<ChatLieu> GetAll();
        ChatLieu? GetById(Guid id);
        void Add(ChatLieu entity);
        void Update(ChatLieu entity);
        void Delete(Guid id);
    }
} 