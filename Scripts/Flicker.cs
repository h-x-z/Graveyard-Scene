using UnityEngine;

public class Flicker : MonoBehaviour
{
    private float time = 0f;
    private bool emit = false;
    public Material material;
    
    void Update()
    {
        if (time >= 0.1f)
        {
            emit = !emit;
            if (emit)
                material.EnableKeyword("_EMISSION");
            else
                material.DisableKeyword("_EMISSION");
            time = 0f;
        }
    
        time += Time.deltaTime;
    }
}
