using UnityEngine;

public class Script_Geral_PosSeguir : MonoBehaviour
{
    public Transform t_posAlvo;

    void Update()
    {
        if (t_posAlvo == null) return;
        transform.position = t_posAlvo.position;
    }
}