using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlowMenuLoop : IGameFlow
{
#region Singleton

    private static GameFlowMenuLoop instance = null;

    private GameFlowMenuLoop() { }

    public static GameFlowMenuLoop Instance {
        get { return instance ?? (instance = new GameFlowMenuLoop()); }
        private set { instance = value; }
    }

#endregion

    public void PreInitialize() {
#if UNITY_EDITOR
        Debug.Log("Entering Menu");
#endif
    }

    public void Initialize() { }

    public void Refresh() {
        GameFlowManager.Instance.SetGameFlow(GameFlowGameLoop.Instance);
    }

    public void PhysicRefresh() { }

    public void LateRefresh() { }

    public void Terminate() {
#if UNITY_EDITOR
        Debug.Log("Leaving Menu");
#endif
    }
}