using System.Collections;
using System.Collections.Generic;
using Rewired;
using Unity.Mathematics;
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
        private Rigidbody rb;

        public void PreInitialize() {
            inputs = ReInput.players.GetPlayer(GetNextRewiredPlayerId);

#region Get RigidBody

            if (!TryGetComponent(out Rigidbody body)) {
#if UNITY_EDITOR
                Debug.LogWarning("Player is missing a RigidBody component...");
#endif
                gameObject.AddComponent<Rigidbody>();
            }

            rb = GetComponent<Rigidbody>();

#endregion
        }

        public void Initialize() { }

        public void Refresh() { }

        public void PhysicRefresh() {
            MoveAndRotate(inputs.GetAxis("Horizontal"), inputs.GetAxis("Vertical"));
        }

        private void MoveAndRotate(float axisHorizontal, float axisVertical) {
            if (!IsJoyStickOutsideDeadZone(0.1f, math.abs(axisHorizontal) + math.abs(axisVertical)))
                return;

            //Find next player rotation
            Vector3 newRotation = Quaternion.LookRotation(new Vector3(-axisVertical, 0, axisHorizontal)).eulerAngles;

            //Rotate only on Y axis
            newRotation.x = 0;
            newRotation.z = 0;
            transform.rotation = Quaternion.Euler(newRotation);

            if (rb != null)
                rb.AddForce(transform.forward * 0.1f, ForceMode.VelocityChange);
        }

        private bool IsJoyStickOutsideDeadZone(float deadZone, float value) {
            return (value <= -deadZone || value >= deadZone);
        }
    }
}