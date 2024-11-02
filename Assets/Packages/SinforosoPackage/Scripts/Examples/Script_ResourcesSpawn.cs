using UnityEngine;

public class Script_ResourcesSpawn : MonoBehaviour
{
    public static void Resource(Vector3 _pos)
    {
        GameObject _prefab = Resources.Load<GameObject>("prefab");
        GameObject _obj = Instantiate(_prefab, _pos, Quaternion.identity);
    }
}