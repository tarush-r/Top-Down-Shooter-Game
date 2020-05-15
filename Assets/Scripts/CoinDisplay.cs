using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinDisplay : MonoBehaviour
{

    public Text coinCount;
    
    void Update()
    {
        coinCount.text="x"+PlayerStats.getCoins();
    }
}
