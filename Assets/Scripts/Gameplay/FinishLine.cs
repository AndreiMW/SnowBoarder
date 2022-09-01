
/**
 * Created Date: 9/1/2022
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2022 Andrei-Florin Ciobanu. All rights reserved. 
 */

using UnityEngine;

namespace Gameplay {
	public class FinishLine : MonoBehaviour {
		
		#region Collision

		private void OnTriggerEnter2D(Collider2D col) {
			if (col.CompareTag("Player")) {
				//TODO Implement level won 
			}
		}

		#endregion
	}
}