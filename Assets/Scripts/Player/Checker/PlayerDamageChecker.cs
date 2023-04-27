using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player {
    public class PlayerDamageChecker : MonoBehaviour {

        public bool IsDamaged { get; private set; }

		//--------------------------------------------------
		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.tag == "Stage") {
				IsDamaged = true;
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.gameObject.tag == "Stage") {
				IsDamaged = false;
			}
		}
	}
}