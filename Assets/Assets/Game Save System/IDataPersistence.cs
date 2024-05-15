using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDataPersistence 
{
    void LoadData(GameData data);

    // must pass by reference in order to allow for modifying data by DPM script
    void SaveData(ref GameData data);
}
