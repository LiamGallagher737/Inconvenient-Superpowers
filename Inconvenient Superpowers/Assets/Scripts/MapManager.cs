using UnityEngine; using System.Collections.Generic;
public class MapManager : MonoBehaviour {

    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private Vector2 mapSize;
    [SerializeField] private Transform cam;
    [SerializeField] private float platformDensity = 3f;

    private int platformCount;
    private List<GameObject> platforms = new List<GameObject>();
    
    private void Update() {
        if (!(cam.position.y > platformCount * platformDensity)) return;
        AddNewPlatform();
        platformCount++;
    }

    private void AddNewPlatform() {
        var pos = new Vector3(Random.Range(0, mapSize.x) - (mapSize.x / 2), cam.position.y + (mapSize.y*.8f), 0);
        var platform = Instantiate(platformPrefab, pos, Quaternion.identity);
        platforms.Add(platform);
        platform.layer = 3;
            
        ClearUnusedPlatforms();
    }

    private void ClearUnusedPlatforms() {
        for (var i = 0; i < platforms.Count; i++) {
            if (!(platforms[i].transform.position.y < cam.position.y - (mapSize.y * .8f))) continue;
            Destroy(platforms[i]);
            platforms.Remove(platforms[i]);
        }
    }
}
