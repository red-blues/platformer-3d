using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SettingsButton : MonoBehaviour
{
  [SerializeField] private GameObject mainPanel;
  [SerializeField] private GameObject settingsPanel;
  private Button _btn;

  private void Awake()
  {
    _btn = GetComponent<Button>();
    _btn.onClick.AddListener(GoToSettings);
  }

  private void GoToSettings()
  {
    AudioManager.instance.PlayUISfx();
    mainPanel.SetActive(false);
    settingsPanel.SetActive(true);
  }
}
