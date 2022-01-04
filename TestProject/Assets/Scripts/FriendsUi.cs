using UnityEngine;
using UnityEngine.UI;
using System;
using Photon.Realtime;
using TMPro;
public class FriendsUi : MonoBehaviour
{
    [SerializeField] private string displayName;
    private TMP_Text friendNameText;
    private FriendInfo friend;
    public static Action<string> OnRemoveFriend = delegate { };


    private bool active = false;
    private Button friendsButton;

    private Vector3 originalPosition;
    public float popUpDistance = 25;

    private void Awake()
    {
        friendsButton = GetComponent<Button>();

        friendsButton.onClick.AddListener(() =>
        {
            ToggleFriendsUi();
        });

        originalPosition = friendsButton.transform.position;
        Debug.Log(originalPosition.y);
    }

    public void Initialize(FriendInfo friend)
    {
        this.friend = friend;
        friendNameText.SetText(this.friend.UserId);
        
    }

    public void SetAddFriendName(string name)
    {
        displayName = name;
    }
    public void AddFriend()
    {
        //if (string.IsNullOrEmpty(displayName)) return;
       // OnAddFriend?.Invoke(displayName);
    }

    public void RemoveFriend()
    {
        OnRemoveFriend?.Invoke(friend.UserId);
        
    }

    private void ToggleFriendsUi()
    {
        if (!active)
        {
            active = true;
            
           LeanTween.moveLocalY(friendsButton.gameObject, friendsButton.transform.localPosition.y + popUpDistance, 0.3f).setEaseLinear();
        }
        else
        {
            active = false;
            LeanTween.moveLocalY(friendsButton.gameObject, friendsButton.transform.localPosition.y - popUpDistance, 0.3f).setEaseLinear();

        }
    }



}
