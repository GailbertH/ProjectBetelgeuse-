using System;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectBetelgeuse.Database
{
    [Serializable]
    [CreateAssetMenu(fileName = "New Item", menuName = "Assets/Database_Item/Item")]
    public class DatabaseItem : ScriptableObject
    {
        public string id;
        public new string name;
        [TextArea]
        public string description;
        public Sprite icon;
    }
}
