using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manipulator : MonoBehaviour
{
    PlayerData data;

    public void LoadAndDebugVals()
    {
        data = DataManager.instance.Load();
        Debug.Log("Earning: "+data.earning);
        Debug.Log("CGPA: "+data.cgpa);
        Debug.Log("Is Married: "+data.isMarried);

        Debug.Log("Character No 1 Health: "+data.characters[0].health);
        Debug.Log("Character No 1 Kick Damage: " + data.characters[0].kickDamage);
        Debug.Log("Character No 1 Punch Damage: " + data.characters[0].punchDamage);
        Debug.Log("Character No 1 IsUnLocked: " + data.characters[0].isUnlocked);
        Debug.Log("Character No 1 UnLockPrice: " + data.characters[0].unlockPrice);

        Debug.Log("Character No 2 Health: " + data.characters[1].health);
        Debug.Log("Character No 2 Kick Damage: " + data.characters[1].kickDamage);
        Debug.Log("Character No 2 Punch Damage: " + data.characters[1].punchDamage);
        Debug.Log("Character No 2 IsUnLocked: " + data.characters[1].isUnlocked);
        Debug.Log("Character No 2 UnLockPrice: " + data.characters[1].unlockPrice);

    }

    public void Save()
    {
        data.cgpa = data.cgpa + 0.25f;
        data.characters[0].health += 10;
        data.characters[0].kickDamage += 2;
        data.characters[0].punchDamage += 3;
        data.characters[0].unlockPrice += 500;
        data.characters[0].isUnlocked = true;
        data.characters[1].health += 10;
        data.characters[1].kickDamage += 2;
        data.characters[1].punchDamage += 3;
        data.characters[1].unlockPrice += 500;
        data.characters[1].isUnlocked = true;
        DataManager.instance.Save(data);
    }
}
