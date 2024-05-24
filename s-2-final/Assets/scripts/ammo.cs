using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ammo : MonoBehaviour
{
    public TextMeshProUGUI AmmoText;
    private int _ammoAmount = 10;
    // Start is called before the first frame update
    void Start()
    {
        //Display ammo amount
        DisplayAmmoAmount();
        StartCoroutine(Giveammo());
    }
    void Update()
    {
        
    }

    public void RemoveAmmo()
    {
        _ammoAmount -= 1;
        DisplayAmmoAmount();
    }

    public void AddAmmo()
    {
        _ammoAmount++;
        
    }
    

    public int GetAmmoAmount()
    {
        return _ammoAmount;
    }

    private void DisplayAmmoAmount()
    {
        AmmoText.text = "Primary Ammo: " + _ammoAmount.ToString();
    }
    IEnumerator Giveammo()
    {
        while (true)
        {
        int randomSeconds = Random.Range(2, 3);
        yield return new WaitForSeconds(randomSeconds);

        {
                AddAmmo();
                 DisplayAmmoAmount();
            }
        }
      
    }}