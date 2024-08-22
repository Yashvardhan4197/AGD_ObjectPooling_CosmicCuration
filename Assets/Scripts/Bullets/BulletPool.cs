using CosmicCuration.Bullets;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    private BulletView bulletView;
    private BulletScriptableObject bulletScriptableObject;
    private List<PooledBullet>pooledBullets = new List<PooledBullet>();

    private BulletController CreateBulletController()
    {
        PooledBullet pooledBullet = new PooledBullet();
        pooledBullet.bulletController = new BulletController(bulletView, bulletScriptableObject);
        pooledBullet.isUsed = true;
        pooledBullets.Add(pooledBullet);
        return pooledBullet.bulletController;
    }

    public BulletPool(BulletView bulletView,BulletScriptableObject bulletScriptableObject)
    {
        this.bulletView = bulletView;  
        this.bulletScriptableObject= bulletScriptableObject;
    }

    public BulletController GetBullet()
    {
        PooledBullet pooledBullet = pooledBullets.Find(item => !item.isUsed);
        if(pooledBullet != null)
        {
            pooledBullet.isUsed = true;
            return pooledBullet.bulletController;
        }
        return CreateBulletController();
    }

    public void ReturntoBulletPool(BulletController returnController)
    {
        PooledBullet pooledBullet=pooledBullets.Find(item=>item.bulletController.Equals(returnController));
        pooledBullet.isUsed = false;
    }
   public class PooledBullet
    {
        public BulletController bulletController;
        public bool isUsed;
    }
}
