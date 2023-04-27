using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player {
	public class PlayerLandingChecker : MonoBehaviour {
		public bool IsLanding { get; private set; }

		//--------------------------------------------------

		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.tag == "Stage") {
				IsLanding = true;
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (other.gameObject.tag == "Stage") {
				IsLanding = false;
			}
		}
	}
}