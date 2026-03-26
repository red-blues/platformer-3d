using UnityEngine;

public class Bouncer : MonoBehaviour
{
  [SerializeField] private float multiplier = 1.0f;
  [SerializeField] private float cooldownSeconds = 0.05f;
  [SerializeField] private AudioClip sound;

  private float _cooldown;

  private void Update()
  {
    if (_cooldown > 0f) 
      _cooldown -= Time.deltaTime;
  }

  private void OnCollisionEnter(Collision collision)
  {
    if (_cooldown <= 0)
    {
      if (collision.gameObject.TryGetComponent(out PlayerController player))
      {
        Vector3 vRel = collision.relativeVelocity;
        vRel.y = 0f;
        Vector3 deltaV = (-2f * vRel) * multiplier;
        player.AddKnockbackDeltaV(deltaV);
        _cooldown = cooldownSeconds;
        AudioManager.instance.PlayLevelSfx(sound);
      }
    }
  }
}