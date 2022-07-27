using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

namespace PadlockSystem
{
    public class PLDisableManager : MonoBehaviour
    {
        public static PLDisableManager instance;

        [SerializeField] private Opsive.UltimateCharacterController.Character.UltimateCharacterLocomotion player = null;
        [SerializeField] private Opsive.UltimateCharacterController.Camera.CameraController playerCamera = null;
        [SerializeField] private Opsive.Shared.Input.UnityInput playerInput = null;
        [SerializeField] private PadlockRaycast mainCameraRaycast = null;
        [SerializeField] private Image crosshair = null; 

        void Awake()
        {
            if (instance != null) { Destroy(gameObject); }
            else { instance = this; DontDestroyOnLoad(gameObject); }
        }

        public void DisablePlayer(bool disable)
        {
            if (disable)
            {
                player.enabled = false;
                playerCamera.enabled = false;
                playerInput.enabled = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                //mainCameraRaycast.enabled = false;
                crosshair.enabled = false;
            }

            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                player.enabled = true;
                playerInput.enabled = true;
                playerCamera.enabled = true;
                //mainCameraRaycast.enabled = true;
                crosshair.enabled = true;
            }
        }
    }
}
