using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHp = 100;
    [SerializeField] private Slider hpSlider;
    [SerializeField] private AudioClip hurtSound;
    private float _currHp;

    private void Awake()
    {
        _currHp = maxHp;
        DrawHp();
    }

    public void GetDamage(float damage)
    {
        _currHp -= damage;
        DrawHp();
        TryDie();
        AudioManager.instance.PlayPlayerSfx(hurtSound);
    }

    private void TryDie()
    {
        if (_currHp <= 0)
        {
            if (gameObject.CompareTag("Player"))
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            else 
                gameObject.SetActive(false);
        }
    }
    
    private void DrawHp() => 
        hpSlider.value = _currHp / maxHp;
}
