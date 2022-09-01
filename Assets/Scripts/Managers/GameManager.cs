/**
 * Created Date: 9/1/2022
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2022 Andrei-Florin Ciobanu. All rights reserved. 
 */

using UnityEngine;

using Player;

namespace Managers {
	public sealed class GameManager : UnitySingleton<GameManager> {
		[SerializeField]
		private PlayerController _player;
		
		public bool IsGameStarted { get; private set; }
		#region Lifecycle

		private new void Awake() {
			LevelManager.Instance.OnLevelLoaded += this.HandleLevelLoaded;
		}
		private void Start() {
			LevelManager.Instance.LoadLevel();
			
			LevelManager.Instance.OnLevelEnded += this.HandleLevelEnd;
		}

		#endregion
		
		#region Private

		private void HandleLevelEnd(bool won) {
			UIManager.Instance.ShowLevelEndUI(won);
			this.IsGameStarted = false;
		}

		private void HandleLevelLoaded() {
			this.IsGameStarted = true;
			this._player.Reset();
		}
		
		#endregion
	}
}