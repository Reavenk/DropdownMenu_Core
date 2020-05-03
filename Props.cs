using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PxPre
{
    namespace DropMenu
    {
        [CreateAssetMenu(menuName = "PxPre/DropMenuProps")]
        public class Props : ScriptableObject
        {
            [System.Serializable]
            public class Padding
            {
                public float top;
                public float left;
                public float right;
                public float bottom;
            }

            /// <summary>
            /// The color and opacity of the modal plate hosting the dropdown menu.
            /// </summary>
            public Color modalPlateColor;

            /// <summary>
            /// If true, show the titles of menus
            /// </summary>
            public bool showTitles;

            public Padding outerPadding;

            public Font titleFont;
            public Font entryFont;
            public Color entryFontColor = Color.black;
            public Padding entryPadding;
            public int entryFontSize = 14;
            public float minEntrySize = 20.0f;
            public Sprite submenuSpawnArrow;
            public Sprite entrySprite;

            public float iconTextPadding = 5.0f;
            public float textArrowPadding = 5.0f;

            public Sprite shadow;
            public Sprite plate;
            public Vector2 shadowOffset;
            public Color shadowColor = Color.black;

            public Sprite splitter;
            public Padding splitterPadding;
            public float minSplitter = 10.0f;

            public float childrenSpacing = 3.0f;


        }
    }
}