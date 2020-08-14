using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PxPre
{
    namespace DropMenu
    {
        [System.Flags]
        public enum Flags
        { 
            Selected    = 1 << 1,
            Disabled    = 1 << 2,
            Colored     = 1 << 3,

            // For submenus, if scrollable with a single selection, 
            // scroll to it.
            CenterScrollSel   = 1 << 4,
        }

        public class Node
        {
            public enum Type
            {
                Menu,
                Action,
                Separator,
                GoBack
            }

            

            public string label = "";
            public Type type;
            public List<Node> children = null;
            public System.Action action = null;
            public Sprite sprite;
            public Color color = Color.white;
            public Props.TextAlignment alignment = Props.TextAlignment.Default;
            public Flags flags = 0;

            public Node(string label, System.Action onSel, Flags flags = 0)
            { 
                this.type = Type.Action;
                this.flags = flags;
                this.label = label;
                this.action = onSel;
            }

            public Node(Type type, Flags flags = 0)
            { 
                this.type = type;
                this.flags = flags;

                if(type == Type.Menu)
                    this.children = new List<Node>();
            }

            public Node AddSeparator()
            { 
                Node n = new Node(Type.Separator);
                this.AddChild(n);
                return n;
            }

            public Node AddAction(string label, System.Action onSel)
            { 
                return this.AddAction(null, label, onSel);
            }

            public Node AddAction(Sprite icon, string label, System.Action onSel)
            {
                return this.AddAction(icon, Color.white, label, onSel);
            }

            public Node AddAction(Sprite icon, Color color, string label, System.Action onSel, Flags flags = 0)
            {
                Node n = new Node(label, onSel);
                n.sprite = icon;
                n.color = color;
                n.flags = flags;
                this.AddChild(n);
                return n;
            }

            public Node AddSubmenu(string label, Flags flags = 0)
            { 
                Node n = new Node( Type.Menu);
                n.label = label;
                n.flags = flags;

                this.AddChild(n);
                return n;
            }

            public void AddChild(Node child)
            { 
                if(this.children == null)
                    this.children = new List<Node>();

                this.children.Add(child);

            }
        }
    }
}