using LaererVikaren.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace LaererVikaren.ViewModels
{
    public abstract class TEntityViewModelBase<TEntity> : SuperClassViewModel
    where TEntity : class, new()
    {
        protected TEntity entity;

        protected TEntityViewModelBase(TEntity entity)
        {
            this.entity = entity;
        }
    }
}
