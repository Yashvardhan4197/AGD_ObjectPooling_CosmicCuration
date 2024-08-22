
using System.Collections.Generic;
using System;

namespace Assets.Scripts.Utilities
{
    internal class GenericObjectPool<T> where T : class
    {
        private List<PooledItem<T>> pooledItems = new List<PooledItem<T>>();
        
        public T GetItem()
        {
            if(pooledItems.Count > 0)
            {
                PooledItem<T> pooledItem = pooledItems.Find(item => !item.isUsed);
                if (pooledItem != null)
                {
                    pooledItem.isUsed = true;
                    return pooledItem.Item;
                }
            }
            return CreatePooledItem();
        }

        private T CreatePooledItem()
        {
            PooledItem<T> newItem = new PooledItem<T>();
            newItem.Item = CreateItem();
            newItem.isUsed = true;
            pooledItems.Add(newItem);
            return newItem.Item;
        }

        protected virtual T CreateItem()
        {
            throw new NotImplementedException("Child Class does not Contain Implementation");
        }

        public class PooledItem<T>
        {
            public T Item;
            public bool isUsed;
        }
    }
}
