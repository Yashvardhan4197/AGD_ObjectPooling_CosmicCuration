using CosmicCuration.Bullets;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    private BulletView bulletView;
    private BulletScriptableObject bulletScriptableObject;
    private List<PooledBullet>pooledBullets = new List<PooledBullet>();

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

    private BulletController CreateBulletController()
    {
        PooledBullet pooledBullet=new PooledBullet();
        pooledBullet.bulletController=new BulletController(bulletView,bulletScriptableObject);
        pooledBullet.isUsed=true;
        return pooledBullet.bulletController;
    }

   public class PooledBullet
    {
        public BulletController bulletController;
        public bool isUsed;
    }
}
