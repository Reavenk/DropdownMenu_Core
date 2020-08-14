using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PxPre
{
    namespace DropMenu
    {
        public class StackUtil
        {
            Stack<Node> stack = new Stack<Node>();
            Node root = null;
            Node curr = null;

            public Node Root {get{return this.root; } }

            public StackUtil(string title = "", Flags flags = 0)
            { 
                this.root = new Node(Node.Type.Menu, flags);
                this.root.label = title;

                this.stack.Push(this.root);
                this.curr = this.root;
            }

            public void PushMenu(string title, Flags flags = 0)
            { 
                this.stack.Push(this.curr);
                this.curr = this.curr.AddSubmenu(title, flags);
            }

            public void PopMenu()
            { 
                if(this.stack.Count <= 1)
                    return;

                this.curr = this.stack.Pop();
            }

            public void AddSeparator()
            { 
                this.curr.AddSeparator();
            }

            public void AddAction(string label, System.Action onSel, bool sel = false)
            { 
                this.curr.AddAction(label, onSel);
            }

            public void AddAction(Color color, string label, System.Action onSel)
            {
                this.curr.AddAction(null, color, label, onSel);
            }

            public void AddAction(Sprite icon, Color color, string label, System.Action onSel, Flags flags = 0)
            { 
                this.curr.AddAction(icon, color, label, onSel, flags|Flags.Colored);
            }

            public void AddAction(Sprite icon, Color color, string label, System.Action onSel)
            { 
                this.curr.AddAction(icon, color, label, onSel, Flags.Colored);
            }

            public void AddAction(bool sel, Sprite icon, Color color, string label, System.Action onSel)
            { 
                this.curr.AddAction(icon, color, label, onSel, sel ? Flags.Selected : 0);
            }

            public void AddAction(Sprite icon, string label, System.Action onSel)
            { 
                this.curr.AddAction(icon, Color.white, label, onSel, 0);
            }

            public void AddAction(bool sel, Sprite icon, string label, System.Action onSel)
            {
                this.curr.AddAction(icon, Color.white, label, onSel, sel ? Flags.Selected : 0);
            }
        }
    }
}