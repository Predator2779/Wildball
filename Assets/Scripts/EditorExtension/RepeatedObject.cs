using UnityEngine;
using EditorExtension;

[ExecuteAlways]
[SelectionBase]
public class RepeatedObject : MonoBehaviour
{
#if UNITY_EDITOR

    public EditManager EditManager;
    public GameObject SpawnObject;

    [Min(1)] public int Rows = 1;
    [Min(1)] public int Columns = 1;

    private void Start()
    {
        if (Application.IsPlaying(this))
        {
            Destroy(this);
        }
    }

    [EditorButton("Instantiate Objs")]
    public void InstantiateObs()
    {
        if (EditManager.EDIT_MODE)
        {
            RemoveAllChildren();

            CreateGridObjs();
        }
    }

    private void CreateGridObjs()
    {
        Vector3 position;

        for (int z = 0; z < Columns; z++)
        {
            for (int x = 0; x < Rows; x++)
            {
                position = new Vector3(x * SpawnObject.transform.localScale.x, 0, z * -SpawnObject.transform.localScale.z);

                CreateObj(SpawnObject, position);
            }
        }
    }

    private GameObject CreateObj(GameObject obj, Vector3 position)
    {
        GameObject clone = Instantiate(obj, position, obj.transform.rotation, transform);

        return clone;
    }

    private void RemoveAllChildren()
    {
        GameObject[] allChildren = new GameObject[transform.childCount];

        int i = 0;

        foreach (Transform child in transform)
        {
            allChildren[i] = child.gameObject;
            i++;
        }

        foreach (var child in allChildren)
        {
            DestroyImmediate(child.gameObject);
        }
    }

#endif
}