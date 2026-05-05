using UnityEngine;
using UnityEngine.Events;

public class EZTrigger : MonoBehaviour
{

    public UnityEvent OnOverlap;
    public UnityEvent OnEndOverlap;
    public bool CheckCollider = false;
    public GameObject targetGameObject;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (CheckCollider)
        {
            if (other.gameObject == targetGameObject)
            {
                OnOverlap.Invoke();
            }

        } else
        {
            OnOverlap.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (CheckCollider)
        {
            if (other.gameObject == targetGameObject)
            {
                OnEndOverlap.Invoke();
            }

        }
        else
        {
            OnEndOverlap.Invoke();
        }
    }









}
