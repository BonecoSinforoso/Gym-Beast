using TMPro;
using UnityEngine;

public class Script_ProductName : MonoBehaviour
{
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = Application.productName;
    }
}