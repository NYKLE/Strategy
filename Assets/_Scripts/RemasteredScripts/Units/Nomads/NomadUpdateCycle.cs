
using GameInit.Builders;
using GameInit.Component;
using NomadComponent = GameInit.Component.NomadComponent;

namespace GameInit.Nomads
{
    public class NomadUpdateCycle : IUpdate
    {
        private bool _isCollided;
        private NomadComponent _nomad;
        private CitizenPoolBuilder _citizenPoolBuilder;
        private NomadsCampComponent _nomadsCampComponent;

        public NomadUpdateCycle(NomadComponent nomad, NomadsCampComponent nomadsCampComponent, CitizenPoolBuilder citizenPoolBuilder)
        {
            _nomad = nomad;
            _nomadsCampComponent = nomadsCampComponent;
            _citizenPoolBuilder = citizenPoolBuilder;
            _isCollided = nomad.IsCollided;
        }

        public void OnUpdate()
        {
            if (_isCollided)
            {
                _nomad.Coin.Hide();

                var go = _citizenPoolBuilder.Pool.Pool.Get();
                go.transform.position = _nomad.transform.position;
                _nomadsCampComponent.NomadPool.Pool.Release(_nomad.gameObject);
            }
        }
    }
}
