using Player.State;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player {
    public class PlayerCore : MonoBehaviour {
        [Header("Components")]
        [SerializeField] PlayerStateMathine state;

        [Header("HitChecker")]
        [SerializeField] PlayerLandingChecker landingChecker;
        [SerializeField] PlayerDamageChecker damageChecker;

		//--------------------------------------------------

		// Properties
        public PlayerStateMathine State => state;

        // Flags
        public bool IsLanding => landingChecker.IsLanding;
        public bool IsDamaged => damageChecker.IsDamaged;

		//--------------------------------------------------
	}
}