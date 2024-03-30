using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSight : MonoBehaviour
{
    [SerializeField] private Character character;
    private void OnTriggerEnter(Collider other)
    { 
        if(other.CompareTag(TagName.Character.ToString()))
        {
            Debug.Log("aa");
            Character characterTarget = Cache.GetCharacter(other);
            if(!characterTarget.isDead)
            {
                character.AddTarget(characterTarget);
                character.SetNewTarget();
            }

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(TagName.Character.ToString()))
        {
            Character characterTarget = Cache.GetCharacter(other);
            character.RemoveTarget(characterTarget);
            if (character.currentTarget == characterTarget)
            {
                character.currentTarget =null;
                character.SetNewTarget();
            }

        }
    }
}
