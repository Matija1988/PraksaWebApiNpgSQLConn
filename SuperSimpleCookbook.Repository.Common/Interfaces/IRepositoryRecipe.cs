﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSimpleCookbook.Repository.Common.Interfaces
{
    public interface IRepositoryRecipe<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);

        Task<List<T>> GetNotActive();

        Task<T> Post(T item);

        Task<T> Put(T item, int id);

        Task<bool> Delete(int id);


    }
}
