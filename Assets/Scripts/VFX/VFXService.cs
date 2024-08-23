using Assets.Scripts.VFX;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.VFX
{
    public class VFXService
    {
        private List<VFXData> vfxData = new List<VFXData>();
        public VFXPool vfxPool;
        public VFXService(VFXScriptableObject vfxScriptableObject)
        {
            vfxPool=new VFXPool();

            vfxData = vfxScriptableObject.vfxData;
        }

        public void PlayVFXAtPosition(VFXType type, Vector2 spawnPosition)
        {
            VFXView prefabToSpawn = vfxData.Find(item => item.type == type).prefab;
            VFXController vfxToPlay = vfxPool.GetVFX(prefabToSpawn);
            vfxToPlay.Configure(spawnPosition);
        }

        public void ReturnToPool(VFXController vFXController) => vfxPool.ReturnItem(vFXController); 
    } 
}