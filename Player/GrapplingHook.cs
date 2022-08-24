

using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    public LayerMask ropeLayerMask;

    [SerializeField] private float distance = 20f;
    [SerializeField] private LineRenderer line;
    [SerializeField] private SpringJoint2D rope;
    [SerializeField] private GameObject grapplingGun;
    private Animator anim;
    Vector2 lookDirection;
    bool canGrapple = true;

    void Start()
    {
        rope.enabled = false;
        line.enabled = false;
        anim = GetComponentInParent<Animator>();

    }

    void Update()
    {
        line.SetPosition(0, transform.position);
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        if (Input.GetMouseButtonDown(1) && canGrapple == true)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, lookDirection, distance, ropeLayerMask);

            if (hit.collider != null)
            {
                AudioManager.audioManager.PlaySound(AudioManager.audioManager.rope);
                GetComponentInParent<PlayerController>().maxMovementSpeed *= 1.5f;
                canGrapple = false;
                SetRope(hit);
                anim.SetBool("isGrappling", true);
            }
        }
        else if (Input.GetMouseButtonUp(1) && canGrapple == false)
        {
            GetComponentInParent<PlayerController>().maxMovementSpeed = 12f;
            canGrapple = true;
            DestroyRope();
            anim.SetBool("isGrappling", false);
        }
    }

    void SetRope(RaycastHit2D hit)
    {
        rope.enabled = true;
        rope.connectedAnchor = hit.point;

        line.enabled = true;
        line.SetPosition(1, hit.point);
    }

    void DestroyRope()
    {
        rope.enabled = false;
        line.enabled = false;
    }
}

