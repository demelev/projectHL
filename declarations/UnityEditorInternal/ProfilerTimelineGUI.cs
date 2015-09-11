namespace UnityEditorInternal
{
    using System;
    using System.Collections.Generic;
    using UnityEditor;
    using UnityEngine;

    [Serializable]
    internal class ProfilerTimelineGUI
    {
        private const float kLineHeight = 16f;
        private const float kSmallWidth = 7f;
        private const float kTextFadeOutWidth = 20f;
        private const float kTextFadeStartWidth = 50f;
        private const float kTextLongWidth = 200f;
        private float m_SelectedDur;
        private int m_SelectedID = -1;
        private int m_SelectedThread;
        private float m_SelectedTime;
        [NonSerialized]
        private ZoomableArea m_TimeArea;
        private IProfilerWindowController m_Window;
        private static Styles ms_Styles;

        public ProfilerTimelineGUI(IProfilerWindowController window)
        {
            this.m_Window = window;
        }

        public void DoGUI(int frameIndex, float width, float ypos, float height)
        {
            Rect position = new Rect(0f, ypos - 1f, width, height + 1f);
            float num = 169f;
            if (Event.current.type == EventType.Repaint)
            {
                styles.profilerGraphBackground.Draw(position, false, false, false, false);
                EditorStyles.toolbar.Draw(new Rect(0f, (ypos + height) - 15f, num, 15f), false, false, false, false);
            }
            bool flag = false;
            if (this.m_TimeArea == null)
            {
                flag = true;
                this.m_TimeArea = new ZoomableArea();
                this.m_TimeArea.hRangeLocked = false;
                this.m_TimeArea.vRangeLocked = true;
                this.m_TimeArea.hSlider = true;
                this.m_TimeArea.vSlider = false;
                this.m_TimeArea.scaleWithWindow = true;
                this.m_TimeArea.rect = new Rect((position.x + num) - 1f, position.y, position.width - num, position.height);
                this.m_TimeArea.margin = 10f;
            }
            ProfilerFrameDataIterator iterator = new ProfilerFrameDataIterator();
            iterator.SetRoot(frameIndex, 0);
            this.m_TimeArea.hBaseRangeMin = 0f;
            this.m_TimeArea.hBaseRangeMax = iterator.frameTimeMS;
            if (flag)
            {
                this.PerformFrameSelected(iterator.frameTimeMS);
            }
            this.m_TimeArea.rect = new Rect(position.x + num, position.y, position.width - num, position.height);
            this.m_TimeArea.BeginViewGUI();
            this.m_TimeArea.EndViewGUI();
            position = this.m_TimeArea.drawRect;
            this.DrawBars(position, frameIndex);
            GUI.BeginClip(this.m_TimeArea.drawRect);
            position.x = 0f;
            position.y = 0f;
            int threadCount = 0;
            this.DoProfilerFrame(frameIndex, position, false, ref threadCount, 0f);
            bool enabled = GUI.enabled;
            GUI.enabled = false;
            int previousFrameIndex = ProfilerDriver.GetPreviousFrameIndex(frameIndex);
            if (previousFrameIndex != -1)
            {
                ProfilerFrameDataIterator iterator2 = new ProfilerFrameDataIterator();
                iterator2.SetRoot(previousFrameIndex, 0);
                this.DoProfilerFrame(previousFrameIndex, position, true, ref threadCount, -iterator2.frameTimeMS);
            }
            int nextFrameIndex = ProfilerDriver.GetNextFrameIndex(frameIndex);
            if (nextFrameIndex != -1)
            {
                ProfilerFrameDataIterator iterator3 = new ProfilerFrameDataIterator();
                iterator3.SetRoot(frameIndex, 0);
                this.DoProfilerFrame(nextFrameIndex, position, true, ref threadCount, iterator3.frameTimeMS);
            }
            GUI.enabled = enabled;
            GUI.EndClip();
        }

        private void DoProfilerFrame(int frameIndex, Rect fullRect, bool ghost, ref int threadCount, float offset)
        {
            ProfilerFrameDataIterator iter = new ProfilerFrameDataIterator();
            int num = iter.GetThreadCount(frameIndex);
            if (!ghost || (num == threadCount))
            {
                if (!ghost)
                {
                    threadCount = num;
                }
                for (int i = 0; i < threadCount; i++)
                {
                    Rect r = fullRect;
                    r.y = this.GetThreadY(fullRect, i, threadCount);
                    r.height = this.GetThreadY(fullRect, i + 1, threadCount) - r.y;
                    iter.SetRoot(frameIndex, i);
                    if ((i == 0) && !ghost)
                    {
                        this.DrawGrid(fullRect, threadCount, iter.frameTimeMS);
                        this.HandleFrameSelected(iter.frameTimeMS);
                    }
                    this.DrawProfilingData(iter, r, i, offset, ghost);
                }
            }
        }

        private void DrawBars(Rect r, int frameIndex)
        {
            ProfilerFrameDataIterator iterator = new ProfilerFrameDataIterator();
            iterator.SetRoot(frameIndex, 0);
            int threadCount = iterator.GetThreadCount(frameIndex);
            if (Event.current.type == EventType.Repaint)
            {
                for (int i = 0; i < threadCount; i++)
                {
                    iterator.SetRoot(frameIndex, i);
                    float y = this.GetThreadY(r, i, threadCount);
                    float height = this.GetThreadY(r, i + 1, threadCount) - y;
                    Rect position = new Rect(r.x - 170f, y, 170f, height);
                    Rect rect2 = new Rect(r.x, y, r.width, height);
                    styles.rightPane.Draw(rect2, false, false, false, false);
                    styles.leftPane.Draw(position, GUIContent.Temp(iterator.GetThreadName()), false, false, false, false);
                }
            }
        }

        private void DrawGrid(Rect r, int threadCount, float frameTime)
        {
            float num;
            float num3;
            float num2 = 16.66667f;
            HandleUtility.ApplyWireMaterial();
            GL.Begin(1);
            GL.Color(new Color(1f, 1f, 1f, 0.2f));
            for (num3 = num2; num3 <= frameTime; num3 += num2)
            {
                num = this.m_TimeArea.TimeToPixel(num3, r);
                GL.Vertex3(num, r.y, 0f);
                GL.Vertex3(num, r.y + r.height, 0f);
            }
            GL.Color(new Color(1f, 1f, 1f, 0.8f));
            num = this.m_TimeArea.TimeToPixel(0f, r);
            GL.Vertex3(num, r.y, 0f);
            GL.Vertex3(num, r.y + r.height, 0f);
            num = this.m_TimeArea.TimeToPixel(frameTime, r);
            GL.Vertex3(num, r.y, 0f);
            GL.Vertex3(num, r.y + r.height, 0f);
            GL.End();
            GUI.color = new Color(1f, 1f, 1f, 0.4f);
            for (num3 = 0f; num3 <= frameTime; num3 += num2)
            {
                Chart.DoLabel(this.m_TimeArea.TimeToPixel(num3, r) + 2f, r.yMax - 12f, string.Format("{0:f1}ms", num3), 0f);
            }
            GUI.color = new Color(1f, 1f, 1f, 1f);
            num3 = frameTime;
            Chart.DoLabel(this.m_TimeArea.TimeToPixel(num3, r) + 2f, r.yMax - 12f, string.Format("{0:f1}ms ({1:f0}FPS)", num3, 1000f / num3), 0f);
        }

        private void DrawProfilingData(ProfilerFrameDataIterator iter, Rect r, int threadIdx, float timeOffset, bool ghost)
        {
            float num = !ghost ? 7f : 21f;
            string selectedPropertyPath = ProfilerDriver.selectedPropertyPath;
            bool enterChildren = true;
            Color color = GUI.color;
            Color contentColor = GUI.contentColor;
            Color[] colors = ProfilerColors.colors;
            bool flag2 = false;
            float num2 = -1f;
            float num3 = -1f;
            float y = -1f;
            int size = 0;
            float num6 = -1f;
            string str2 = null;
            r.height--;
            GUI.BeginGroup(r);
            float num20 = 0f;
            r.y = num20;
            r.x = num20;
            bool flag3 = (Event.current.clickCount == 1) && (Event.current.type == EventType.MouseDown);
            bool flag4 = (Event.current.clickCount == 2) && (Event.current.type == EventType.MouseDown);
            Rect shownArea = this.m_TimeArea.shownArea;
            float rectWidthDivShownWidth = r.width / shownArea.width;
            float x = r.x;
            float shownX = shownArea.x;
            while (iter.Next(enterChildren))
            {
                enterChildren = true;
                float time = iter.startTimeMS + timeOffset;
                float durationMS = iter.durationMS;
                float num12 = Mathf.Max(durationMS, 0.0003f);
                float num13 = TimeToPixelCached(time, rectWidthDivShownWidth, shownX, x);
                float num14 = TimeToPixelCached(time + num12, rectWidthDivShownWidth, shownX, x) - 1f;
                float width = num14 - num13;
                if ((num13 > (r.x + r.width)) || (num14 < r.x))
                {
                    enterChildren = false;
                }
                else
                {
                    float num16 = iter.depth - 1;
                    float num17 = r.y + (num16 * 16f);
                    if (flag2)
                    {
                        bool flag5 = false;
                        if (width >= num)
                        {
                            flag5 = true;
                        }
                        if (y != num17)
                        {
                            flag5 = true;
                        }
                        if ((num13 - num3) > 6f)
                        {
                            flag5 = true;
                        }
                        if (flag5)
                        {
                            this.DrawSmallGroup(num2, num3, y, size);
                            flag2 = false;
                        }
                    }
                    if (width < num)
                    {
                        enterChildren = false;
                        if (!flag2)
                        {
                            flag2 = true;
                            y = num17;
                            num2 = num13;
                            size = 0;
                        }
                        num3 = num14;
                        size++;
                        continue;
                    }
                    int id = iter.id;
                    string path = iter.path;
                    bool flag6 = (path == selectedPropertyPath) && !ghost;
                    if (this.m_SelectedID >= 0)
                    {
                        flag6 &= id == this.m_SelectedID;
                    }
                    flag6 &= threadIdx == this.m_SelectedThread;
                    Color white = Color.white;
                    Color color4 = colors[iter.group % colors.Length];
                    color4.a = !flag6 ? 0.75f : 1f;
                    if (ghost)
                    {
                        color4.a = 0.4f;
                        white.a = 0.5f;
                    }
                    string name = iter.name;
                    if (flag6)
                    {
                        str2 = name;
                        this.m_SelectedTime = time;
                        this.m_SelectedDur = durationMS;
                        num6 = num17 + 16f;
                    }
                    if (width < 20f)
                    {
                        name = string.Empty;
                    }
                    else
                    {
                        if ((width < 50f) && !flag6)
                        {
                            white.a *= (width - 20f) / 30f;
                        }
                        if (width > 200f)
                        {
                            name = name + string.Format(" ({0:f2}ms)", durationMS);
                        }
                    }
                    GUI.color = color4;
                    GUI.contentColor = white;
                    Rect position = new Rect(num13, num17, width, 14f);
                    GUI.Label(position, name, styles.bar);
                    if ((flag3 || flag4) && position.Contains(Event.current.mousePosition))
                    {
                        this.m_Window.SetSelectedPropertyPath(path);
                        this.m_SelectedThread = threadIdx;
                        this.m_SelectedID = id;
                        UnityEngine.Object gameObject = EditorUtility.InstanceIDToObject(iter.instanceId);
                        if (gameObject is Component)
                        {
                            gameObject = ((Component) gameObject).gameObject;
                        }
                        if (gameObject != null)
                        {
                            if (flag3)
                            {
                                EditorGUIUtility.PingObject(gameObject.GetInstanceID());
                            }
                            else if (flag4)
                            {
                                Selection.objects = new List<UnityEngine.Object> { gameObject }.ToArray();
                            }
                        }
                        Event.current.Use();
                    }
                    flag2 = false;
                }
            }
            if (flag2)
            {
                this.DrawSmallGroup(num2, num3, y, size);
            }
            GUI.color = color;
            GUI.contentColor = contentColor;
            if ((str2 != null) && (threadIdx == this.m_SelectedThread))
            {
                Rect rect3;
                GUIContent content = new GUIContent(string.Format((this.m_SelectedDur < 1.0) ? "{0}\n{1:f3}ms" : "{0}\n{1:f2}ms", str2, this.m_SelectedDur));
                GUIStyle tooltip = styles.tooltip;
                Vector2 vector = tooltip.CalcSize(content);
                float num19 = this.m_TimeArea.TimeToPixel(this.m_SelectedTime + (this.m_SelectedDur * 0.5f), r);
                if (num19 < r.x)
                {
                    num19 = r.x + 20f;
                }
                if (num19 > r.xMax)
                {
                    num19 = r.xMax - 20f;
                }
                if (((num6 + 6f) + vector.y) < r.yMax)
                {
                    rect3 = new Rect(num19 - 32f, num6, 50f, 7f);
                    GUI.Label(rect3, GUIContent.none, styles.tooltipArrow);
                }
                rect3 = new Rect(num19, num6 + 6f, vector.x, vector.y);
                if (rect3.xMax > (r.xMax + 20f))
                {
                    rect3.x = (r.xMax - rect3.width) + 20f;
                }
                if (rect3.yMax > r.yMax)
                {
                    rect3.y = r.yMax - rect3.height;
                }
                if (rect3.y < r.y)
                {
                    rect3.y = r.y;
                }
                GUI.Label(rect3, content, tooltip);
            }
            if ((Event.current.type == EventType.MouseDown) && r.Contains(Event.current.mousePosition))
            {
                this.m_Window.ClearSelectedPropertyPath();
                this.m_SelectedID = -1;
                this.m_SelectedThread = threadIdx;
                Event.current.Use();
            }
            GUI.EndGroup();
        }

        private void DrawSmallGroup(float x1, float x2, float y, int size)
        {
            if ((x2 - x1) >= 1f)
            {
                GUI.color = new Color(0.5f, 0.5f, 0.5f, 0.7f);
                GUI.contentColor = Color.white;
                GUIContent none = GUIContent.none;
                if ((x2 - x1) > 20f)
                {
                    none = new GUIContent(size + " items");
                }
                GUI.Label(new Rect(x1, y, x2 - x1, 14f), none, styles.bar);
            }
        }

        private float GetThreadY(Rect r, int thread, int threadCount)
        {
            if (thread > 0)
            {
                thread += 2;
            }
            return (r.y + ((r.height / ((float) (threadCount + 2))) * thread));
        }

        private void HandleFrameSelected(float frameMS)
        {
            Event current = Event.current;
            if (((current.type == EventType.ValidateCommand) || (current.type == EventType.ExecuteCommand)) && (current.commandName == "FrameSelected"))
            {
                if (current.type == EventType.ExecuteCommand)
                {
                    this.PerformFrameSelected(frameMS);
                }
                current.Use();
            }
        }

        private void PerformFrameSelected(float frameMS)
        {
            float selectedTime = this.m_SelectedTime;
            float selectedDur = this.m_SelectedDur;
            if ((this.m_SelectedID < 0) || (selectedDur <= 0f))
            {
                selectedTime = 0f;
                selectedDur = frameMS;
            }
            this.m_TimeArea.SetShownHRangeInsideMargins(selectedTime - (selectedDur * 0.2f), selectedTime + (selectedDur * 1.2f));
        }

        private static float TimeToPixelCached(float time, float rectWidthDivShownWidth, float shownX, float rectX)
        {
            return (((time - shownX) * rectWidthDivShownWidth) + rectX);
        }

        private static Styles styles
        {
            get
            {
                if (ms_Styles == null)
                {
                }
                return (ms_Styles = new Styles());
            }
        }

        internal class Styles
        {
            public GUIStyle background = "OL Box";
            public GUIStyle bar = new GUIStyle(EditorStyles.miniButton);
            public GUIStyle leftPane = new GUIStyle("ProfilerLeftPane");
            public GUIStyle profilerGraphBackground = new GUIStyle("ProfilerScrollviewBackground");
            public GUIStyle rightPane = "ProfilerRightPane";
            public GUIStyle tooltip = "AnimationEventTooltip";
            public GUIStyle tooltipArrow = "AnimationEventTooltipArrow";

            internal Styles()
            {
                this.bar.margin = new RectOffset(0, 0, 0, 0);
                this.bar.padding = new RectOffset(0, 0, 0, 0);
                this.bar.border = new RectOffset(1, 1, 1, 1);
                Texture2D whiteTexture = EditorGUIUtility.whiteTexture;
                this.bar.active.background = whiteTexture;
                this.bar.hover.background = whiteTexture;
                this.bar.normal.background = whiteTexture;
                Color black = Color.black;
                this.bar.active.textColor = black;
                this.bar.hover.textColor = black;
                this.bar.normal.textColor = black;
                this.profilerGraphBackground.overflow.left = -169;
                this.leftPane.padding.left -= 40;
                this.leftPane.padding.top = 4;
            }
        }
    }
}

