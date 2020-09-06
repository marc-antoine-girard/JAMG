using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlowLoadingGame : IGameFlow
{
#region Singleton

    private static GameFlowLoadingGame instance = null;

    private GameFlowLoadingGame() { }

    public static GameFlowLoadingGame Instance {
        get { return instance ?? (instance = new GameFlowLoadingGame()); }
        private set { instance = value; }
    }

#endregion

    public void PreInitialize() { }

    public void Initialize() { }

    public void Refresh() {
        GameFlowManager.Instance.SetGameFlow(GameFlowMenuLoop.Instance);
    }

    public void PhysicRefresh() { }

    public void LateRefresh() { }

    public void Terminate() {
#if UNITY_EDITOR
        Debug.Log("End of loading");
#endif
    }
}