using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FireAmmo : MonoBehaviour
{
    public TextMeshProUGUI AmmoText;
    private int _fireAmount = 3;
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
        _fireAmount -= 1;
        DisplayAmmoAmount();
    }

    public void AddAmmo()
    {
        _fireAmount++;
        
    }
    

    public int GetAmmoAmount()
    {
        return _fireAmount;
    }

    private void DisplayAmmoAmount()
    {
        AmmoText.text = "Secondary Ammo: " + _fireAmount.ToString();
    }
    IEnumerator Giveammo()
    {
        while (true)
        {
        int randomSeconds = Random.Range(10, 15);
        yield return new WaitForSeconds(randomSeconds);

        {
                AddAmmo();
                 DisplayAmmoAmount();
            }
        }
      
    }}