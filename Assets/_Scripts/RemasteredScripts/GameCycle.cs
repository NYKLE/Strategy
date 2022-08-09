using System.Collections.Generic;
using UnityEngine;


namespace GameInit.GameCycleModule
{
    [DisallowMultipleComponent]
    public class GameCycle : MonoBehaviour
    {
      //  private readonly Dictionary<CycleMethod, List<ICallable>> _classesToUpdate = new Dictionary<CycleMethod, List<ICallable>>();

        // ====== TEST ======
        private readonly List<IUpdate> _updates = new List<IUpdate>(100);
        private readonly List<ILateUpdate> _lateUpdates = new List<ILateUpdate>(20);
        // ==================

       /* public void Init()
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
        }*/

        // ====== TEST ======
        public void Add(IUpdate update)
        {
            _updates.Add(update);
        }

        public void Add(ILateUpdate lateUpdate)
        {
            _lateUpdates.Add(lateUpdate);
        }

        public void Remove(IUpdate update)
        {
            _updates.Remove(update);
        }

        public void Remove(ILateUpdate lateUpdate)
        {
            _lateUpdates.Remove(lateUpdate);
        }
        // ==================

        private void Update()
        {
            /*foreach (var item in _classesToUpdate[CycleMethod.Update].ToArray())
            {
                item.UpdateCall();
            }*/

            // ====== TEST ======
            foreach (var update in _updates.ToArray())
            {
                update.OnUpdate();
            }
            // ==================
        }

        private void LateUpdate()
        {
            /*foreach (var item in _classesToUpdate[CycleMethod.LateUpdate].ToArray())
            {
                item.UpdateCall();
            }*/

            // ====== TEST ======
            foreach (var lateUpdate in _lateUpdates.ToArray())
            {
                lateUpdate.OnLateUpdate();
            }
            // ==================
        }
    }
}
