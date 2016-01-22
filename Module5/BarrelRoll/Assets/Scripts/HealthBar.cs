using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private GameObject block;
    private GameObject healthBar;
    private Image currentHealthImage;
    private Text healthText;
    private DurabilityManager durability;
    private float maxPercent = 100;

    public void Start()
    {
        block = GameObject.Find("Block");
        durability = block.GetComponent<DurabilityManager>();
        healthBar = transform.FindChild("HealthBar").gameObject;
        currentHealthImage = healthBar.transform.FindChild("CurrentHealth").GetComponent<Image>();
        healthText = healthBar.transform.FindChild("Text").GetComponent<Text>();
    }

    public void Update()
    {
        if (durability.durability < 0)
        {
            durability.durability = 0;
        }

        var currentHealthPercent = durability.durability / maxPercent;
        currentHealthImage.fillAmount = currentHealthPercent;
        healthText.text = currentHealthPercent * 100 + "%";
    }
}
