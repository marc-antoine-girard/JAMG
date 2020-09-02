using System.Collections;
using System.Collections.Generic;
using Rewired;
using UnityEngine;

namespace Game
{
    public class Player : MonoBehaviour
    {
        private static ushort rewiredPlayerId = 0;

        private static ushort GetNextRewiredPlayerId {
            get {
                if (rewiredPlayerId >= GameSettingsDev.AmountPlayerPerGameMax)
                    rewiredPlayerId = 0;
                return rewiredPlayerId++;
            }

            set => rewiredPlayerId = value;
        }

        private Rewired.Player inputs;

        public void PreInitialize() {
            inputs = ReInput.players.GetPlayer(GetNextRewiredPlayerId);
        }

        public void Initialize() { }

        public void Refresh() { }

        public void PhysicRefresh() { }
    }
}