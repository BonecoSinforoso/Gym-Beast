using TMPro;
using UnityEngine;

public class Script_ProductVersion : MonoBehaviour
{
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = Application.version;
    }
}