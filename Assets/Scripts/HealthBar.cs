using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider bossHealthValue;
    public void setBossHealth(float health)
    {
        bossHealthValue.value=health;
    }
}
