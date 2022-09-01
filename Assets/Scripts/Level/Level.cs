/**
 * Created Date: 08/23/2022
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2022 Andrei-Florin Ciobanu. All rights reserved. 
 */

using UnityEngine;

namespace Level {
	public class Level : MonoBehaviour {
		[SerializeField]
		private SurfaceEffector2D _surfaceEffector2D;
		
		#region Public

		public void ChangeSurfaceEffectorState(bool enabled) {
			this._surfaceEffector2D.enabled = enabled;
		}
		
		#endregion
	}
}
