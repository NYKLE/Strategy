
using GameInit.Builders;
using GameInit.Component;
using GameInit.GameCycleModule;
using UnityEngine;
using NomadComponent = GameInit.Component.NomadComponent;

namespace GameInit.Nomads
{
    public class NomadUpdateCycle : IUpdate
    {
        private GameCycle _cycle;
        private NomadComponent _nomad;
        private CitizenPoolBuilder _citizenPoolBuilder;
        private NomadsCampComponent _nomadsCampComponent;

        public NomadUpdateCycle(GameCycle cycle, NomadComponent nomad, NomadsCampComponent nomadsCampComponent, CitizenPoolBuilder citizenPoolBuilder)
        {
            _cycle = cycle;
            _nomad = nomad;
            _nomadsCampComponent = nomadsCampComponent;
            _citizenPoolBuilder = citizenPoolBuilder;
        }

        public void OnUpdate()
        {
            if (_nomad.IsCollided)
            {
                _nomad.Coin.Hide();

                var go = _citizenPoolBuilder.CitizenPool.Pool.Get();
                go.transform.position = _nomad.transform.position;
                _nomadsCampComponent.NomadPool.Pool.Release(_nomad.gameObject);

                _cycle.Remove(this);
            }
        }
    }
}
