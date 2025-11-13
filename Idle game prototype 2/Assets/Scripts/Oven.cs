using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class Oven : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public Button bakeButton;
    public Button collectButton;
    public GameObject floatingTextPrefab;  // assign prefab in Inspector
    public Transform popupParent;          // where the text should spawn (usually your Canvas)

    private float bakeTime = 5f;
    private float timer;
    private bool isBaking = false;
    private bool breadReady = false;

    private void Start()
    {
        bakeButton.onClick.AddListener(StartBaking);
        collectButton.onClick.AddListener(CollectBread);
        collectButton.interactable = false;
    }

    private void Update()
    {
        if (isBaking)
        {
            timer -= Time.deltaTime;
            timerText.text = "Time Left: " + Mathf.Ceil(timer).ToString() + "s";

            if (timer <= 0)
            {
                isBaking = false;
                breadReady = true;
                collectButton.interactable = true;
                timerText.text = "Bread Ready!";
            }
        }
    }

    private void StartBaking()
    {
        if (!isBaking && !breadReady && GameManager.Instance.UseDough(1))
        {
            timer = bakeTime;
            isBaking = true;
            timerText.text = "Time Left: " + bakeTime + "s";
        }
    }
    private void CollectBread()
    {
        if (breadReady)
        {
            breadReady = false;
            collectButton.interactable = false;

            int breadCollected = 1; // later replace with upgrade system
            GameManager.Instance.AddBread(breadCollected);
            timerText.text = "Idle";

            // Show floating popup
            if (floatingTextPrefab != null && popupParent != null)
            {
                GameObject popup = Instantiate(floatingTextPrefab, popupParent);
                popup.transform.position = collectButton.transform.position; // spawn near button
                popup.GetComponent<FloatingText>().Setup("+" + breadCollected.ToString());
            }
        }
    }
}


