using System;
using UnityEngine; using System.Collections;
public class Init : MonoBehaviour {
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Vector3 playerSpawnPos = new Vector3(-3f, -1.45f, 0);
    private void Start() {
        GameManager.Init();

        Instantiate(playerPrefab, playerSpawnPos, Quaternion.identity);
    }
}
