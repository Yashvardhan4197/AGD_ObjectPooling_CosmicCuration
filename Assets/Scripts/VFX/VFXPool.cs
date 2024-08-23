using CosmicCuration.Utilities;
using CosmicCuration.VFX;

namespace Assets.Scripts.VFX
{
    public class VFXPool:GenericObjectPool<VFXController>
    {
        private VFXView vFXPrefab;
        
        public VFXPool(VFXView vFXView)
        {
            this.vFXPrefab = vFXView;
        }

        public VFXController GetVFX()
        {
            return GetItem<VFXController>();
        }

        protected override VFXController CreateItem<U>()
        {
            return new VFXController(vFXPrefab);
        }
    }
}
