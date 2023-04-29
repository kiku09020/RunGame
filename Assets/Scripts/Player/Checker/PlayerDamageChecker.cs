using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player {
    public class PlayerDamageChecker : MonoBehaviour {

        public bool IsDamaged { get; set; }

		//--------------------------------------------------
		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.tag == "Damage") {
				IsDamaged = true;
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.gameObject.tag == "Damage") {
				IsDamaged = false;
			}
		}
	}
}