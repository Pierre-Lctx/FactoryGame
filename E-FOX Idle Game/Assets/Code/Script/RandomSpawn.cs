using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    [SerializeField] private List<ScriptableRessources> _listSR;
    public GameObject ObjectPrefab;

    public Vector3 center;
    public Vector3 size;

    public float cooldownTime = 2;
    private float nextSpawnTime = 0;

    public PickUp pickUpFile;

    // Start is called before the first frame update
    void Start()
    {
        SpawnObject();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + cooldownTime;
            SpawnObject();
        }

        
    }

    public void SpawnObject()
    {
        int randObj = Random.Range(0, _listSR.Count-1);
        ScriptableRessources srTemp = _listSR[randObj];
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));

        GameObject go = Instantiate(srTemp.gameObject, pos, Quaternion.identity);
        go.AddComponent<DataObject>().SetScriptableRessources(srTemp);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1,0,0,0.5f);
        Gizmos.DrawCube(center, size);
    }
}
