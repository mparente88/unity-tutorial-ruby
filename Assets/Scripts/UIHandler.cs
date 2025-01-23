using UnityEngine;
using UnityEngine.UIElements;

public class UIHandler1 : MonoBehaviour
{
    public float CurrentHealth = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();
        VisualElement healthBar = uiDocument.rootVisualElement.Q<VisualElement>("HealthBar");
        healthBar.style.width = Length.Percent(CurrentHealth * 100.0f);
    }
}
