using UnityEngine;

public class TriggerVFXAfterTime : MonoBehaviour
{
    // 在Inspector中设置这个数组，包含所有想要触发的VFX Prefabs
    public GameObject[] vfxPrefabs;

    // 起始延迟时间（秒）
    private float delay = 2f;

    void Start()
    {
        // 在游戏开始后的一分钟（60秒）调用TriggerVFX方法
        Invoke("TriggerVFX", delay);
    }

    void TriggerVFX()
    {
        // 遍历所有VFX Prefabs并实例化它们
        foreach (GameObject vfxPrefab in vfxPrefabs)
        {
            if (vfxPrefab != null)
            {
                // 实例化VFX Prefab，在当前游戏对象的位置
                Instantiate(vfxPrefab, transform.position, Quaternion.identity);
            }
        }
    }
}
