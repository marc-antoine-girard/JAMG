using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainEntry : MonoBehaviour
{
#region

    public static MainEntry Instance = null;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
            //GameObject.DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

#endregion

    private void Start() { }

    private void Update() { }

    private void FixedUpdate() { }

    private void LateUpdate() { }

    private void OnApplicationFocus(bool hasFocus) { }

    private void OnApplicationPause(bool pauseStatus) { }

    private void OnApplicationQuit() { }
}