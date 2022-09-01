﻿/**
 * Created Date: 08/23/2022
 * Author: Andrei-Florin Ciobanu
 * 
 * Copyright (c) 2022 Andrei-Florin Ciobanu. All rights reserved. 
 */

using System;

using UnityEngine;

using CurrentLevel = Level.Level;
using Level;

namespace Managers {
public class LevelManager : UnitySingleton<LevelManager>{
    public event Action OnLevelLoaded;
    
    private LevelData[] _levelDatas;
    public LevelData CurrentLevelData{ get; private set; }
    public CurrentLevel CurrentLevelInstance{ get; private set; }
    
    private int _currentLevelIndex;
    private int _actualLevelIndex;

    #region Lifecycle

    public override void Awake() {
        base.Awake();
        this._levelDatas = Resources.LoadAll<LevelData>("LevelData");
    }

    private void Start() {
	    this._currentLevelIndex = UserSettingsManager.Instance.CurrentLevelIndex;
    }

    #endregion
    
    #region Public

    /// <summary>
    /// Load next level index that is saved in PlayerPrefs.
    /// </summary>
    public void LoadLevel() {
	    this._actualLevelIndex = this._currentLevelIndex;
        while (this._actualLevelIndex >= this._levelDatas.Length) {
            this._actualLevelIndex -= (this._levelDatas.Length - 1);
        }
        Debug.Log($"Loaded level {this._actualLevelIndex} for {this._currentLevelIndex}");
        this.CurrentLevelData = this._levelDatas[this._actualLevelIndex];
        if (this.CurrentLevelInstance != null){
            Destroy(this.CurrentLevelInstance.gameObject);
            this.CurrentLevelInstance = null;
        }
        this.CurrentLevelInstance = GameObject.Instantiate(this._levelDatas[this._actualLevelIndex].LevelPrefab, this.transform);
        this.OnLevelLoaded?.Invoke();
    }

    /// <summary>
    /// Increase the level index.
    /// </summary>
    public void IncrementLevelIndex() {
	    this._currentLevelIndex++;
        
	    UserSettingsManager.Instance.CurrentLevelIndex = this._currentLevelIndex;	    
    }
    
    #endregion
	}	
}