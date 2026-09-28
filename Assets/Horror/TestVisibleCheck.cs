using UnityEngine;

public class TestVisibleCheck : MonoBehaviour
{
    CheckWithinView viewCheck;
    MeshRenderer meshRenderer;

    public float speed = 7f;
    public Transform player;
    public Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        viewCheck = GetComponent<CheckWithinView>();
        meshRenderer = GetComponent<MeshRenderer>();

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(viewCheck.IsVisibleToCamera()) {
            meshRenderer.sharedMaterial.color = Color.white;
        }
        else {
            meshRenderer.sharedMaterial.color = Color.red;

            if (player != null)
            {
                Vector3 direction = player.position - transform.position;
                direction.y = 0f;

                direction = direction.normalized;

                rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);

                transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
            }
        }
    }
}
