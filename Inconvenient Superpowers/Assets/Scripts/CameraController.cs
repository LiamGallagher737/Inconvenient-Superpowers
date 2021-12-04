using UnityEngine;
public class CameraController : MonoBehaviour {
    [HideInInspector] public Transform player;
    [SerializeField] private Camera cam;
    
    [SerializeField] private float dampTime = 0.15f;
    private Vector3 velocity = Vector3.zero;
    
    private void LateUpdate() {
        var destination = transform.position + new Vector3(0, player.position.y, player.position.z) - cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, cam.WorldToViewportPoint(player.position).z));
        transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
    }
}
