using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerCameraControl : MonoBehaviour
{
    
    public GameObject targetPlayer;
    public float cameraDistance;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 CamPos = new Vector3(targetPlayer.transform.position.x, targetPlayer.transform.position.y, -cameraDistance);
        transform.position = CamPos;
    }
}
