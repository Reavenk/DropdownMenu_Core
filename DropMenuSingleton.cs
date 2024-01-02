// MIT License
// 
// Copyright (c) 2021 Pixel Precision, LLC
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using UnityEngine;

namespace PxPre.DropMenu
{
    /// <summary>
    /// Singleton to declare a single DropMenu used by the entire application.
    /// </summary>
    [RequireComponent(typeof(DropMenuSpawner))]
    public class DropMenuSingleton : MonoBehaviour
    {
        /// <summary>
        /// The singleton instance.
        /// </summary>
        static DropMenuSingleton instance;

        /// <summary>
        /// Public accessor to the singleton instance.
        /// </summary>
        public static DropMenuSingleton Instance {get{return instance; } }

        /// <summary>
        /// The singleton menu.
        /// </summary>
        public static DropMenuSpawner MenuInst
        { get{return Instance.CachedMenu; } }

        /// <summary>
        /// Cached singleton menu.
        /// </summary>
        private DropMenuSpawner menu;

        /// <summary>
        /// Public accessor to the cached singleton menu.
        /// </summary>
        public DropMenuSpawner CachedMenu { get{return this.menu; } }

        private void Awake()
        {
            instance = this;
            this.menu = this.GetComponent<DropMenuSpawner>();
        }

        /// <summary>
        /// If a menu is created with this class's Create*(), it's tracked as the singleton
        /// menu, which there should only ever be 1 active instance of at any time.
        /// </summary>
        private static SpawnContext spawnContext = null;

        public static SpawnContext CreateDropdownMenu(Canvas canvas, Node rootNode, RectTransform rtInvokingRect, StyleOverride overrideFlags = 0)
        { 
            var menu = MenuInst.CreateDropdownMenu(canvas, rootNode, rtInvokingRect, overrideFlags);
            SetupSingletonMenu(menu);
            return menu;
        }

        public static SpawnContext CreateDropdownMenu(Canvas canvas, Node rootNode, Vector3 loc, StyleOverride overrideFlags = 0)
        { 
            var menu = MenuInst.CreateDropdownMenu(canvas, rootNode, loc, overrideFlags);
            SetupSingletonMenu(menu);
            return menu;
        }

        public static bool DestroySingletonMenu()
        { 
            if(spawnContext == null)
                return false;

            spawnContext.Destroy();
            Debug.Assert(spawnContext == null);
            return true;
        }

        public static void SetupSingletonMenu(SpawnContext ctx)
        { 
            if(spawnContext != null)
            { 
                spawnContext.Destroy();
                Debug.Assert(spawnContext == null);
            }

            spawnContext = ctx;
            ctx.onMenuSessionEnded += () => {  spawnContext = null; };
        }
    }
}