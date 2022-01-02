using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotKeyAbility: MonoBehaviour
{
    public PassiveAbility passiveAbility;
    public List<Ability> abilityHolder = new List<Ability>();

    private void Awake()
    {
        for (int i = 0; i < abilityHolder.Count; i++)
        {
            abilityHolder[i].SetUpPlayerRefference(gameObject);
        }
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Q))
      //  {
       //     abilityHolder[0].ExecuteAbility();
       // }
    }

    public void IntegrateAbility(Ability ability)
    {
        ability.SetUpPlayerRefference(gameObject);
        abilityHolder.Add(ability);

    }

}
