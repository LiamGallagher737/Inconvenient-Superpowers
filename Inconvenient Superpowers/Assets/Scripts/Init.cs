using UnityEngine; using System.Collections;
public class Init : MonoBehaviour {
    [SerializeField] private CameraController cam;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Vector3 playerSpawnPos = new Vector3(-3f, -1.45f, 0);
    [SerializeField] private UnityEngine.UI.Text scoreText;
    [SerializeField] private UnityEngine.UI.Text highscoreText;
    [SerializeField] private SuperpowerManager superpowerManager;
    private void Awake() {
        var player = Instantiate(playerPrefab, playerSpawnPos, Quaternion.identity);
        cam.player = player.transform;
        player.GetComponent<PlayerController>().scoreText = scoreText;
        superpowerManager.player = player.GetComponent<PlayerController>();
        
        if (PlayerPrefs.HasKey("Highscore")) {
            highscoreText.text = PlayerPrefs.GetFloat("Highscore").ToString("F1");
        }
    }
}
