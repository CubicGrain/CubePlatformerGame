using System.Timers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class EZCollectAndRespawn : MonoBehaviour
{
    public GameObject targetObject;
    public UnityEvent OnCollision;
    public UnityEvent OnRespawn;
    public float respawnTimer = 1;
    float timer;
    bool timerActive = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == targetObject && !timerActive)
        {
            OnCollision.Invoke();
            timer = respawnTimer;
            timerActive = true;
        }
    }
    void Update()
    {
        if(timerActive && timer >= 0)
        {
            timer -= Time.deltaTime;
        }
        if(timer <= 0)
        {
            timerActive = false;
            Respawn();
        }
    }

    void Respawn()
    {
        OnRespawn.Invoke();
    }


}
