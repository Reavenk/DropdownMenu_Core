using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PxPre
{
    namespace DropMenu
    {
        public class DropMenuSpawner : MonoBehaviour
        {
            public struct NodeCreationCache
            {
                public UnityEngine.UI.Image plate;
                public UnityEngine.UI.Text text;
                public UnityEngine.UI.Image arrow;
                public UnityEngine.UI.Image icon;
                public float height;
            }

            private class NodeContext
            { 
                public Node menu;
                public UnityEngine.UI.Image plate;
                public UnityEngine.UI.Image shadow;
                public SpawnContext spawnContext;
                public int depth;
            }

            private struct DropdownCreationReturn
            { 
                public Node node;
                public RectTransform rtMain;
                public RectTransform rtShadow;

                public DropdownCreationReturn(Node node, RectTransform rtMain, RectTransform rtShadow)
                { 
                    this.node = node;
                    this.rtMain = rtMain;
                    this.rtShadow = rtShadow;
                }
            }

            private class SpawnContext
            { 
                public List<NodeContext> spawnedSubmenus;
                public RectTransform modalPlate;
                public DropMenuSpawner spawner;
                
                public SpawnContext(DropMenuSpawner spawner)
                { 
                    this.spawner = spawner;
                }

                public void BreakDown(int depth)
                {
                    while(spawnedSubmenus.Count >= depth + 1)
                    { 
                        int lastIdx = spawnedSubmenus.Count - 1;
                        NodeContext nc = spawnedSubmenus[lastIdx];
                        GameObject.Destroy(nc.plate.gameObject);
                        GameObject.Destroy(nc.shadow.gameObject);

                        spawnedSubmenus.RemoveAt(lastIdx);
                    }
                }

                public void Destroy()
                { 
                    GameObject.Destroy(this.modalPlate.gameObject);
                }

                public void SpawnSubmenu(RectTransform rt, Node node, int depth)
                { 
                    this.spawner.CreateSubMenu(this, rt, node, depth);
                }
            }

            public Props props;

            public RectTransform CreateMenu(Canvas canvas, Vector2 pos)
            { 
                return null;
            }

            private RectTransform CreateModalPlate(Canvas canvas, SpawnContext sc)
            {
                GameObject goMP = new GameObject("ModalPlate");
                goMP.transform.SetParent(canvas.transform);
                goMP.transform.localScale = Vector3.one;
                goMP.transform.localRotation = Quaternion.identity;
                UnityEngine.UI.Image imgBP = goMP.AddComponent<UnityEngine.UI.Image>();
                imgBP.color = props.modalPlateColor;
                RectTransform rtBP = imgBP.rectTransform;
                rtBP.anchorMin = Vector2.zero;
                rtBP.anchorMax = Vector2.one;
                rtBP.offsetMin = Vector2.zero;
                rtBP.offsetMax = Vector2.zero;
                rtBP.pivot = new Vector2(0.0f, 1.0f);
                UnityEngine.EventSystems.EventTrigger tMP = goMP.AddComponent<UnityEngine.EventSystems.EventTrigger>();
                tMP.triggers = new List<UnityEngine.EventSystems.EventTrigger.Entry>();
                UnityEngine.EventSystems.EventTrigger.Entry mpClickExit = new UnityEngine.EventSystems.EventTrigger.Entry();
                mpClickExit.eventID = UnityEngine.EventSystems.EventTriggerType.PointerDown;
                mpClickExit.callback = new UnityEngine.EventSystems.EventTrigger.TriggerEvent();
                mpClickExit.callback.AddListener((x) => { sc.Destroy(); });
                tMP.triggers.Add(mpClickExit);

                return rtBP;
            }

            public RectTransform CreateDropdownMenu(Canvas canvas, Node menu, RectTransform rt)
            {

                SpawnContext sc = new SpawnContext(this);

                RectTransform parent = this.CreateModalPlate(canvas, sc);
                sc.modalPlate = parent;


                Vector3 [] corners = new Vector3[4];
                rt.GetWorldCorners(corners);
                DropdownCreationReturn dcr = CreateDropdownMenu(sc, parent, menu, corners[0], 0);

                return parent;
            }

            private DropdownCreationReturn CreateSubMenu(SpawnContext sc, RectTransform relevantRect, Node node, int depth)
            { 
                Vector3 [] rcc = new Vector3[4];
                relevantRect.GetWorldCorners(rcc);

                return this.CreateDropdownMenu( sc, sc.modalPlate, node, rcc[2], depth);
            }


            private DropdownCreationReturn CreateDropdownMenu(SpawnContext sc, RectTransform parent, Node node, Vector3 loc, int depth)
            {
                
                GameObject goMenu = new GameObject("Menu");
                goMenu.transform.SetParent(parent);
                UnityEngine.UI.Image imgMenu = goMenu.AddComponent<UnityEngine.UI.Image>();
                imgMenu.sprite = this.props.plate;
                imgMenu.type = UnityEngine.UI.Image.Type.Sliced;
                RectTransform rtMenu = imgMenu.rectTransform;
                rtMenu.pivot = new Vector2(0.0f, 1.0f);
                rtMenu.anchorMin = new Vector2(0.0f, 1.0f);
                rtMenu.anchorMax = new Vector2(0.0f, 1.0f);
                rtMenu.position = loc;

                GameObject goShadow = new GameObject("Shadow");
                goShadow.transform.SetParent(parent);
                UnityEngine.UI.Image imgShadow = goShadow.AddComponent<UnityEngine.UI.Image>();
                imgShadow.sprite = this.props.shadow;
                imgShadow.type = UnityEngine.UI.Image.Type.Sliced;
                RectTransform rtShadow = imgShadow.rectTransform;
                rtShadow.pivot = new Vector2(0.0f, 1.0f);
                rtShadow.anchorMin = new Vector2(0.0f, 1.0f);
                rtShadow.anchorMax = new Vector2(0.0f, 1.0f);

                float maxXIco = 0.0f;
                float maxXLabel = 0.0f;
                float maxXSpawnArrow = 0.0f;

                bool atleastOne = false;

                bool ico = false;
                bool arrow = false;

                // Create assets and get total size values
                List< NodeCreationCache> childrenCreationCache = new List<NodeCreationCache>();
                foreach (Node n in node.children)
                {
                    float fyMax = 0.0f;

                    NodeCreationCache ncc = new NodeCreationCache();
                    if (n.type == Node.Type.Action || n.type == Node.Type.Menu)
                    {   
                        GameObject goEntry = new GameObject("Entry");
                        goEntry.transform.SetParent(goMenu.transform);
                        goEntry.transform.localRotation = Quaternion.identity;
                        goEntry.transform.localScale = Vector3.one;
                        UnityEngine.UI.Image imgEntry = goEntry.AddComponent<UnityEngine.UI.Image>();
                        imgEntry.sprite = this.props.entrySprite;
                        imgEntry.rectTransform.anchorMin = new Vector2(0.0f, 1.0f);
                        imgEntry.rectTransform.anchorMax = new Vector2(0.0f, 1.0f);
                        imgEntry.rectTransform.pivot = new Vector2(0.0f, 1.0f);
                        imgEntry.type = UnityEngine.UI.Image.Type.Sliced;

                        ncc.plate = imgEntry;

                        GameObject goText = new GameObject("Text");
                        goText.transform.SetParent(goEntry.transform);
                        goText.transform.localRotation = Quaternion.identity;
                        goText.transform.localScale = Vector3.one;
                        UnityEngine.UI.Text txtText = goText.AddComponent<UnityEngine.UI.Text>();
                        txtText.color = this.props.entryFontColor;
                        txtText.fontSize = this.props.entryFontSize;
                        txtText.font = this.props.entryFont;
                        txtText.text = n.label;
                        txtText.rectTransform.anchorMin = new Vector2(0.0f, 0.0f);
                        txtText.rectTransform.anchorMax = new Vector2(1.0f, 1.0f);
                        txtText.rectTransform.pivot = new Vector2(0.0f, 0.5f);
                        txtText.alignment = TextAnchor.MiddleCenter;
                        TextGenerationSettings tgs = txtText.GetGenerationSettings(new Vector2(float.PositiveInfinity, float.PositiveInfinity));
                        TextGenerator tg = txtText.cachedTextGenerator;
                        Vector2 textSz = 
                            new Vector2(
                                tg.GetPreferredWidth(txtText.text, tgs), 
                                tg.GetPreferredHeight(txtText.text, tgs));
                        txtText.rectTransform.sizeDelta = textSz;
                        //
                        maxXLabel = Mathf.Max(maxXLabel, textSz.x);
                        fyMax = Mathf.Max(fyMax, textSz.y, this.props.minEntrySize);
                        //
                        ncc.text = txtText;

                        if(n.type == Node.Type.Action)
                        { 
                            UnityEngine.UI.Button actionBtn = goEntry.AddComponent<UnityEngine.UI.Button>();
                            actionBtn.targetGraphic = ncc.plate;
                            actionBtn.onClick.AddListener(
                                ()=>
                                { 
                                    System.Action a = n.action; 
                                    sc.Destroy();

                                    if(a != null)
                                        a();
                                });
                        }
                        else if(n.type == Node.Type.Menu)
                        { 
                            // Do nothing with the button. We're just leveraging the 
                            // hover-over animations.
                            UnityEngine.UI.Button menuBtn = goEntry.AddComponent<UnityEngine.UI.Button>();
                            menuBtn.targetGraphic = ncc.plate;

                            UnityEngine.EventSystems.EventTrigger menuTrig = goEntry.AddComponent<UnityEngine.EventSystems.EventTrigger>();
                            menuTrig.triggers = new List<UnityEngine.EventSystems.EventTrigger.Entry>();

                            UnityEngine.EventSystems.EventTrigger.Entry hoverTrig = new UnityEngine.EventSystems.EventTrigger.Entry();
                            hoverTrig.eventID = UnityEngine.EventSystems.EventTriggerType.PointerEnter;
                            hoverTrig.callback = new UnityEngine.EventSystems.EventTrigger.TriggerEvent();
                            hoverTrig.callback.AddListener(
                                (x)=>
                                {
                                    Node nCpy = n;
                                    sc.SpawnSubmenu(
                                        imgEntry.rectTransform,
                                        nCpy,
                                        depth + 1);

                                });

                            menuTrig.triggers.Add(hoverTrig);
                        }

                        ncc.text = txtText;

                        if (n.sprite != null)
                        { 
                            Vector2 v2Ico = n.sprite.rect.size;

                            GameObject goIcon = new GameObject("Icon");
                            goIcon.transform.SetParent(goEntry.transform);
                            goIcon.transform.localRotation = Quaternion.identity;
                            goIcon.transform.localScale = Vector3.one;
                            UnityEngine.UI.Image imgIcon = goIcon.AddComponent<UnityEngine.UI.Image>();
                            imgIcon.sprite = n.sprite;
                            imgIcon.rectTransform.anchorMin = new Vector2(0.0f, 1.0f);
                            imgIcon.rectTransform.anchorMax = new Vector2(0.0f, 1.0f);
                            imgIcon.rectTransform.pivot = new Vector2(0.0f, 1.0f);
                            imgIcon.rectTransform.sizeDelta = v2Ico;

                            ncc.icon = imgIcon;

                            maxXIco = Mathf.Max(v2Ico.x, maxXIco);
                            fyMax   = Mathf.Max(v2Ico.y, fyMax);

                            ico = true;
                        }

                        if(n.type == Node.Type.Menu)
                        {
                            Vector2 v2Arrow = this.props.submenuSpawnArrow.rect.size;

                            GameObject goArrow = new GameObject("Arrow");
                            goArrow.transform.SetParent(goEntry.transform);
                            goArrow.transform.localRotation = Quaternion.identity;
                            goArrow.transform.localScale = Vector3.one;
                            UnityEngine.UI.Image imgArrow = goArrow.AddComponent<UnityEngine.UI.Image>();
                            imgArrow.sprite = this.props.submenuSpawnArrow;
                            imgArrow.rectTransform.anchorMin = new Vector2(0.0f, 1.0f);
                            imgArrow.rectTransform.anchorMax = new Vector2(0.0f, 1.0f);
                            imgArrow.rectTransform.pivot = new Vector2(0.0f, 1.0f);
                            imgArrow.rectTransform.sizeDelta = v2Arrow;

                            ncc.arrow = imgArrow;

                            maxXSpawnArrow = Mathf.Max(maxXSpawnArrow, v2Arrow.x);
                            fyMax = Mathf.Max(fyMax, v2Arrow.y);

                            arrow = true;
                        }

                        fyMax += this.props.entryPadding.left + this.props.entryPadding.right;
                        ncc.height = fyMax;
                    }
                    else if(n.type == Node.Type.Separator)
                    { 
                        float stotalX = this.props.minSplitter + this.props.splitterPadding.left + this.props.splitterPadding.right;
                        float stotalY = this.props.splitter.rect.height + this.props.splitterPadding.top + this.props.splitterPadding.bottom;

                        GameObject goSep = new GameObject("Separator");
                        goSep.transform.SetParent(goMenu.transform);
                        goSep.transform.localRotation = Quaternion.identity;
                        goSep.transform.localScale = Vector3.one;
                        UnityEngine.UI.Image imgSpe = goSep.AddComponent<UnityEngine.UI.Image>();
                        imgSpe.sprite = this.props.splitter;
                        imgSpe.type = UnityEngine.UI.Image.Type.Sliced;
                        imgSpe.rectTransform.anchorMin = new Vector2(0.0f, 1.0f);
                        imgSpe.rectTransform.anchorMax = new Vector2(0.0f, 1.0f);
                        imgSpe.rectTransform.pivot = new Vector2(0.0f, 1.0f);

                        ncc.plate = imgSpe;

                        ncc.height = 
                            this.props.splitterPadding.top + 
                            this.props.splitterPadding.bottom + 
                            this.props.splitter.rect.height;
                    }
                    else
                    { 
                        // TODO: Error
                        continue;
                    }

                    childrenCreationCache.Add(ncc);
                }

                // Layout internals
                float fY = this.props.entryPadding.top;

                float fX = this.props.entryPadding.left;
                float xIcoStart = fX;
                float xTextStart = fX + maxXIco;
                if(maxXIco == 0.0f)
                    xTextStart += this.props.textArrowPadding;

                float xArrowIco = xTextStart + maxXLabel;
                if(maxXSpawnArrow != 0.0f)
                    xArrowIco += this.props.textArrowPadding;

                float xWidth = xArrowIco + maxXSpawnArrow + this.props.splitterPadding.right;

                float xTextFromRight = this.props.splitterPadding.right;
                if(xArrowIco > 0.0f)
                    xTextFromRight += maxXSpawnArrow + this.props.textArrowPadding;

                atleastOne = false;
                for(int i = 0; i < node.children.Count; ++i)
                {
                    Node n = node.children[i];
                    NodeCreationCache ccache = childrenCreationCache[i];

                    if(atleastOne == false)
                        atleastOne = true;
                    else
                        fY += this.props.childrenSpacing;

                    float height = 
                        ccache.height - 
                        this.props.entryPadding.top - 
                        this.props.entryPadding.bottom;

                    if (n.type == Node.Type.Action || n.type == Node.Type.Menu)
                    {
                        ccache.plate.rectTransform.anchoredPosition = 
                            new Vector2(
                                fX, 
                                -fY);

                        ccache.plate.rectTransform.sizeDelta = 
                            new Vector2(
                                xWidth, ccache.height);

                        ccache.text.rectTransform.offsetMin = new Vector2(xTextStart, this.props.entryPadding.bottom);
                        ccache.text.rectTransform.offsetMax = new Vector2(-xTextFromRight, -this.props.entryPadding.top);

                        if(ccache.icon != null)
                        { 
                            ccache.icon.rectTransform.anchoredPosition = 
                                new Vector2(
                                    xIcoStart + (maxXIco - ccache.icon.sprite.rect.width) * 0.5f,
                                    -this.props.entryPadding.top - (height - ccache.icon.sprite.rect.height) * 0.5f);
                        }

                        if(ccache.arrow != null)
                        {
                            ccache.arrow.rectTransform.anchoredPosition = 
                                new Vector2(
                                    xArrowIco + (maxXSpawnArrow - ccache.arrow.sprite.rect.width) * 0.5f,
                                    -this.props.entryPadding.top - (height - ccache.arrow.sprite.rect.height) * 0.5f);
                        }

                        fY += ccache.height;
                    }
                    else if(n.type == Node.Type.Separator)
                    {
                        ccache.plate.rectTransform.anchoredPosition = 
                            new Vector2(fX + this.props.splitterPadding.left, -fY - this.props.splitterPadding.top );

                        ccache.plate.rectTransform.sizeDelta = 
                            new Vector2( 
                                xWidth - 
                                this.props.splitterPadding.left - 
                                this.props.splitterPadding.right, 
                                this.props.splitter.rect.height );

                        fY += ccache.height;
                    }
                }

                fY += this.props.outerPadding.bottom;
                rtMenu.sizeDelta = 
                    new Vector2(
                        xWidth + this.props.outerPadding.left + this.props.outerPadding.right, fY);

                // Layout plate

                rtShadow.sizeDelta = rtMenu.sizeDelta;
                rtShadow.anchoredPosition = rtMenu.anchoredPosition + this.props.shadowOffset;
                //
                rtShadow.SetAsLastSibling();
                rtMenu.SetAsLastSibling();

                return new DropdownCreationReturn(
                    node,
                    rtMenu,
                    rtShadow);
            }
        }
    }
}