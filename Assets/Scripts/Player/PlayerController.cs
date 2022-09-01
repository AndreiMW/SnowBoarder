/**
 * Created Date: 9/1/2022
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2022 Andrei-Florin Ciobanu. All rights reserved. 
 */

using UnityEngine;

namespace Player {
	public class PlayerController : MonoBehaviour {
		private Rigidbody2D _rigidbody2D;
	
		#region Lifecycle

		private void Awake() {
			this._rigidbody2D = this.GetComponent<Rigidbody2D>();
		}

		private void FixedUpdate() {
			if (Input.GetMouseButton(0)) {
				this._rigidbody2D.AddTorque(3f);
			}
		}

		#endregion
		
		#region Collision

		private void OnTriggerEnter2D(Collider2D col) {
			if (col.gameObject.CompareTag("Ground")) {
				//TODO implement level lost logic.
			}
		}

		#endregion
	}	
}