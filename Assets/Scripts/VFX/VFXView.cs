using System;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.VFX
{
    public class VFXView : MonoBehaviour
    {
        private VFXController controller;
        private ParticleSystem vfx;
        [SerializeField] private List<VFXDatas> vfxData;
        public void SetController(VFXController controllerToSet) => controller = controllerToSet;
        public void ConfigureAndPlay(VFXType vFXType,Vector2 positionToSet)
        {
            this.gameObject.SetActive(true);
            gameObject.transform.position = positionToSet;
            foreach(VFXDatas data in vfxData)
            {
                if(data.type == vFXType)
                {
                    data.particleSystem.gameObject.SetActive(true);
                    vfx = data.particleSystem;
                }
                else
                {
                    data.particleSystem.gameObject.SetActive(false);
                }
            }
        }

        private void Update()
        {
            if (vfx != null && vfx.isStopped==true)
            {
                vfx.gameObject.SetActive(false);
                controller.StopVFX();
                vfx = null;
                this.gameObject.SetActive(false);
            }
        }
    }
    [Serializable]
    public struct VFXDatas
    {
        public VFXType type;
        public ParticleSystem particleSystem;
    }
}