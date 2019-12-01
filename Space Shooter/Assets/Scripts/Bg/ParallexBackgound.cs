using UnityEngine;

public class ParallexBackgound : MonoBehaviour
{
    public float parallex;

    // Update is called once per frame
    void Update()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();

        Material mat = mr.material;

        Vector2 offset = mat.mainTextureOffset;

        offset.x = transform.position.x / parallex;
        offset.y = transform.position.y / parallex;

        mat.mainTextureOffset = offset;
    }
}
