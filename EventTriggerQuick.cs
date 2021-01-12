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
    /// Utility class to add and edit EventTrigger behaviours. This class wrapped a reference 
    /// to an EventTrigger and then provides a library of class methods that returns itself
    /// so that command can be chained.
    /// </summary>
    public class EventTriggerQuick
    {
        /// <summary>
        /// The EventTrigger to focus the methods on.
        /// </summary>
        public UnityEngine.EventSystems.EventTrigger trigger;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="et">The EventTrigger to focus the methods on.</param>
        public EventTriggerQuick(UnityEngine.EventSystems.EventTrigger et)
        { 
            this.trigger = et;
        }

        /// <summary>
        /// EventTriggerQuick method for inserting an BeginDrag event into the wrapped EventTrigger.
        /// </summary>
        /// <param name="cb">The callback to the event.</param>
        public void AddOnBeginDrag(UnityEngine.Events.UnityAction<UnityEngine.EventSystems.PointerEventData> cb)
        { 
            UnityEngine.EventSystems.EventTrigger.Entry e = 
                this.trigger.GetEntry(UnityEngine.EventSystems.EventTriggerType.BeginDrag);

            e.callback.AddListener( (x)=>{ cb((UnityEngine.EventSystems.PointerEventData)x); });
        }

        /// <summary>
        /// EventTriggerQuick method for inserting an Cancel event into the wrapped EventTrigger.
        /// </summary>
        /// <param name="cb">The callback to the event.</param>
        public void AddOnCancel(UnityEngine.Events.UnityAction<UnityEngine.EventSystems.BaseEventData> cb)
        { 
            UnityEngine.EventSystems.EventTrigger.Entry e = 
                this.trigger.GetEntry(UnityEngine.EventSystems.EventTriggerType.Cancel);

            e.callback.AddListener( (x)=>{ cb(x); });
        }

        /// <summary>
        /// EventTriggerQuick method for inserting an Deselect event into the wrapped EventTrigger.
        /// </summary>
        /// <param name="cb">The callback to the event.</param>
        public void AddOnDeselect(UnityEngine.Events.UnityAction<UnityEngine.EventSystems.BaseEventData> cb)
        { 
            UnityEngine.EventSystems.EventTrigger.Entry e = 
                this.trigger.GetEntry(UnityEngine.EventSystems.EventTriggerType.Deselect);

            e.callback.AddListener( (x)=>{ cb(x); });
        }

        /// <summary>
        /// EventTriggerQuick method for inserting an Drag event into the wrapped EventTrigger.
        /// </summary>
        /// <param name="cb">The callback to the event.</param>
        public void AddOnDrag(UnityEngine.Events.UnityAction<UnityEngine.EventSystems.PointerEventData> cb)
        { 
            UnityEngine.EventSystems.EventTrigger.Entry e = 
                this.trigger.GetEntry(UnityEngine.EventSystems.EventTriggerType.Drag);

            e.callback.AddListener( (x)=>{ cb((UnityEngine.EventSystems.PointerEventData)x); });
        }

        /// <summary>
        /// EventTriggerQuick method for inserting an Drop event into the wrapped EventTrigger.
        /// </summary>
        /// <param name="cb">The callback to the event.</param>
        public void AddOnDrop(UnityEngine.Events.UnityAction<UnityEngine.EventSystems.PointerEventData> cb)
        { 
            UnityEngine.EventSystems.EventTrigger.Entry e = 
                this.trigger.GetEntry(UnityEngine.EventSystems.EventTriggerType.Drop);

            e.callback.AddListener( (x)=>{ cb((UnityEngine.EventSystems.PointerEventData)x); });
        }

        /// <summary>
        /// EventTriggerQuick method for inserting an EndDrag event into the wrapped EventTrigger.
        /// </summary>
        /// <param name="cb">The callback to the event.</param>
        public void AddOnEndDrag(UnityEngine.Events.UnityAction<UnityEngine.EventSystems.PointerEventData> cb)
        { 
            UnityEngine.EventSystems.EventTrigger.Entry e = 
                this.trigger.GetEntry(UnityEngine.EventSystems.EventTriggerType.EndDrag);

            e.callback.AddListener( (x)=>{ cb((UnityEngine.EventSystems.PointerEventData)x); });
        }

        /// <summary>
        /// EventTriggerQuick method for inserting an PotentialDrag event into the wrapped EventTrigger.
        /// </summary>
        /// <param name="cb">The callback to the event.</param>
        public void AddOnInitializePotentialDrag(UnityEngine.Events.UnityAction<UnityEngine.EventSystems.PointerEventData> cb)
        { 
            UnityEngine.EventSystems.EventTrigger.Entry e = 
                this.trigger.GetEntry(UnityEngine.EventSystems.EventTriggerType.Drag);

            e.callback.AddListener( (x)=>{ cb((UnityEngine.EventSystems.PointerEventData)x); });
        }

        /// <summary>
        /// EventTriggerQuick method for inserting an Move event into the wrapped EventTrigger.
        /// </summary>
        /// <param name="cb">The callback to the event.</param>
        public void AddOnMove(UnityEngine.Events.UnityAction<UnityEngine.EventSystems.AxisEventData> cb)
        { 
            UnityEngine.EventSystems.EventTrigger.Entry e = 
                this.trigger.GetEntry(UnityEngine.EventSystems.EventTriggerType.Move);

            e.callback.AddListener( (x)=>{ cb((UnityEngine.EventSystems.AxisEventData)x); });
        }

        /// <summary>
        /// EventTriggerQuick method for inserting an PointerClick event into the wrapped EventTrigger.
        /// </summary>
        /// <param name="cb">The callback to the event.</param>
        public void AddOnPointerClick(UnityEngine.Events.UnityAction<UnityEngine.EventSystems.PointerEventData> cb)
        { 
            UnityEngine.EventSystems.EventTrigger.Entry e = 
                this.trigger.GetEntry(UnityEngine.EventSystems.EventTriggerType.PointerClick);

            e.callback.AddListener( (x)=>{ cb((UnityEngine.EventSystems.PointerEventData)x); });
        }

        /// <summary>
        /// EventTriggerQuick method for inserting an PointerDown event into the wrapped EventTrigger.
        /// </summary>
        /// <param name="cb">The callback to the event.</param>
        public void AddOnPointerDown(UnityEngine.Events.UnityAction<UnityEngine.EventSystems.PointerEventData> cb)
        { 
            UnityEngine.EventSystems.EventTrigger.Entry e = 
                this.trigger.GetEntry(UnityEngine.EventSystems.EventTriggerType.PointerDown);

            e.callback.AddListener( (x)=>{ cb((UnityEngine.EventSystems.PointerEventData)x); });
        }

        /// <summary>
        /// EventTriggerQuick method for inserting an PointerEnter event into the wrapped EventTrigger.
        /// </summary>
        /// <param name="cb">The callback to the event.</param>
        public void AddOnPointerEnter(UnityEngine.Events.UnityAction<UnityEngine.EventSystems.PointerEventData> cb)
        { 
            UnityEngine.EventSystems.EventTrigger.Entry e = 
                this.trigger.GetEntry(UnityEngine.EventSystems.EventTriggerType.PointerEnter);

            e.callback.AddListener( (x)=>{ cb((UnityEngine.EventSystems.PointerEventData)x); });
        }

        /// <summary>
        /// EventTriggerQuick method for inserting an PointerExit event into the wrapped EventTrigger.
        /// </summary>
        /// <param name="cb">The callback to the event.</param>
        public void AddOnPointerExit(UnityEngine.Events.UnityAction<UnityEngine.EventSystems.PointerEventData> cb)
        { 
            UnityEngine.EventSystems.EventTrigger.Entry e = 
                this.trigger.GetEntry(UnityEngine.EventSystems.EventTriggerType.PointerExit);

            e.callback.AddListener( (x)=>{ cb((UnityEngine.EventSystems.PointerEventData)x); });
        }

        /// <summary>
        /// EventTriggerQuick method for inserting an OnPointerUp event into the wrapped EventTrigger.
        /// </summary>
        /// <param name="cb">The callback to the event.</param>
        public void AddOnPointerUp(UnityEngine.Events.UnityAction<UnityEngine.EventSystems.PointerEventData> cb)
        { 
            UnityEngine.EventSystems.EventTrigger.Entry e = 
                this.trigger.GetEntry(UnityEngine.EventSystems.EventTriggerType.PointerUp);

            e.callback.AddListener( (x)=>{ cb((UnityEngine.EventSystems.PointerEventData)x); });
        }

        /// <summary>
        /// EventTriggerQuick method for inserting an Scroll event into the wrapped EventTrigger.
        /// </summary>
        /// <param name="cb">The callback to the event.</param>
        public void AddOnScroll(UnityEngine.Events.UnityAction<UnityEngine.EventSystems.PointerEventData> cb)
        { 
            UnityEngine.EventSystems.EventTrigger.Entry e = 
                this.trigger.GetEntry(UnityEngine.EventSystems.EventTriggerType.Scroll);

            e.callback.AddListener( (x)=>{ cb((UnityEngine.EventSystems.PointerEventData)x); });
        }

        /// <summary>
        /// EventTriggerQuick method for inserting an Select event into the wrapped EventTrigger.
        /// </summary>
        /// <param name="cb">The callback to the event.</param>
        public void AddOnSelect(UnityEngine.Events.UnityAction<UnityEngine.EventSystems.BaseEventData> cb)
        { 
            UnityEngine.EventSystems.EventTrigger.Entry e = 
                this.trigger.GetEntry(UnityEngine.EventSystems.EventTriggerType.Select);

            e.callback.AddListener( (x)=>{ cb(x); });
        }

        /// <summary>
        /// EventTriggerQuick method for inserting an Submit event into the wrapped EventTrigger.
        /// </summary>
        /// <param name="cb">The callback to the event.</param>
        public void AddOnSubmit(UnityEngine.Events.UnityAction<UnityEngine.EventSystems.BaseEventData> cb)
        {
            UnityEngine.EventSystems.EventTrigger.Entry e = 
                this.trigger.GetEntry(UnityEngine.EventSystems.EventTriggerType.Submit);

            e.callback.AddListener( (x)=>{ cb(x); });
        }

        /// <summary>
        /// EventTriggerQuick method for inserting an UpdatedSelected event into the wrapped EventTrigger.
        /// </summary>
        /// <param name="cb">The callback to the event.</param>
        public void AddOnUpdateSelected(UnityEngine.Events.UnityAction<UnityEngine.EventSystems.BaseEventData> cb)
        { 
            UnityEngine.EventSystems.EventTrigger.Entry e = 
                this.trigger.GetEntry(UnityEngine.EventSystems.EventTriggerType.Select);

            e.callback.AddListener( (x)=>{ cb(x); });
        }
    }

    /// <summary>
    /// Utility class to add the EventTriggerQuick library as extension methods to
    /// the EventTrigger class.
    /// </summary>
    public static class EventTriggerQuickUtil
    { 
        /// <summary>
        /// Create an EventTriggerQuick object from a GameObject.
        /// 
        /// Extension method to GameObject.
        /// </summary>
        /// <param name="go">The GameObject to extract the EventTriggerQuick from.</param>
        /// <returns>The requested EventTriggerQuick object.</returns>
        /// <remarks>If the GameObject does not have an EventTrigger, one is automatically added.</remarks>
        public static EventTriggerQuick ETQ(this GameObject go)
        {
            UnityEngine.EventSystems.EventTrigger et = go.GetComponent<UnityEngine.EventSystems.EventTrigger>();
            if(et == null)
                et = go.AddComponent<UnityEngine.EventSystems.EventTrigger>();

            return new EventTriggerQuick(et);
        }

        /// <summary>
        /// Create a retrieve an EventTrigger.Entry from an EventTrigger.
        /// 
        /// Extension method to EventTrigger.
        /// </summary>
        /// <param name="et">The EventTrigger to process.</param>
        /// <param name="ty">The type of event to retrieve.</param>
        /// <returns>The EventTrigger.Entry of event type ty in the EventTrigger.</returns>
        /// <remarks>If the EventTrigger does not contain the event, one is created.</remarks>
        public static UnityEngine.EventSystems.EventTrigger.Entry GetEntry(
                this UnityEngine.EventSystems.EventTrigger et,
                UnityEngine.EventSystems.EventTriggerType ty)
        { 
            if(et.triggers == null)
                et.triggers = new List<UnityEngine.EventSystems.EventTrigger.Entry>();

            foreach(UnityEngine.EventSystems.EventTrigger.Entry e in et.triggers)
            {
                if(e.eventID == ty)
                    return e;
            }

            UnityEngine.EventSystems.EventTrigger.Entry ret = new UnityEngine.EventSystems.EventTrigger.Entry();
            ret.eventID = ty;

            et.triggers.Add(ret);
            return ret;
        }
    }
}