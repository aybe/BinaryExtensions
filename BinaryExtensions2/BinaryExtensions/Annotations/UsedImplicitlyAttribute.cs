﻿using System;
using System.Diagnostics;

namespace BinaryExtensions.Annotations
{
    /// <summary>
    ///     Indicates that the marked symbol is used implicitly (e.g. via reflection, in external library),
    ///     so this symbol will not be marked as unused (as well as by other usage inspections).
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    [Conditional("JETBRAINS_ANNOTATIONS")]
    internal sealed class UsedImplicitlyAttribute : Attribute
    {
        public UsedImplicitlyAttribute()
            : this(ImplicitUseKindFlags.Default, ImplicitUseTargetFlags.Default)
        {
        }

        public UsedImplicitlyAttribute(ImplicitUseKindFlags useKindFlags)
            : this(useKindFlags, ImplicitUseTargetFlags.Default)
        {
        }

        public UsedImplicitlyAttribute(ImplicitUseTargetFlags targetFlags)
            : this(ImplicitUseKindFlags.Default, targetFlags)
        {
        }

        public UsedImplicitlyAttribute(ImplicitUseKindFlags useKindFlags, ImplicitUseTargetFlags targetFlags)
        {
            UseKindFlags = useKindFlags;
            TargetFlags = targetFlags;
        }

        public ImplicitUseKindFlags UseKindFlags { get; }

        public ImplicitUseTargetFlags TargetFlags { get; }
    }
}