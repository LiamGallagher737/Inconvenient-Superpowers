using UnityEngine;
public class MapManager : MonoBehaviour {

    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private Vector2 mapSize;
    [SerializeField] private int platformDensity = 5;

    public void Start() {
        for (var i = 0; i < platformDensity; i++) {
            AddNewPlatform();
        }
    }

    private void AddNewPlatform() {
        var pos = new Vector3(Random.Range(0, mapSize.x)- (mapSize.x / 2), Random.Range(0, mapSize.y)- (mapSize.y / 2), 0);
        Instantiate(platformPrefab, pos, Quaternion.identity);
    }
}
