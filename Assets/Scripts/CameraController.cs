using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float camSpeed = 5f;
  
    void Update()
    {
        Vector3 newCamPos = new Vector3(playerPos.position.x + offset.x, playerPos.position.y + offset.y,offset.z);
        transform.position = Vector3.Lerp(transform.position, newCamPos, camSpeed * Time.deltaTime);
    }
}
