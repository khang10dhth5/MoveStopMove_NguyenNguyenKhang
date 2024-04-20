using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSight : MonoBehaviour
{
    [SerializeField] private Character character;
    [SerializeField] private Transform TF;
    private void OnTriggerEnter(Collider other)
    { 
        if(other.CompareTag(KeyConstant.TAG_CHACRACTER))
        {
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
        if (other.CompareTag(KeyConstant.TAG_CHACRACTER))
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
    private void LateUpdate()
    {
       TF.rotation =Quaternion.Euler( Vector3.zero);
    }
}
