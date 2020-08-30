using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectBetelgeuse.Database
{
    public class DatabaseContainer : ScriptableObject
    {
        public string id;
    }

    [CreateAssetMenu(fileName = "New Consumable Container", menuName = "Assets/Database_Container/Item")]
    public class DatabaseConsumable : DatabaseContainer
    {
    }
}
