
using GameInit.Component;
using GameInit.GameCycleModule;
using GameInit.Pool;
using UnityEngine;
using NomadComponent = GameInit.Component.NomadComponent;

namespace GameInit.Nomads
{
    public class NomadUpdateCycle : IUpdate
    {
        private GameCycle _cycle;
        private NomadComponent _nomad;
        private Pools _citizenPoolBuilder;
        private NomadsCampComponent _nomadsCampComponent;

        public NomadUpdateCycle(GameCycle cycle, NomadComponent nomad, NomadsCampComponent nomadsCampComponent, Pools citizenPool)
        {
            _cycle = cycle;
            _nomad = nomad;
            _nomadsCampComponent = nomadsCampComponent;
            _citizenPoolBuilder = citizenPool;
        }

        public void OnUpdate()
        {
            if (_nomad.IsCollided)
            {
                _nomad.Coin.Hide();

                if (_citizenPoolBuilder.TryGetElement(out GameObject go))
                {
                    go.transform.position = _nomad.transform.position;
                    _nomadsCampComponent.NomadPool.Pool.Release(_nomad.gameObject);

                    _cycle.Remove(this);
                }
            }
        }
    }
}
