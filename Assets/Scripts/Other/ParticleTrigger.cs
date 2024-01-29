using UnityEngine;

public class ParticleTrigger : MonoBehaviour
{
    [SerializeField] private PartTriggerType _type;
    
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
            CheckType(collider.gameObject);
    }

    private void CheckType(GameObject g)
    {
        switch (_type)
        {
            case PartTriggerType.DeadZone:
                Disapperance(g);
                break;
            case PartTriggerType.Bonus:
                Disapperance(gameObject);
                break;
        }
    }

    private void Disapperance(GameObject g)
    {
        if (g.TryGetComponent(out SpectacularDisapperance specDis))
            specDis.Disapperance();
    }
}

public enum PartTriggerType
{
    DeadZone,
    Bonus
}