/**
 * Created Date: 9/1/2022
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2022 Andrei-Florin Ciobanu. All rights reserved. 
 */

using UnityEngine;

using Managers;

namespace Player {
	public class PlayerController : MonoBehaviour {
		[SerializeField]
		private int _torqueValue = 3;

		
		private Rigidbody2D _rigidbody2D;
		
		private Vector3 _originalPosition;
		private Quaternion _originalRotation;
	
		#region Lifecycle

		private void Awake() {
			this._rigidbody2D = this.GetComponent<Rigidbody2D>();
			
			this._originalPosition = this.transform.position;
			this._originalRotation = this.transform.rotation;
		}

		private void FixedUpdate() {
			if (Input.GetMouseButton(0)) {
				float xPos = Input.mousePosition.x;

				if (xPos <= Screen.width / 2) {
					this._torqueValue = Mathf.Abs(this._torqueValue);
				} else {
					this._torqueValue = -Mathf.Abs(this._torqueValue);
				}
				this._rigidbody2D.AddTorque(this._torqueValue);
			}
		}

		#endregion
		
		#region Collision

		private void OnTriggerEnter2D(Collider2D col) {
			if (GameManager.Instance.IsGameStarted) {
				if (col.gameObject.CompareTag("Ground")) {
					LevelManager.Instance.TriggerLevelEnd(false);
				}

				if (col.gameObject.CompareTag("Finish")) {
					LevelManager.Instance.TriggerLevelEnd(true);
				}
			}
		}

		#endregion
		
		#region Public

		public void Reset() {
			this.transform.SetPositionAndRotation(this._originalPosition,this._originalRotation);
		}
		
		#endregion
	}	
}