using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;

        public GameObject hitUI;

       public GameObject deathUI;

        public TextMeshProUGUI ammoText;

        public Image healthBar;
        public Gradient healthGradient;

    private void Awake()
        {
            Instance = this;
        }

        public void InstantiateHitUI()
        {
            Instantiate(hitUI, transform);
        }
    public void RestartGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void EnableDeathUI()
    {
        deathUI.SetActive(true);
    }

    public void SetHealthValue(int health)
    {
        float floatHealth = (float)health / 100;
        healthBar.color = healthGradient.Evaluate(floatHealth);
        healthBar.fillAmount = floatHealth;
    }
}
