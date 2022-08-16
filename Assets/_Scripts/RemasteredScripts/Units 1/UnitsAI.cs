using GamePlay.Work;
using GameInit.UnitsPrefab;
using UnityEngine;
using GamePlay.NomandsCamp;
using System;
using System.Collections.Generic;
using GameInit.Job;

namespace GamePlay.Units
{
    public class UnitsAI : IDisposable
    {
        private GameObject prefab;
        private NomandsComponet nomandsComponet;
        private CollisionComponent collision;
        private IJob State;

        private event Action collectCoin;
        public UnitsAI(GameObject _prefab, NomandsComponet _nomandsComponet)
        {
            prefab = _prefab;
            collision = _prefab.GetComponent<CollisionComponent>();
            ActionAdd();
            collision.AddAction(collectCoin);
            nomandsComponet = _nomandsComponet;
        }
        public void StateChange(IJob _State)
        {
            State = _State;
        }
        private void ActionAdd()
        {
            collectCoin += doSmth;
        }

        public void doSmth()
        {
            if (State.GetType() != new NomandState().GetType())
            {
                State.Enter();
            }
        }
        public void Dispose()
        {
            collectCoin -= doSmth;
        }
    }
}

