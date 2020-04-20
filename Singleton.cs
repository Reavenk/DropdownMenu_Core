using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PxPre
{
    namespace DropMenu
    {
        [RequireComponent(typeof(Spawner))]
        public class Singleton : MonoBehaviour
        {
            static Singleton instance;
            public static Singleton Instance {get{return instance; } }

            public static Spawner MenuInst
            { get{return Instance.CachedMenu; } }

            private Spawner menu;
            public Spawner CachedMenu { get{return this.menu; } }

            private void Awake()
            {
                instance = this;
                this.menu = this.GetComponent<Spawner>();
            }
        }
    }
}