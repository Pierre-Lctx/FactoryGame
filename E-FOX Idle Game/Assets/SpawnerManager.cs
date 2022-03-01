using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public static SpawnerManager Instance;

    [SerializeField] private List<ScriptableRessources> _listSR;
    [SerializeField] private Transform _posSpawn;
    [SerializeField] private Vector3 _sizeSpawn;
    [SerializeField] private float _speedSpawn;


    private float nextSpawnTime = 0;
    private bool _state;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _state = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_state) return;
        if (Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + _speedSpawn;
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        int randObj = Random.Range(0, _listSR.Count - 1);
        ScriptableRessources srTemp = _listSR[randObj];
        Vector3 pos = _posSpawn.position + new Vector3(Random.Range(-_sizeSpawn.x / 2, _sizeSpawn.x / 2), Random.Range(-_sizeSpawn.y / 2, _sizeSpawn.y / 2), Random.Range(-_sizeSpawn.z / 2, _sizeSpawn.z / 2));

        GameObject go = Instantiate(srTemp.gameObject, pos, Quaternion.identity);
        go.AddComponent<DataObject>().SetScriptableRessources(srTemp);
    }

    public void SetSpawnerState(bool value)
    {
        _state = value;
    }
}
