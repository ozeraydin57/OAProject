﻿using System;
using System.Collections.Generic;
using System.Text;
using Tier.Entities.ComplexType;
using Tier.Entities.Concrete;

namespace Tier.Business.Abstract
{
    public interface IPostService
    {
        List<PostComplex> GetAllComplex(int skip, int take);
        List<PostComplex> GetAllComplexByCategoryId(int skip, int take, int categoryId);
        List<PostComplex> GetAllComplexByUserId(int skip, int take, int userId);
        PostComplex GetComplexById(int id);

        int GetAllCount();
        
        void Add(Post data);
        void Update(Post data);
        void Delete(int id);
        List<Post> GetByCategoryId(int id);
        List<Post> GetByAuthorId(int id);

        Post GetById(int id);

    }
}
