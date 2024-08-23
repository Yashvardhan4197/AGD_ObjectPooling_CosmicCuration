using CosmicCuration.Utilities;
using CosmicCuration.VFX;

namespace Assets.Scripts.VFX
{
    public class VFXPool:GenericObjectPool<VFXController>
    {
        private VFXView vFXPrefab;
        

        public VFXController GetVFX(VFXView vFXView)
        {
            this.vFXPrefab = vFXView;
            return GetItem<VFXController>();
        }

        protected override VFXController CreateItem<U>()
        {
            return new VFXController(vFXPrefab);
        }
    }
}
