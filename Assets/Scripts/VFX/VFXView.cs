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
            transform.position = positionToSet;
            vfx = GetComponent<ParticleSystem>();
            foreach(VFXDatas data in vfxData)
            {
                if(data.type == vFXType)
                {
                    data.particleSystem.gameObject.SetActive(true);
                    vfx=data.particleSystem;
                }
            }
        }

        private void Update()
        {
            if (vfx != null && vfx.isStopped)
            {
                vfx.gameObject.SetActive(false);
                controller.StopVFX();
            }
        }
    }
    [Serializable]
    public class VFXDatas
    {
        public VFXType type;
        public ParticleSystem particleSystem;
    }
}