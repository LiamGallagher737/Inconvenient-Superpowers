using UnityEngine; using UnityEngine.UI; using System.Collections.Generic;
public class SuperpowerManager : MonoBehaviour {
    [SerializeField] private Text countdownText;
    [SerializeField] private AudioClip newPowerSFX;
    [SerializeField] private AudioSource audioSource;
    public PlayerController player;
    private int countdown = 10;
    private void Start() {
        InvokeRepeating(nameof(DecreaseCountdown), 1, 1);
    }
    private void DecreaseCountdown() {
        if (GameManager.GameOver) {
            CancelInvoke(nameof(DecreaseCountdown));
            return;
        }
        
        countdown--;
        if (countdown == 0) {
            countdown = 10;
            NewPower();
        }

        countdownText.text = countdown.ToString()+'s';
    }
    
    private const float defaultSpeed = 15f;
    private const float defaultJumpForce = 13f;

    private void NewPower() {
        switch (Random.Range(0,9)) {
            case 0:
                player.movementSpeed = 50f;
                player.jumpForce = defaultJumpForce;
                break;
            case 1:
                player.movementSpeed = defaultSpeed;
                player.jumpForce = 9f;
                break;
            case 2:
                player.movementSpeed = 50f;
                player.jumpForce = 9f;
                break;
            case 3:
                player.movementSpeed = 100f;
                player.jumpForce = defaultJumpForce;
                break;
            case 5:
                player.movementSpeed = defaultSpeed;
                player.jumpForce = 25f;
                break;
            case 6:
                (player.movementSpeed, player.jumpForce) = (player.jumpForce, player.movementSpeed);
                break;
            case 7:
                player.movementSpeed = 250f;
                player.jumpForce = defaultJumpForce;
                break;
            case 8:
                player.movementSpeed = defaultSpeed;
                player.jumpForce = defaultJumpForce;
                break;
        }
        audioSource.PlayOneShot(newPowerSFX);
    }
}
