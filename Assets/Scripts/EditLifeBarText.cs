using UnityEngine;
using UnityEngine.UI;

public class EditLifeBarText : MonoBehaviour
{
    public PlayerHealth playerHealth;

    Text lifeText;
    private int Health;

    void Start()
    {
        Health = 100;
        lifeText = gameObject.GetComponent<Text>();
        lifeText.text = Health.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Health = playerHealth.currentHealth;
        lifeText = gameObject.GetComponent<Text>();
        lifeText.text = Health.ToString();
    }
}
