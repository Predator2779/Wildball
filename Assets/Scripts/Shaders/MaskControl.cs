using UnityEngine;

public class MaskControl : MonoBehaviour
{
    public Transform player, mask; // трансформ маски и игрока
    public float maskSize = 4;
    public float maskFade = 10;
    public LayerMask playerMask; // слои, которые нужно игнорировать (например, слой игрока)
    private Vector3 maskScale, maskDir;
    private MaterialControl wall;

    void Start()
    {
        maskScale = new Vector3(maskSize, maskSize, maskSize);
        mask.localScale = Vector3.zero;
    }

    void Update()
    {
        RaycastHit raycastHit;

        if (Physics.Linecast(Camera.main.transform.position, player.position, out raycastHit, ~playerMask))
        {
            maskDir = raycastHit.point - player.position;

            if (wall == null)
            {
                wall = raycastHit.collider.GetComponent<MaterialControl>();
                wall.SetMask(true);
            }

            mask.localScale = Vector3.MoveTowards(mask.localScale, maskScale, maskFade * Time.deltaTime);
        }
        else
        {
            mask.localScale = Vector3.MoveTowards(mask.localScale, Vector3.zero, maskFade * Time.deltaTime);

            if (mask.localScale.x == 0)
            {
                if (wall != null)
                {
                    wall.SetMask(false);
                    wall = null;
                }
            }
        }

        mask.position = player.position + maskDir;
    }
}