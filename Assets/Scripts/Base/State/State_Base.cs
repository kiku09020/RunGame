using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameController.State {
    public abstract class State_Base : MonoBehaviour {

        public abstract void OnEnter();
        public abstract void OnUpdate();
        public abstract void OnExit();
    }
}