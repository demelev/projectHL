using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

internal class AssemblyValidation
{
    private static Dictionary<RuntimePlatform, List<System.Type>> _rulesByPlatform;
    [CompilerGenerated]
    private static Func<IValidationRule, bool> <>f__am$cache1;
    [CompilerGenerated]
    private static Func<object, System.Type> <>f__am$cache2;
    [CompilerGenerated]
    private static Func<AssemblyValidationRule, int> <>f__am$cache3;

    internal static int CompareValidationRulesByPriority(System.Type a, System.Type b, RuntimePlatform platform)
    {
        int num = PriorityFor(a, platform);
        int num2 = PriorityFor(b, platform);
        if (num == num2)
        {
            return 0;
        }
        return ((num >= num2) ? 1 : -1);
    }

    private static ConstructorInfo ConstructorFor(System.Type type, IEnumerable<object> options)
    {
        if (<>f__am$cache2 == null)
        {
            <>f__am$cache2 = o => o.GetType();
        }
        System.Type[] types = options.Select<object, System.Type>(<>f__am$cache2).ToArray<System.Type>();
        return type.GetConstructor(types);
    }

    private static IValidationRule CreateValidationRuleWithOptions(System.Type type, params object[] options)
    {
        List<object> list = new List<object>(options);
        while (true)
        {
            object[] objArray = list.ToArray();
            ConstructorInfo info = ConstructorFor(type, objArray);
            if (info != null)
            {
                return (IValidationRule) info.Invoke(objArray);
            }
            if (list.Count == 0)
            {
                return null;
            }
            list.RemoveAt(list.Count - 1);
        }
    }

    private static bool IsValidationRule(System.Type type)
    {
        return ValidationRuleAttributesFor(type).Any<AssemblyValidationRule>();
    }

    private static int PriorityFor(System.Type type, RuntimePlatform platform)
    {
        <PriorityFor>c__AnonStorey60 storey = new <PriorityFor>c__AnonStorey60 {
            platform = platform
        };
        if (<>f__am$cache3 == null)
        {
            <>f__am$cache3 = attr => attr.Priority;
        }
        return ValidationRuleAttributesFor(type).Where<AssemblyValidationRule>(new Func<AssemblyValidationRule, bool>(storey.<>m__C2)).Select<AssemblyValidationRule, int>(<>f__am$cache3).FirstOrDefault<int>();
    }

    internal static void RegisterValidationRule(System.Type type)
    {
        IEnumerator<AssemblyValidationRule> enumerator = ValidationRuleAttributesFor(type).GetEnumerator();
        try
        {
            while (enumerator.MoveNext())
            {
                AssemblyValidationRule current = enumerator.Current;
                RegisterValidationRuleForPlatform(current.Platform, type);
            }
        }
        finally
        {
            if (enumerator == null)
            {
            }
            enumerator.Dispose();
        }
    }

    internal static void RegisterValidationRuleForPlatform(RuntimePlatform platform, System.Type type)
    {
        <RegisterValidationRuleForPlatform>c__AnonStorey5F storeyf = new <RegisterValidationRuleForPlatform>c__AnonStorey5F {
            platform = platform
        };
        if (!_rulesByPlatform.ContainsKey(storeyf.platform))
        {
            _rulesByPlatform[storeyf.platform] = new List<System.Type>();
        }
        if (_rulesByPlatform[storeyf.platform].IndexOf(type) == -1)
        {
            _rulesByPlatform[storeyf.platform].Add(type);
        }
        _rulesByPlatform[storeyf.platform].Sort(new Comparison<System.Type>(storeyf.<>m__C1));
    }

