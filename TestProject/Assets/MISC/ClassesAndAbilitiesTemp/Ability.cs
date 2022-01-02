using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability")]
public class Ability : ScriptableObject
{
    public string AbilityName;
    public Sprite AbilityThumbnail;
    protected GameObject player;

    public virtual void SetUpPlayerRefference(GameObject player)
    {
        this.player = player;
    }
    public virtual void ExecuteAbility()
    {
      
    }
}
