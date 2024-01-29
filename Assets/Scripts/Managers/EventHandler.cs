using UnityEngine;
using UnityEngine.Events;

public class EventHandler
{ 
    public static UnityEvent<float> OnScaling = new();
    public static UnityEvent<GameObject> OnDisapperance = new();
    public static UnityEvent<Transform> OnLastCheckpoint = new();
    public static UnityEvent OnIncluded = new();
}