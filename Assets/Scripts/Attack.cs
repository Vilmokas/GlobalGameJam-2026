using System.Collections;
using UnityEngine;
using static Masks;

public class Attack : MonoBehaviour
{
    [SerializeField]
    GameObject[] attacks;
    [SerializeField]
    float[] attackCooldowns;
    [SerializeField]
    bool canAttack = true;

    public void UseAttack(TYPES type)
    {
        if (canAttack)
        {
            canAttack = false;
            StartCoroutine(StartAttack(attacks[(int)type], attackCooldowns[(int)type]));
        }
    }

    IEnumerator StartAttack(GameObject attack, float cooldown)
    {
        attack.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        attack.SetActive(false);
        yield return new WaitForSeconds(cooldown - 0.1f);
        canAttack = true;
    }
}
