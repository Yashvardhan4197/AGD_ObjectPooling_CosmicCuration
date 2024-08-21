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
   public class PooledBullet
    {
        public BulletController bulletController;
        public bool isUsed;
    }
}
