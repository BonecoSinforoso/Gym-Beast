using UnityEngine;

public class Script_Geral_MaterialRandomizar : MonoBehaviour
{
    [SerializeField] Renderer rend;
    [SerializeField] Material[] mat;

    void Start()
    {
        rend.material = mat[Random.Range(0, mat.Length)];
    }
}