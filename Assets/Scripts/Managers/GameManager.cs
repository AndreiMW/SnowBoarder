/**
 * Created Date: 9/1/2022
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2022 Andrei-Florin Ciobanu. All rights reserved. 
 */

using System;
using UnityEngine;

namespace Managers {
	public sealed class GameManager : UnitySingleton<GameManager> {
		
		#region Lifecycle

		private void Start() {
			LevelManager.Instance.LoadLevel();

			LevelManager.Instance.OnLevelEnded += this.HandleLevelEnd;
		}

		#endregion
		
		#region Private

		private void HandleLevelEnd(bool won) {
			if (won) {
				//TODO display level won UI
			} else {
				//TODO display level lost UI
			}
		}
		
		#endregion
	}
}