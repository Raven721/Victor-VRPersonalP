using UnityEngine;
using TMPro; // 引用TextMeshPro命名空间
using UnityEngine.XR.Interaction.Toolkit; // 引用XR Interaction Toolkit

public class TeleportationManager : MonoBehaviour
{
    public TMP_Text teleportCountText; // 在Inspector中设置的TextMeshPro文本组件
    public GameObject[] vfxObjects; // 在Inspector中设置的VFX对象数组
    private int teleportCount = 0; // 用于跟踪传送次数

    void Start()
    {
        UpdateTeleportCountText();
        // 查找所有TeleportationProvider并为它们的events添加监听器
        var teleportProviders = FindObjectsOfType<TeleportationProvider>();
        foreach (var provider in teleportProviders)
        {
            provider.endLocomotion += OnEndLocomotion;
        }
    }

    private void OnDestroy()
    {
        // 清理：为所有TeleportationProvider移除监听器
        var teleportProviders = FindObjectsOfType<TeleportationProvider>();
        foreach (var provider in teleportProviders)
        {
            provider.endLocomotion -= OnEndLocomotion;
        }
    }

    private void OnEndLocomotion(LocomotionSystem locomotionSystem)
    {
        teleportCount++; // 每次传送后增加计数
        UpdateTeleportCountText();

        // 根据传送次数激活特定的VFX
        ActivateVFX(teleportCount);
    }

    private void UpdateTeleportCountText()
    {
        // 更新TextMeshPro文本显示当前传送次数
        teleportCountText.text = "Teleport Count: " + teleportCount;
    }

    private void ActivateVFX(int count)
    {
        // 根据传送次数激活特定的VFX对象
        if (count == 2 && vfxObjects.Length > 0)
        {
            vfxObjects[0].SetActive(true);
        }
        else if (count == 5 && vfxObjects.Length > 1)
        {
            vfxObjects[1].SetActive(true);
        }
        else if (count == 6 && vfxObjects.Length > 1)
        {
            vfxObjects[2].SetActive(true);
        }

        // 这里可以根据需要添加更多条件
    }
}
