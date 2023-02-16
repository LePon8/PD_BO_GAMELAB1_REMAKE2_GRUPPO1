using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelector : MonoBehaviour
{
    [SerializeField] Transform[] CharacterGraphics;
    //public int playerCharacterNumber;
    [SerializeField] PlayerGraphicChoiceSO sOPlayerCharacterChoice;

    private void Start()
    {
        EnableCharacter(sOPlayerCharacterChoice.CharacterNumber);
    }

    public void EnableCharacter(int CharacterModelNumber)
    {
        foreach (Transform character in CharacterGraphics)
        {
            character.gameObject.SetActive(false);
        }
        CharacterGraphics[CharacterModelNumber].gameObject.SetActive(true);
        sOPlayerCharacterChoice.CharacterNumber = CharacterModelNumber;
    }
}

