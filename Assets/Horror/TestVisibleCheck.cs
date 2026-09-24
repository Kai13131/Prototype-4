using UnityEngine;

public class TestVisibleCheck : MonoBehaviour
{
    CheckWithinView viewCheck;
    MeshRenderer meshRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        viewCheck = GetComponent<CheckWithinView>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(viewCheck.IsVisibleToCamera()) {
            meshRenderer.sharedMaterial.color = Color.white;
        }
        else {
            meshRenderer.sharedMaterial.color = Color.red;
        }
    }
}
