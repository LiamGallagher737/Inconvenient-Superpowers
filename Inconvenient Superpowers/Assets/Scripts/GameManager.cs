using UnityEngine; using System.Collections; using UnityEngine.SceneManagement;
public static class GameManager {
    public static bool GameOver = false;
    
    public static void PlayerDied() {
        GameOver = true;
        if (!PlayerPrefs.HasKey("Highscore") || PlayerPrefs.GetFloat("Highscore") < PlayerController.highestScore+1.45f) {
            PlayerPrefs.SetFloat("Highscore", PlayerController.highestScore+1.45f);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameOver = false;
    }
}
