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

namespace PxPre
{
    namespace DropMenu
    {
        /// <summary>
        /// The class in charge of creating dropdown menus.
        /// </summary>
        public class DropMenuSpawner : MonoBehaviour
        {
            /// <summary>
            /// The assets and layout properties used to create the visual
            /// style of the drop menus.
            /// </summary>
            public Props props;

            /// <summary>
            /// A callback to listen to dropdown menu creations.
            /// </summary>
            public System.Action<Node> onAction;

            /// <summary>
            /// A callback for when the background modal plate is created.
            /// </summary>
            public System.Action<UnityEngine.UI.Image> onCreatedModalPlate;

            /// <summary>
            /// A callback to listen to when a submenu is opened.
            /// </summary>
            public System.Action<SpawnContext, SpawnContext.NodeContext> onSubMenuOpened;

            // TODO: Remove
            public RectTransform CreateMenu(Canvas canvas, Vector2 pos)
            { 
                return null;
            }

            /// <summary>
            /// Create a dropdown around a RectTransform - mimicing if the RectTransform was a 
            /// pulldown menu.
            /// </summary>
            /// <param name="canvas">The UI Canvas to create the menu in.</param>
            /// <param name="rootNode">The root node of the menu to spawn.</param>
            /// <param name="rtInvokingRect">The RectTransform to create the menu around.</param>
            /// <returns>The context information of the created menu.</returns>
            public SpawnContext CreateDropdownMenu(Canvas canvas, Node rootNode, RectTransform rtInvokingRect)
            {
                SpawnContext sc = new SpawnContext(canvas, this);
                sc.CreateDropdownMenu(rootNode, rtInvokingRect);
                return sc;
            }

            /// <summary>
            /// Create a dropdown menu at a specific position.
            /// </summary>
            /// <param name="canvas">The UI Canvas to create the menu in.</param>
            /// <param name="rootNode">The root node of the menu to spawn.</param>
            /// <param name="loc">The UI location to spawn the menu.</param>
            /// <returns>The context information of the created menu.</returns>
            private SpawnContext CreateDropdownMenu(Canvas canvas, Node rootNode, Vector3 loc)
            { 
                SpawnContext sc = new SpawnContext(canvas, this);
                sc.CreateDropdownMenu(rootNode, false, loc);
                return sc;
            }
        }
    }
}