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

            public StackUtil(string title = "")
            { 
                this.root = new Node(Node.Type.Menu);
                this.root.label = title;

                this.stack.Push(this.root);
                this.curr = this.root;
            }

            public void PushMenu(string title)
            { 
                this.curr = this.curr.AddSubmenu(title);
                this.stack.Push(this.curr);
            }

            public void PopMenu()
            { 
                if(this.stack.Count == 1)
                    return;

                this.curr = this.stack.Pop();
            }

            public void AddSeparator()
            { 
                this.curr.AddSeparator();
            }

            public void AddAction(string label, System.Action onSel)
            { 
                this.curr.AddAction(label, onSel);
            }

            public void AddAction(Sprite icon, string label, System.Action onSel)
            { 
                this.curr.AddAction(icon, label, onSel);
            }
        }
    }
}