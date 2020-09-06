using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;

public class PlayersManager : IManager
{
#region Singleton

    private static PlayersManager instance = null;

    private PlayersManager() { }

    public static PlayersManager Instance {
        get { return instance ?? (instance = new PlayersManager()); }
        private set { instance = value; }
    }

#endregion

    private List<Game.Player> players = new List<Player>();

    public void PreInitialize() { }

    public void Initialize() { }

    public void Refresh() { }

    public void PhysicRefresh() { }

    public void LateRefresh() { }

    public void Terminate() { }
}