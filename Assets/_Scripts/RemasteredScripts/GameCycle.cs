using System.Collections.Generic;
using UnityEngine;


namespace GameInit.GameCycleModule
{
    [DisallowMultipleComponent]
    public class GameCycle : MonoBehaviour
    {
        private readonly Dictionary<CycleMethod, List<ICallable>> _classesToUpdate = new Dictionary<CycleMethod, List<ICallable>>();

        public void Init()
        {
            _classesToUpdate[CycleMethod.Update] = new List<ICallable>();

            _classesToUpdate[CycleMethod.LateUpdate] = new List<ICallable>();
        }
       
        public void Add(CycleMethod method, ICallable callable)
        {
            if (!_classesToUpdate[method].Contains(callable))
            {
                _classesToUpdate[method].Add(callable);
            }
        }

        public void Remove(CycleMethod method, ICallable callable)
        {
            if (_classesToUpdate[method].Contains(callable))
            {
                _classesToUpdate[method].Remove(callable);
            }
        }

        private void Update()
        {
            foreach (var item in _classesToUpdate[CycleMethod.Update].ToArray())
            {
                item.UpdateCall();
            }
        }

        private void LateUpdate()
        {
            foreach (var item in _classesToUpdate[CycleMethod.LateUpdate].ToArray())
            {
                item.UpdateCall();
            }
        }
    }
}
