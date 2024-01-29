using UnityEngine;

public class SpawnObj : MonoBehaviour
{
    public GameObject Spawn(GameObject obj, Transform position, Transform parent)
    {
        return Instantiate
            (
            obj, 
            position.transform.position, 
            position.transform.rotation,
            parent.transform.parent
            );
    }
}
