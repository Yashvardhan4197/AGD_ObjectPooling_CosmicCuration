
using CosmicCuration.Enemy;
using System.Collections.Generic;

public class EnemyPool
{
    private EnemyView enemyPrefab;
    private EnemyData enemyData;
    private List<PooledEnemy>pooledEnemies=new List<PooledEnemy>();
    public EnemyPool(EnemyView enemyPrefab, EnemyData enemyData)
    {
        this.enemyData = enemyData;
        this.enemyPrefab = enemyPrefab;
    }

    private EnemyController CreateEnemyController()
    {
        PooledEnemy pooledEnemy = new PooledEnemy();
        pooledEnemy.enemyController=new EnemyController(enemyPrefab,enemyData);
        pooledEnemy.isUsed = true;
        pooledEnemies.Add(pooledEnemy);
        return pooledEnemy.enemyController;
    }

    public EnemyController GetEnemy()
    {
        if(pooledEnemies.Count > 0)
        {
            PooledEnemy pooledEnemy = pooledEnemies.Find(item => !item.isUsed);
            if(pooledEnemy != null)
            {
                pooledEnemy.isUsed = true;
                return pooledEnemy.enemyController;
            }
        }
        return CreateEnemyController();
    }

    public void ReturnEnemyToPool(EnemyController enemyController)
    {
        PooledEnemy pooledEnemy = pooledEnemies.Find(item => item.enemyController.Equals(enemyController));
        pooledEnemy.isUsed=false;
    }

    public class PooledEnemy
    {
        public EnemyController enemyController;
        public bool isUsed;
    }
}
