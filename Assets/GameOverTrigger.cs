using UnityEngine;

public class GameOverTrigger : MonoBehaviour
{
    public GameObject gameOverScreen; // 在Inspector中设置，指向游戏结束画面的GameObject

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 确保是玩家触发了事件
        {
            gameOverScreen.SetActive(true); // 激活游戏结束画面
        }
    }
}
