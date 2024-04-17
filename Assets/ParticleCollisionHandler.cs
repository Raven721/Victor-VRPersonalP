using UnityEngine;

public class ParticleCollisionHandler : MonoBehaviour
{
    void OnParticleCollision(GameObject other)
    {
        // 检查被碰撞的对象是否具有“EffectToDisable”标记
        if (other.CompareTag("EffectToDisable"))
        {
            var effect = other.GetComponent<ParticleSystem>();
            if (effect != null)
            {
                effect.Stop(); // 停止该粒子系统
            }
        }
    }
}
