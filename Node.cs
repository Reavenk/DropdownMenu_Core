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

using System.Collections.Generic;
using UnityEngine;

namespace PxPre.DropMenu
{
    [System.Flags]
    public enum Flags
    { 
        /// <summary>
        /// The menu item is selected.
        /// </summary>
        Selected    = 1 << 1,

        /// <summary>
        /// The menu item is disabled. Not only does this affect the visual appearance,
        /// this will also disable the node's ability to handle inputs.
        /// </summary>
        Disabled    = 1 << 2,

        /// <summary>
        /// The menu item has a color override. The menu's style will be ignore and the
        /// node's color override will be used instead.
        /// </summary>
        Colored     = 1 << 3,

        /// <summary>
        // For submenus, if scrollable with a single selection, 
        // scroll to it.
        /// </summary>
        CenterScrollSel = 1 << 4,
    }

    /// <summary>
    /// An entry in the dropdown menu. Theses nodes create a tree datastructure that
    /// define the contents of a menu (and their submenus).
    /// </summary>
    public class Node
    {
        /// <summary>
        /// The types of elements that can exist in a dropdown menu.
        /// </summary>
        public enum Type
        {
            /// <summary>
            /// A submenu. The user can place the cursor over the menu to spawn another
            /// cascading child menu.
            /// </summary>
            Menu,

            /// <summary>
            /// A menu button. The user can click the button in the menu to perform an action.
            /// </summary>
            Action,

            /// <summary>
            /// A seperator to visually divide sections of the menu from each other.
            /// </summary>
            Separator,

            /// <summary>
            /// A special menu action that closes the parent submenu and puts focus on the
            /// parent menu.
            /// </summary>
            GoBack
        }

        /// <summary>
        /// The label to display in the menu. Only relevant for certain node types.
        /// </summary>
        public string label = "";

        /// <summary>
        /// The type of node.
        /// </summary>
        public Type type;

        /// <summary>
        /// The submenu children. Only relevant for Menu nodes.
        /// </summary>
        public List<Node> children = null;

        /// <summary>
        /// The action to perform on being selected. Only relevant for Action nodes.
        /// </summary>
        public System.Action action = null;

        /// <summary>
        /// The sprite. Only relevant for certain node types.
        /// </summary>
        public Sprite sprite;

        /// <summary>
        /// The override color. Only relelvant for certain node types.
        /// </summary>
        public Color color = Color.white;

        /// <summary>
        /// The text alignment. Only relevant for nodes that have text.
        /// </summary>
        public Props.TextAlignment alignment = Props.TextAlignment.Default;

        /// <summary>
        /// Bitflag properties.
        /// </summary>
        public Flags flags = 0;

        /// <summary>
        /// Action node constructor.
        /// </summary>
        /// <param name="label">The labeled displayed for the menu item.</param>
        /// <param name="onSel">The action perform if the menu item is clicked.</param>
        /// <param name="flags">Node property flags.</param>
        public Node(string label, System.Action onSel, Flags flags = 0)
        { 
            this.type = Type.Action;
            this.flags = flags;
            this.label = label;
            this.action = onSel;
        }

        /// <summary>
        /// Misc blank constructor.
        /// </summary>
        /// <param name="type">Creates a node by only defining the type.</param>
        /// <param name="flags">Node property flags.</param>
        public Node(Type type, Flags flags = 0)
        { 
            this.type = type;
            this.flags = flags;

            if(type == Type.Menu)
                this.children = new List<Node>();
        }

        /// <summary>
        /// Adds a separator node to the end of the menu.
        /// </summary>
        /// <returns>The added separator node.</returns>
        public Node AddSeparator()
        { 
            Node n = new Node(Type.Separator);
            this.AddChild(n);
            return n;
        }

        /// <summary>
        /// Adds a plain text Action node to the end of the menu.
        /// </summary>
        /// <param name="label"></param>
        /// <param name="onSel"></param>
        /// <returns></returns>
        public Node AddAction(string label, System.Action onSel)
        { 
            return this.AddAction(null, label, onSel);
        }

        /// <summary>
        /// Adds an Action node with a sprite to the end of the menu.
        /// </summary>
        /// <param name="icon">The icon for the entry. Optional.</param>
        /// <param name="label">The label displayed for the node entry.</param>
        /// <param name="onSel">The action to perform if the node's button is clicked.</param>
        /// <returns></returns>
        public Node AddAction(Sprite icon, string label, System.Action onSel)
        {
            return this.AddAction(icon, Color.white, label, onSel);
        }

        /// <summary>
        /// Adds an Action node with an overriden color and sprite to the end of the menu.
        /// </summary>
        /// <param name="icon">The icon for the entry. Optional</param>
        /// <param name="color">The override color.</param>
        /// <param name="label">The label displayed for the submenu.</param>
        /// <param name="onSel">The action to perform if the node's button is clicked.</param>
        /// <param name="flags">The node property flags.</param>
        /// <returns></returns>
        public Node AddAction(Sprite icon, Color color, string label, System.Action onSel, Flags flags = 0)
        {
            Node n = new Node(label, onSel);
            n.sprite = icon;
            n.color = color;
            n.flags = flags;
            this.AddChild(n);
            return n;
        }

        /// <summary>
        /// Adds a submenu to the end of the menu.
        /// </summary>
        /// <param name="label">The label displayed for the submenu.</param>
        /// <param name="flags">The node property flags.</param>
        /// <returns>The created submenu node.</returns>
        public Node AddSubmenu(string label, Flags flags = 0)
        { 
            Node n = new Node( Type.Menu);
            n.label = label;
            n.flags = flags;

            this.AddChild(n);
            return n;
        }

        /// <summary>
        /// Adds a child node to the end of the menu.
        /// </summary>
        /// <param name="child">The node to add.</param>
        public void AddChild(Node child)
        { 
            if(this.children == null)
                this.children = new List<Node>();

            this.children.Add(child);

        }
    }
}