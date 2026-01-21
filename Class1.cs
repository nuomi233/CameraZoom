using BepInEx;
using BepInEx.Unity.IL2CPP;
using UnityEngine;
using Cinemachine;
using Il2CppInterop.Runtime;
using BepInEx.Logging;

namespace CameraZoom
{
    [BepInPlugin("com.custom.camerazoom", "Editor Camera Controller", "1.0.0")]
    public class CameraMod : BasePlugin
    {
        public static ManualLogSource? InstanceLog;

        public override void Load()
        {
            InstanceLog = Log;
            AddComponent<ZoomHandler>();
            Log.LogInfo("CameraMod v1.0.0 加载：已就绪。");
        }

        public class ZoomHandler : MonoBehaviour
        {
            private Vector3 virtualPoint;
            private bool hasInitialized = false;
            private bool isPaused = false;
            private bool isMovementEnabled = false; // 控制移动功能的开关

            void Update()
            {
                var cam = Camera.main;
                if (cam == null) return;

                // --- 0. 初始化 ---
                if (!hasInitialized)
                {
                    virtualPoint = cam.transform.position + cam.transform.forward * 18.0f;
                    hasInitialized = true;
                }

                cam.nearClipPlane = 0.01f;

                // --- 1. 功能开关控制 ---

                // 按 9 切换移动功能锁定状态
                if (Input.GetKeyDown(KeyCode.Alpha9))
                {
                    isMovementEnabled = !isMovementEnabled;
                    CameraMod.InstanceLog?.LogInfo("移动功能: " + (isMovementEnabled ? "已启用" : "已锁定"));
                }

                // 按 Backspace 暂停/继续
                if (Input.GetKeyDown(KeyCode.Backspace))
                {
                    isPaused = !isPaused;
                    Time.timeScale = isPaused ? 0.0f : 1.0f;
                }

                // --- 2. 移动逻辑 (仅在 isMovementEnabled 为 true 时生效) ---
                if (isMovementEnabled)
                {
                    // 左键：前后同步平移
                    if (Input.GetMouseButton(0))
                    {
                        float moveSpeed = 0.2f;
                        float mouseDeltaY = Input.GetAxis("Mouse Y");
                        Vector3 offset = cam.transform.forward * mouseDeltaY * moveSpeed;
                        cam.transform.position += offset;
                        virtualPoint += offset;
                    }

                    // 中键：整体平移
                    if (Input.GetMouseButton(2))
                    {
                        float panSpeed = 0.04f;
                        float moveX = Input.GetAxis("Mouse X") * panSpeed;
                        float moveY = Input.GetAxis("Mouse Y") * panSpeed;
                        Vector3 offset = cam.transform.right * -moveX + cam.transform.up * -moveY;
                        cam.transform.position += offset;
                        virtualPoint += offset;
                    }

                    // 滚轮：改变旋转半径
                    float scroll = Input.GetAxis("Mouse ScrollWheel");
                    if (scroll != 0)
                    {
                        float zoomSpeed = 3.0f;
                        Vector3 direction = (virtualPoint - cam.transform.position).normalized;
                        float dist = Vector3.Distance(cam.transform.position, virtualPoint);
                        float moveAmount = scroll * zoomSpeed;

                        if (moveAmount > 0 && (dist - moveAmount) < 0.1f)
                            cam.transform.position = virtualPoint - direction * 0.1f;
                        else
                            cam.transform.position += direction * moveAmount;
                    }

                    // 右键：围绕锚点旋转
                    if (Input.GetMouseButton(1))
                    {
                        float rotateSpeed = 0.4f;
                        float mouseX = Input.GetAxis("Mouse X") * rotateSpeed;
                        float mouseY = Input.GetAxis("Mouse Y") * rotateSpeed;
                        cam.transform.RotateAround(virtualPoint, Vector3.up, mouseX);
                        cam.transform.RotateAround(virtualPoint, cam.transform.right, -mouseY);
                    }
                }

                // --- 3. 辅助功能 (不受 9 键锁定影响) ---

                // 按 0 切换自由相机开关
                if (Input.GetKeyDown(KeyCode.Alpha0))
                {
                    var brainType = Il2CppType.Of<CinemachineBrain>();
                    var brainObj = UnityEngine.Object.FindObjectOfType(brainType);
                    if (brainObj != null)
                    {
                        brainObj.Cast<CinemachineBrain>().enabled = !brainObj.Cast<CinemachineBrain>().enabled;
                    }
                }

                // 按 \ 重置视角
                if (Input.GetKeyDown(KeyCode.Backslash))
                {
                    cam.transform.localPosition = Vector3.zero;
                    cam.transform.localRotation = Quaternion.identity;
                    virtualPoint = cam.transform.position + cam.transform.forward * 18.0f;
                    CameraMod.InstanceLog?.LogInfo("视角已重置。");
                }
            }
        }
    }
}