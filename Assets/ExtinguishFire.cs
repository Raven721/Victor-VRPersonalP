using System.Diagnostics;
using UnityEngine;

public class ExtinguishFire : MonoBehaviour
{
    ParticleSystem fireParticleSystem;

    void Start()
    {
        // 假设火焰粒子系统已经附加在名为"Fire"的GameObject上
        fireParticleSystem = GameObject.Find("Fire").GetComponent<ParticleSystem>();
    }

    void OnParticleCollision(GameObject other)
    {
        UnityEngine.Debug.Log("Collision with: " + other.gameObject.name);
        if (other.gameObject.name == "Bin_Square_White")
        {
            // 当粒子碰撞到名为"Bin"的GameObject时，禁用该GameObject
            other.gameObject.SetActive(false);
            UnityEngine.Debug.Log("Bin object deactivated!");
        }
    }
}