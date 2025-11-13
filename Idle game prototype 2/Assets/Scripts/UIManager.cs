using TMPro;  // Add this at the top
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI doughText;
    public TextMeshProUGUI breadText;

    private void Update()
    {
        doughText.text = "Dough: " + GameManager.Instance.dough;
        breadText.text = "Bread: " + GameManager.Instance.bread;
    }

    public void AddDoughButton()
    {
        GameManager.Instance.AddDough(1);
    }
}