    public static ValidationResult Validate(RuntimePlatform platform, IEnumerable<string> userAssemblies, params object[] options)
    {
        string[] strArray;
        WarmUpRulesCache();
        string[] textArray1 = userAssemblies as string[];
        if (textArray1 != null)
        {
            strArray = textArray1;
        }
        else
        {
            strArray = userAssemblies.ToArray<string>();
        }
        if (strArray.Length != 0)
        {
            IEnumerator<IValidationRule> enumerator = ValidationRulesFor(platform, options).GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    ValidationResult result = enumerator.Current.Validate(strArray, options);
                    if (!result.Success)
                    {
                        return result;
                    }
                }
            }
            finally
            {
                if (enumerator == null)
                {
                }
                enumerator.Dispose();
            }
        }
        return new ValidationResult { Success = true };
    }

    private static IEnumerable<AssemblyValidationRule> ValidationRuleAttributesFor(System.Type type)
    {
        return type.GetCustomAttributes(true).OfType<AssemblyValidationRule>();
    }

    private static IEnumerable<IValidationRule> ValidationRulesFor(RuntimePlatform platform, params object[] options)
    {
        <ValidationRulesFor>c__AnonStorey5E storeye = new <ValidationRulesFor>c__AnonStorey5E {
            options = options
        };
        if (<>f__am$cache1 == null)
        {
            <>f__am$cache1 = v => v != null;
        }
        return ValidationRuleTypesFor(platform).Select<System.Type, IValidationRule>(new Func<System.Type, IValidationRule>(storeye.<>m__BE)).Where<IValidationRule>(<>f__am$cache1);
    }

    [DebuggerHidden]
    private static IEnumerable<System.Type> ValidationRuleTypesFor(RuntimePlatform platform)
    {
        return new <ValidationRuleTypesFor>c__Iterator5 { platform = platform, <$>platform = platform, $PC = -2 };
    }

    private static void WarmUpRulesCache()
    {
        if (_rulesByPlatform == null)
        {
            _rulesByPlatform = new Dictionary<RuntimePlatform, List<System.Type>>();
            IEnumerator<System.Type> enumerator = typeof(AssemblyValidation).Assembly.GetTypes().Where<System.Type>(new Func<System.Type, bool>(AssemblyValidation.IsValidationRule)).GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    System.Type current = enumerator.Current;
                    RegisterValidationRule(current);
                }
            }
            finally
            {
                if (enumerator == null)
                {
                }
                enumerator.Dispose();
            }
        }
    }

    [CompilerGenerated]
    private sealed class <PriorityFor>c__AnonStorey60
    {
        internal RuntimePlatform platform;

        internal bool <>m__C2(AssemblyValidationRule attr)
        {
            return (attr.Platform == this.platform);
        }
    }

    [CompilerGenerated]
    private sealed class <RegisterValidationRuleForPlatform>c__AnonStorey5F
    {
        internal RuntimePlatform platform;

        internal int <>m__C1(System.Type a, System.Type b)
        {
            return AssemblyValidation.CompareValidationRulesByPriority(a, b, this.platform);
        }
    }

    [CompilerGenerated]
    private sealed class <ValidationRulesFor>c__AnonStorey5E
    {
        internal object[] options;

        internal IValidationRule <>m__BE(System.Type t)
        {
            return AssemblyValidation.CreateValidationRuleWithOptions(t, this.options);
        }
    }

    [CompilerGenerated]
    private sealed class <ValidationRuleTypesFor>c__Iterator5 : IDisposable, IEnumerable, IEnumerator, IEnumerable<System.Type>, IEnumerator<System.Type>
    {
        internal System.Type $current;
        internal int $PC;
        internal RuntimePlatform <$>platform;
        internal List<System.Type>.Enumerator <$s_810>__0;
        internal System.Type <validationType>__1;
        internal RuntimePlatform platform;

        [DebuggerHidden]
        public void Dispose()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            switch (num)
            {
                case 1:
                    try
                    {
                    }
                    finally
                    {
                        this.<$s_810>__0.Dispose();
                    }
                    break;
            }
        }

        public bool MoveNext()
        {
            uint num = (uint) this.$PC;
            this.$PC = -1;
            bool flag = false;
            switch (num)
            {
                case 0:
                    if (AssemblyValidation._rulesByPlatform.ContainsKey(this.platform))
                    {
                        this.<$s_810>__0 = AssemblyValidation._rulesByPlatform[this.platform].GetEnumerator();
                        num = 0xfffffffd;
                        break;
                    }
                    goto Label_00C8;

                case 1:
                    break;

                default:
                    goto Label_00C8;
            }
            try
            {
                while (this.<$s_810>__0.MoveNext())
                {
                    this.<validationType>__1 = this.<$s_810>__0.Current;
                    this.$current = this.<validationType>__1;
                    this.$PC = 1;
                    flag = true;
                    return true;
                }
            }
            finally
            {
                if (!flag)
                {
                }
                this.<$s_810>__0.Dispose();
            }
            this.$PC = -1;
        Label_00C8:
            return false;
        }

        [DebuggerHidden]
        public void Reset()
        {
            throw new NotSupportedException();
        }

        [DebuggerHidden]
        IEnumerator<System.Type> IEnumerable<System.Type>.GetEnumerator()
        {
            if (Interlocked.CompareExchange(ref this.$PC, 0, -2) == -2)
            {
                return this;
            }
            return new AssemblyValidation.<ValidationRuleTypesFor>c__Iterator5 { platform = this.<$>platform };
        }

        [DebuggerHidden]
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.System.Collections.Generic.IEnumerable<System.Type>.GetEnumerator();
        }

        System.Type IEnumerator<System.Type>.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }

        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return this.$current;
            }
        }
    }
}

