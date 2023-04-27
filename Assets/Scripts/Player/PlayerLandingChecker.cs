using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player {
	public class PlayerLandingChecker : MonoBehaviour {
		public bool IsLanding { get; private set; }

		//--------------------------------------------------

		private void OnCollisionEnter(Collision collision)
		{
			IsLanding = true;
		}

		private void OnCollisionExit(Collision collision)
		{
			IsLanding = false;
		}
	}
}