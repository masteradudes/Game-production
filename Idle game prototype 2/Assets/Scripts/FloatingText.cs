using TMPro;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public float floatSpeed = 50f;     // Speed upwards
    public float fadeDuration = 1f;    // Time before disappearing
    private TextMeshProUGUI textMesh;
    private Color originalColor;

    private void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        originalColor = textMesh.color;
    }

    public void Setup(string message)
    {
        textMesh.text = message;
        textMesh.color = originalColor; // reset in case reused
        Destroy(gameObject, fadeDuration);
    }

    private void Update()
    {
        // Move upwards
        transform.Translate(Vector3.up * floatSpeed * Time.deltaTime);

        // Fade out
        Color c = textMesh.color;
        c.a -= Time.deltaTime / fadeDuration;
        textMesh.color = c;
    }
}
