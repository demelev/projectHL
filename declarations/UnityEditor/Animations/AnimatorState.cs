﻿namespace UnityEditor.Animations
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using UnityEditor;
    using UnityEngine;
    using UnityEngineInternal;

    public sealed class AnimatorState : UnityEngine.Object
    {
        private PushUndoIfNeeded undoHandler = new PushUndoIfNeeded(true);

        public AnimatorState()
        {
            Internal_Create(this);
        }

        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        internal extern void AddBehaviour(int instanceID);
        public AnimatorStateTransition AddExitTransition()
        {
            AnimatorStateTransition transition = this.AddTransition();
            transition.isExit = true;
            return transition;
        }

        public AnimatorStateTransition AddExitTransition(bool defaultExitTime)
        {
            AnimatorStateTransition newTransition = this.AddTransition();
            newTransition.isExit = true;
            if (defaultExitTime)
            {
                this.SetDefaultTransitionExitTime(ref newTransition);
            }
            return newTransition;
        }

        public T AddStateMachineBehaviour<T>() where T: StateMachineBehaviour
        {
            return (this.AddStateMachineBehaviour(typeof(T)) as T);
        }

        [TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
        public StateMachineBehaviour AddStateMachineBehaviour(System.Type stateMachineBehaviourType)
        {
            return (StateMachineBehaviour) this.Internal_AddStateMachineBehaviourWithType(stateMachineBehaviourType);
        }

        private AnimatorStateTransition AddTransition()
        {
            AnimatorStateTransition objectToAdd = new AnimatorStateTransition {
                hasExitTime = false,
                hasFixedDuration = true
            };
            if (AssetDatabase.GetAssetPath(this) != string.Empty)
            {
                AssetDatabase.AddObjectToAsset(objectToAdd, AssetDatabase.GetAssetPath(this));
            }
            objectToAdd.hideFlags = HideFlags.HideInHierarchy;
            this.AddTransition(objectToAdd);
            return objectToAdd;
        }

        public AnimatorStateTransition AddTransition(AnimatorState destinationState)
        {
            AnimatorStateTransition transition = this.AddTransition();
            transition.destinationState = destinationState;
            return transition;
        }

        public AnimatorStateTransition AddTransition(AnimatorStateMachine destinationStateMachine)
        {
            AnimatorStateTransition transition = this.AddTransition();
            transition.destinationStateMachine = destinationStateMachine;
            return transition;
        }

        public void AddTransition(AnimatorStateTransition transition)
        {
            this.undoHandler.DoUndo(this, "Transition added");
            AnimatorStateTransition[] transitions = this.transitions;
            ArrayUtility.Add<AnimatorStateTransition>(ref transitions, transition);
            this.transitions = transitions;
        }

        public AnimatorStateTransition AddTransition(AnimatorState destinationState, bool defaultExitTime)
        {
            AnimatorStateTransition newTransition = this.AddTransition(destinationState);
            if (defaultExitTime)
            {
                this.SetDefaultTransitionExitTime(ref newTransition);
            }
            return newTransition;
        }

        public AnimatorStateTransition AddTransition(AnimatorStateMachine destinationStateMachine, bool defaultExitTime)
        {
            AnimatorStateTransition newTransition = this.AddTransition(destinationStateMachine);
            if (defaultExitTime)
            {
                this.SetDefaultTransitionExitTime(ref newTransition);
            }
            return newTransition;
        }

        internal AnimatorStateMachine FindParent(AnimatorStateMachine root)
        {
            if (root.HasState(this, false))
            {
                return root;
            }
            return root.stateMachinesRecursive.Find(sm => sm.stateMachine.HasState(this, false)).stateMachine;
        }

        internal AnimatorStateTransition FindTransition(AnimatorState destinationState)
        {
            <FindTransition>c__AnonStorey10 storey = new <FindTransition>c__AnonStorey10 {
                destinationState = destinationState
            };
            return new List<AnimatorStateTransition>(this.transitions).Find(new Predicate<AnimatorStateTransition>(storey.<>m__14));
        }

        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        internal extern MonoScript GetBehaviourMonoScript(int index);
        [Obsolete("GetMotion() is obsolete. Use motion", true)]
        public Motion GetMotion()
        {
            return null;
        }

        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        private extern ScriptableObject Internal_AddStateMachineBehaviourWithType(System.Type stateMachineBehaviourType);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        private static extern void Internal_Create(AnimatorState mono);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        internal extern void RemoveBehaviour(int index);
        public void RemoveTransition(AnimatorStateTransition transition)
        {
            this.undoHandler.DoUndo(this, "Transition removed");
            AnimatorStateTransition[] transitions = this.transitions;
            ArrayUtility.Remove<AnimatorStateTransition>(ref transitions, transition);
            this.transitions = transitions;
            if (MecanimUtilities.AreSameAsset(this, transition))
            {
                Undo.DestroyObjectImmediate(transition);
            }
        }

        private void SetDefaultTransitionExitTime(ref AnimatorStateTransition newTransition)
        {
            newTransition.hasExitTime = true;
            if ((this.motion != null) && (this.motion.averageDuration > 0f))
            {
                float num2 = 0.25f / this.motion.averageDuration;
                newTransition.duration = !newTransition.hasFixedDuration ? num2 : 0.25f;
                newTransition.exitTime = 1f - num2;
            }
        }

        public StateMachineBehaviour[] behaviours { [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall] get; [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall] set; }

        public float cycleOffset { [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall] get; [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall] set; }

        public string cycleOffsetParameter { [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall] get; [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall] set; }

        public bool cycleOffsetParameterActive { [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall] get; [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall] set; }

        public bool iKOnFeet { [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall] get; [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall] set; }

        public bool mirror { [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall] get; [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall] set; }

        public string mirrorParameter { [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall] get; [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall] set; }

        public bool mirrorParameterActive { [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall] get; [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall] set; }

        public Motion motion { [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall] get; [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall] set; }

        public int nameHash { [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall] get; }

        internal bool pushUndo
        {
            set
            {
                this.undoHandler.pushUndo = value;
            }
        }

        public float speed { [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall] get; [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall] set; }

        public string speedParameter { [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall] get; [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall] set; }

        public bool speedParameterActive { [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall] get; [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall] set; }

        public string tag { [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall] get; [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall] set; }

        public AnimatorStateTransition[] transitions { [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall] get; [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall] set; }

        [Obsolete("uniqueName does not exist anymore. Consider using .name instead.", true)]
        public string uniqueName
        {
            get
            {
                return string.Empty;
            }
        }

        [Obsolete("uniqueNameHash does not exist anymore.", true)]
        public int uniqueNameHash
        {
            get
            {
                return -1;
            }
        }

        public bool writeDefaultValues { [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall] get; [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall] set; }

        [CompilerGenerated]
        private sealed class <FindTransition>c__AnonStorey10
        {
            internal AnimatorState destinationState;

            internal bool <>m__14(AnimatorStateTransition t)
            {
                return (t.destinationState == this.destinationState);
            }
        }
    }
}

