using AdvancedPeopleSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderCameraStore : MonoBehaviour
{
    public Transform original;
    public Transform FaceZoom;
    public Transform shirt;
    public Transform pants;
    public Transform shoes;


    private Transform target;

    public void SetTarget(CharacterElementType element)
    {
        switch (element)
        {
            case CharacterElementType.Hat:
                SetTarget(FaceZoom);
                break;
            case CharacterElementType.Shirt:
                SetTarget(shirt);
                break;
            case CharacterElementType.Pants:
                SetTarget(pants);
                break;
            case CharacterElementType.Shoes:
                SetTarget(shoes);
                break;
            case CharacterElementType.Accessory:
                SetTarget(FaceZoom);
                break;
            case CharacterElementType.Hair:
                SetTarget(FaceZoom);
                break;
            case CharacterElementType.Beard:
                SetTarget(FaceZoom);
                break;
            case CharacterElementType.Item1:
                SetTarget(FaceZoom);
                break;
            default:
                break;
        }
    }

    public void ResetTarget()
    {
        target = null;
        LeanTween.move(gameObject, original.position, 0.3f).setEaseLinear();
        LeanTween.rotate(gameObject, original.rotation.eulerAngles, 0.3f).setEaseLinear();
    }

    private void SetTarget(Transform target)
    {
       this.target = target;
       LeanTween.move(gameObject, target.position, 0.3f).setEaseLinear();
       LeanTween.rotate(gameObject, target.rotation.eulerAngles, 0.3f).setEaseLinear();
    }

}
