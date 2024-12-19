using Zenject;

namespace Game.Ammo
{
    public class AmmoCollectedHandler
    {
        private Ammo.Pool _pool;
        private AmmoCounter _ammoCounter;

        [Inject]
        public void Construct(Ammo.Pool pool, AmmoCounter ammoCounter)
        {
            _ammoCounter = ammoCounter;
            _pool = pool;
        }

        public void Collect(Ammo target)
        {
            _ammoCounter.AddAmmo(target.AmmoCount);
            _pool.Despawn(target);
        }
    }
}