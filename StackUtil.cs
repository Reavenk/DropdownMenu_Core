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
    /// <summary>
    /// A utility class to create a heirarchy of Nodes for a dropdown menu, with a
    /// stack backed API similar to immediate mode APIs. 
    /// </summary>
    public class StackUtil
    {
        /// <summary>
        /// The current stack hierarchy of nodes.
        /// </summary>
        Stack<Node> stack = new Stack<Node>();

        /// <summary>
        /// The root node.
        /// </summary>
        Node root = null;

        /// <summary>
        /// The cached top of the stack.
        /// </summary>
        Node curr = null;

        /// <summary>
        /// The root node.
        /// </summary>
        public Node Root {get{return this.root; } }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="title">The title of the menu.</param>
        /// <param name="flags">Property flags.</param>
        /// <remarks>The titles parameter is a placholder. Menu titles are not currently supported.</remarks>
        public StackUtil(string title = "", Flags flags = 0)
        { 
            this.root = new Node(Node.Type.Menu, flags);
            this.root.label = title;

            this.stack.Push(this.root);
            this.curr = this.root;
        }

        /// <summary>
        /// Push a menu to the node on the top of the stack. All Push* and Add* calls will add content
        /// to this new submenu node until the next PopMenu() call.
        /// </summary>
        /// <param name="title">The submenu label.</param>
        /// <param name="flags">Submenu properties.</param>
        public void PushMenu(string title, Flags flags = 0)
        { 
            this.stack.Push(this.curr);
            this.curr = this.curr.AddSubmenu(title, flags);
        }

        /// <summary>
        /// Pop a menu off a stack. Poping a menu off the stack redirects all Add* and Push* 
        /// functions to the submenu before the last Push.
        /// </summary>
        public void PopMenu()
        { 
            if(this.stack.Count <= 1)
                return;

            this.curr = this.stack.Pop();
        }

        /// <summary>
        /// Adds a separator to the node on the top of the stack.
        /// </summary>
        public void AddSeparator()
        { 
            this.curr.AddSeparator();
        }

        /// <summary>
        /// Add an action to the top node of the stack, uses property colors.
        /// </summary>
        /// <param name="label">The label of the menu item.</param>
        /// <param name="onSel">The action's callback.</param>
        /// <param name="sel">If true, the menu item is given the selection color.</param>
        public void AddAction(string label, System.Action onSel, bool sel = false)
        { 
            this.curr.AddAction(label, onSel);
        }

        /// <summary>
        /// Add an action to the top node of the stack, uses a color override.
        /// </summary>
        /// <param name="color">The color to override the menu item.</param>
        /// <param name="label">The label of the menu item.</param>
        /// <param name="onSel">The action's callback.</param>
        public void AddAction(Color color, string label, System.Action onSel)
        {
            this.curr.AddAction(null, color, label, string.Empty, onSel);
        }

        /// <summary>
        /// Add an action to the top node of the stack. The method provides all
        /// options for defining an action node.
        /// </summary>
        /// <param name="icon">The icon to draw with the menu item.</param>
        /// <param name="color">The color to override the menu item.</param>
        /// <param name="label">The label of the menu item.</param>
        /// <param name="onSel">The action's callback.</param>
        /// <param name="flags">Node properties of the action's menu item.</param>
        public void AddAction(Sprite icon, Color color, string label, System.Action onSel, Flags flags = 0)
        { 
            this.curr.AddAction(icon, color, label, string.Empty, onSel, flags|Flags.Colored);
        }

        /// <summary>
        /// Add an action to the top node of the stack. Includes parameters for
        /// an icon and color override.
        /// </summary>
        /// <param name="icon">The icon to draw with the menu item.</param>
        /// <param name="color">The color to override the menu item.</param>
        /// <param name="label">The label of the menu item.</param>
        /// <param name="onSel">The action's callback.</param>
        public void AddAction(Sprite icon, Color color, string label, System.Action onSel)
        { 
            this.curr.AddAction(icon, color, label, string.Empty, onSel, Flags.Colored);
        }

        /// <summary>
        /// Adds an action that's either selected or unselected, depending on a specified bool parameter.
        /// This version also has a color override.
        /// </summary>
        /// <param name="sel">The selection state of the action.</param>
        /// <param name="icon">The icon to draw with the menu item.</param>
        /// <param name="color">The color to override the menu item.</param>
        /// <param name="label">The label of the menu item.</param>
        /// <param name="onSel">The action's callback.</param>
        public void AddAction(bool sel, Sprite icon, Color color, string label, System.Action onSel)
        { 
            this.curr.AddAction(icon, color, label, string.Empty, onSel, sel ? Flags.Selected : 0);
        }

        /// <summary>
        /// Adds an action with a sprite and icon.
        /// </summary>
        /// <param name="icon">The icon to draw with the menu.</param>
        /// <param name="label">The label of the menu item.</param>
        /// <param name="onSel">The action's callback.</param>
        public void AddAction(Sprite icon, string label, System.Action onSel)
        { 
            this.curr.AddAction(icon, Color.white, label, string.Empty, onSel, 0);
        }

        /// <summary>
        /// Adds an action that's either selected or unselected, depending on a specified bool parameter.
        /// </summary>
        /// <param name="sel">The selection state of the action.</param>
        /// <param name="icon">The icon to draw with the menu item.</param>
        /// <param name="label">The label of the menu item.</param>
        /// <param name="onSel">The action's callback.</param>
        public void AddAction(bool sel, Sprite icon, string label, System.Action onSel)
        {
            this.curr.AddAction(icon, Color.white, label, string.Empty, onSel, sel ? Flags.Selected : 0);
        }
        
        /// <summary>
        /// Add an action to the top node of the stack, uses property colors.
        /// </summary>
        /// <param name="label">The label of the menu item.</param>
        /// <param name="shortcut">The displayed action keyboard shortcut.</param>
        /// <param name="onSel">The action's callback.</param>
        /// <param name="sel">If true, the menu item is given the selection color.</param>
        public void AddAction(string label, string shortcut, System.Action onSel, bool sel = false)
        { 
            this.curr.AddAction(label, shortcut, onSel);
        }

        /// <summary>
        /// Add an action to the top node of the stack, uses a color override.
        /// </summary>
        /// <param name="color">The color to override the menu item.</param>
        /// <param name="label">The label of the menu item.</param>
        /// <param name="shortcut">The displayed action keyboard shortcut.</param>
        /// <param name="onSel">The action's callback.</param>
        public void AddAction(Color color, string label, string shortcut, System.Action onSel)
        {
            this.curr.AddAction(null, color, label, shortcut, onSel);
        }

        /// <summary>
        /// Add an action to the top node of the stack. The method provides all
        /// options for defining an action node.
        /// </summary>
        /// <param name="icon">The icon to draw with the menu item.</param>
        /// <param name="color">The color to override the menu item.</param>
        /// <param name="label">The label of the menu item.</param>
        /// <param name="shortcut">The displayed action keyboard shortcut.</param>
        /// <param name="onSel">The action's callback.</param>
        /// <param name="flags">Node properties of the action's menu item.</param>
        public void AddAction(Sprite icon, Color color, string label, string shortcut, System.Action onSel, Flags flags = 0)
        { 
            this.curr.AddAction(icon, color, label, shortcut, onSel, flags|Flags.Colored);
        }

        /// <summary>
        /// Add an action to the top node of the stack. Includes parameters for
        /// an icon and color override.
        /// </summary>
        /// <param name="icon">The icon to draw with the menu item.</param>
        /// <param name="color">The color to override the menu item.</param>
        /// <param name="label">The label of the menu item.</param>
        /// <param name="shortcut">The displayed action keyboard shortcut.</param>
        /// <param name="onSel">The action's callback.</param>
        public void AddAction(Sprite icon, Color color, string label, string shortcut, System.Action onSel)
        { 
            this.curr.AddAction(icon, color, label, shortcut, onSel, Flags.Colored);
        }

        /// <summary>
        /// Adds an action that's either selected or unselected, depending on a specified bool parameter.
        /// This version also has a color override.
        /// </summary>
        /// <param name="sel">The selection state of the action.</param>
        /// <param name="icon">The icon to draw with the menu item.</param>
        /// <param name="color">The color to override the menu item.</param>
        /// <param name="label">The label of the menu item.</param>
        /// <param name="shortcut">The displayed action keyboard shortcut.</param>
        /// <param name="onSel">The action's callback.</param>
        public void AddAction(bool sel, Sprite icon, Color color, string label, string shortcut, System.Action onSel)
        { 
            this.curr.AddAction(icon, color, label, shortcut, onSel, sel ? Flags.Selected : 0);
        }

        /// <summary>
        /// Adds an action with a sprite and icon.
        /// </summary>
        /// <param name="icon">The icon to draw with the menu.</param>
        /// <param name="label">The label of the menu item.</param>
        /// <param name="shortcut">The displayed action keyboard shortcut.</param>
        /// <param name="onSel">The action's callback.</param>
        public void AddAction(Sprite icon, string label, string shortcut, System.Action onSel)
        { 
            this.curr.AddAction(icon, Color.white, label, shortcut, onSel, 0);
        }

        /// <summary>
        /// Adds an action that's either selected or unselected, depending on a specified bool parameter.
        /// </summary>
        /// <param name="sel">The selection state of the action.</param>
        /// <param name="icon">The icon to draw with the menu item.</param>
        /// <param name="label">The label of the menu item.</param>
        /// <param name="shortcut">The displayed action keyboard shortcut.</param>
        /// <param name="onSel">The action's callback.</param>
        public void AddAction(bool sel, Sprite icon, string label, string shortcut, System.Action onSel)
        {
            this.curr.AddAction(icon, Color.white, label, shortcut, onSel, sel ? Flags.Selected : 0);
        }
    }
}