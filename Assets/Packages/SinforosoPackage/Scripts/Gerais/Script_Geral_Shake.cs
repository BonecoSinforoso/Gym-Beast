using System.Collections;
using UnityEngine;

public class Script_Geral_Shake : MonoBehaviour
{
    [SerializeField] float posX;
    [SerializeField] float posY;
    [SerializeField] float posZ;

    [SerializeField] float rotX;
    [SerializeField] float rotY;
    [SerializeField] float rotZ;

    [SerializeField] float delay;

    Vector3 posIni;
    Vector3 rotIni;

    void Start()
    {
        posIni = transform.localPosition;
        rotIni = transform.localEulerAngles;

        StartCoroutine(Rotina());
    }

    IEnumerator Rotina()
    {
        while (true)
        {
            transform.localPosition = posIni + new Vector3(Random.Range(-posX, posX), Random.Range(-posY, posY), Random.Range(-posZ, posZ));
            transform.localEulerAngles = rotIni + new Vector3(Random.Range(-rotX, rotX), Random.Range(-rotY, rotY), Random.Range(-rotZ, rotZ));

            yield return new WaitForSeconds(delay);
        }
    }
}