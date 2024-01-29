using UnityEngine;
using EditorExtension;

public class SpawnRoom : MonoBehaviour
{
#if UNITY_EDITOR
    [SerializeField] private EditManager _editManager;

    [SerializeField] private GameObject[] _rooms = new GameObject[5];

    [SerializeField] [Range(0, 5)] private int _typeRoom;
    [SerializeField] [Range(0, 3)] private int _angleRoom;

    [SerializeField] private GameObject _cloneRoom;

    private void Update()
    {
        
    }

    [EditorButton("SetRooms")]
    public void SelectRoom()
    {
        if (_editManager == null)
        {
            _editManager = GameObject.Find("EditManager").GetComponent<EditManager>();
        }

        if (_editManager.EDIT_MODE)
        {
            SetRoom(_typeRoom);
        }
    }

    private void SetRoom(int typeroom)
    {
        if (typeroom != 0)
        {
            if (_rooms[typeroom - 1] != null)
            {
                Set(_rooms[typeroom - 1]);

                RotateRoom(_angleRoom);
            }
        }
        else
        {
            DisableRoom();
        }
    }

    private void Set(GameObject concreteRoom)
    {
        if (_cloneRoom != null)
        {
            DestroyImmediate(_cloneRoom);
        }
        else
        {
            transform.GetComponent<MeshRenderer>().enabled = false;
        }

        _cloneRoom = new SpawnObj().Spawn(concreteRoom, transform, transform);
    }

    private void RotateRoom(float angle)
    {
        if (_cloneRoom != null)
        {
            _cloneRoom.transform.eulerAngles = new Vector3(0, 90.0f * angle, 0);
        }
    }

    private void DisableRoom()
    {
        if (_cloneRoom != null)
        {
            DestroyImmediate(_cloneRoom);

            transform.GetComponent<MeshRenderer>().enabled = true;
        }
    }
#endif
}
