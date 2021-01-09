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
        /// The various layout properties and assets that define a dropdown menu's
        /// thematic look.
        /// </summary>
        [CreateAssetMenu(menuName = "PxPre/DropMenuProps")]
        public class Props : ScriptableObject
        {
            /// <summary>
            /// Defines blank space on fours sides of a rectangle.
            /// </summary>
            [System.Serializable]
            public class Padding
            {
                /// <summary>
                /// The space on the top.
                /// </summary>
                public float top;

                /// <summary>
                /// The space on the left.
                /// </summary>
                public float left;

                /// <summary>
                /// The space on the right.
                /// </summary>
                public float right;

                /// <summary>
                /// The space on the bottom.
                /// </summary>
                public float bottom;
            }

            /// <summary>
            /// Properties that can be specified for elements implement from a 
            /// UnityEngine.UI.Selectable.
            /// </summary>
            [System.Serializable]
            public class SelectableProperties
            {
                /// <summary>
                /// The default sprite.
                /// </summary>
                public Sprite spriteNormal;

                /// <summary>
                /// The default color.
                /// </summary>
                public Color color;

                /// <summary>
                /// The color block if color transitions are used.
                /// </summary>
                public UnityEngine.UI.ColorBlock colorBlock;

                /// <summary>
                /// The sprite collection for sprite swapping transitions.
                /// </summary>
                public UnityEngine.UI.SpriteState spriteState;

                /// <summary>
                /// The transition mode. Used to specify is colorBlock or spriteState (or neither) 
                /// are relevant.
                /// </summary>
                public UnityEngine.UI.Selectable.Transition transition;

                /// <summary>
                /// All the properties of the SelectableProperties to a UI.Selectable.
                /// </summary>
                /// <param name="sel">The selectable to match the properties for.</param>
                /// <param name="img">The image to match the properties for.</param>
                public void Apply(UnityEngine.UI.Selectable sel, UnityEngine.UI.Image img)
                { 
                    img.color = this.color;
                    img.sprite = this.spriteNormal;
                    img.type = UnityEngine.UI.Image.Type.Sliced;

                    sel.colors = this.colorBlock;
                    sel.spriteState = this.spriteState;
                    sel.targetGraphic = img;
                    sel.transition = this.transition;
                }
            }

            /// <summary>
            /// Different modes to specify alignment of text.
            /// </summary>
            public enum TextAlignment
            { 
                /// <summary>
                /// Left aligned.
                /// </summary>
                Left,

                /// <summary>
                /// Middle aligned.
                /// </summary>
                Middle,

                /// <summary>
                /// Right aligned.
                /// </summary>
                Right,

                /// <summary>
                /// Use the default defined value. See defaultTextAlignment for more
                /// information.
                /// </summary>
                Default
            }

            /// <summary>
            /// The color and opacity of the modal plate hosting the dropdown menu.
            /// </summary>
            public Color modalPlateColor;

            /// <summary>
            /// If true, show the titles of menus
            /// </summary>
            public bool showTitles;

            /// <summary>
            /// The outer padding between the inner menu item elements and the dropdown menu body.
            /// </summary>
            public Padding outerPadding;

            // For now this is just a variable that is held and referenced,
            // but not directly used.
            public Color unselectedColor = Color.white;

            // For now this is just a variable that is held and referenced,
            // but not directly used.
            public Color selectedColor = new Color(0.8f, 1.0f, 0.8f);

            /// <summary>
            /// The font for the menu title.
            /// </summary>
            /// <remarks>Menu titles are currently not implemented.</remarks>
            public Font titleFont;

            /// <summary>
            /// The font for labels, such as the text for actions and submenus.
            /// </summary>
            public Font entryFont;

            /// <summary>
            /// The font color for labels.
            /// </summary>
            public Color entryFontColor = Color.black;

            /// <summary>
            /// The minimum space on all sides of a menu entry before reaching
            /// the menu item's plate.
            /// </summary>
            public Padding entryPadding;

            /// <summary>
            /// The font size for labels.
            /// </summary>
            public int entryFontSize = 14;

            /// <summary>
            /// The minimum height of an entry (excludes separators).
            /// </summary>
            public float minEntrySize = 20.0f;

            /// <summary>
            /// The sprite placed on the right of submenu menu items to visually identify
            /// them as submenus.
            /// </summary>
            public Sprite submenuSpawnArrow;

            /// <summary>
            /// The sprite used as the plate for actions and submenus.
            /// </summary>
            public Sprite entrySprite;

            /// <summary>
            /// The amount of horizontal space that separates a menu item's icon and label.
            /// </summary>
            public float iconTextPadding = 5.0f;

            /// <summary>
            /// The amount of horizontal space that spearates a submenu item's label
            /// and spawn arrow.
            /// </summary>
            public float textArrowPadding = 5.0f;

            /// <summary>
            /// The sprite for the dropdown menu's shadow.
            /// </summary>
            public Sprite shadow;

            /// <summary>
            /// The sprite for the body of the drowndown menu.
            /// </summary>
            public Sprite plate;

            /// <summary>
            /// The position offset of the menu's shadow from the menu.
            /// </summary>
            public Vector2 shadowOffset;

            /// <summary>
            /// The color of the menu's shadow sprite.
            /// </summary>
            public Color shadowColor = Color.black;

            /// <summary>
            /// The sprite for separators.
            /// </summary>
            public Sprite splitter;

            /// <summary>
            /// The padding on all sides of a splitter.
            /// </summary>
            public Padding splitterPadding;

            /// <summary>
            /// The height of a splitter.
            /// </summary>
            public float minSplitter = 10.0f;

            /// <summary>
            /// The vertical padding between menu items.
            /// </summary>
            public float childrenSpacing = 3.0f;

            /// <summary>
            /// The sprite for a menu scrollbar.
            /// </summary>
            /// <remarks>If a menu becomes too tall to fit on screen, a scrollbar is 
            /// provided so the user will still be able to access all menu items.</remarks>
            public Sprite scrollbarPlate;

            /// <summary>
            /// The UI properties of the scrollbar.
            /// </summary>
            public SelectableProperties overflowScrollbar;

            /// <summary>
            /// The width of the vertical overflow scrollbar.
            /// </summary>
            public float scrollbarWidth = 50.0f;

            /// <summary>
            /// The mouse wheel sensitivity for the overflow scrollbar.
            /// </summary>
            public float scrollSensitivity = 50.0f;

            /// <summary>
            /// The default alignment of menu item labels.
            /// </summary>
            public TextAlignment defaultTextAlignment;

            /// <summary>
            /// If true, submenus have a go-back buttons. Go-back buttons are useful if you
            /// beleive the dropdown menus may take up so much screen space that the use may
            /// not have blank areas to click to cancel menus.
            /// </summary>
            public bool useGoBack = true;

            /// <summary>
            /// The icon for the go-back button.
            /// </summary>
            public Sprite goBackIcon;

            /// <summary>
            /// The text size for the go-back button.
            /// </summary>
            public int goBackFontSize;

            /// <summary>
            /// The label for the go-back buttons.
            /// </summary>
            public string goBackMessage = "Go Back";

            /// <summary>
            /// Given a TextAlignment value, convert it into a TextAnchor.
            /// </summary>
            /// <param name="alignment">Dropdown menu text alignment to convert.</param>
            /// <param name="canDefault">
            /// If true, default values will convert to the Prop's defined default.
            /// Else an nonspecific constant value is used.</param>
            /// <returns>The converted Unity TextAnchor alighment.</returns>
            public TextAnchor GetTextAnchorFromAlignment(TextAlignment alignment, bool canDefault)
            { 
                switch(alignment)
                { 
                    case TextAlignment.Left:
                        return TextAnchor.MiddleLeft;

                    case TextAlignment.Middle:
                        return TextAnchor.MiddleCenter;

                    case TextAlignment.Right:
                        return TextAnchor.MiddleRight;

                    default:
                        if(canDefault == false)
                            return TextAnchor.MiddleLeft;

                        return GetTextAnchorFromAlignment(this.defaultTextAlignment, false);
                }
            }
        }
    }
}