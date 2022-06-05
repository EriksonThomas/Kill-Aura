    using UnityEngine;
    using Cinemachine;
     
    public class AutoAddPlayerToVcamTargets : MonoBehaviour
    {
        void Update()
        {
            var vcam = GetComponent<CinemachineVirtualCameraBase>();
            if (vcam != null)
            {
                var target = GameHandler.instance.player;
                vcam.LookAt = vcam.Follow = target.transform;
            }
        }
    }
