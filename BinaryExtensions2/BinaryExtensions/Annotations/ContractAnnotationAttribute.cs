﻿using System;
using System.Diagnostics;

namespace BinaryExtensions.Annotations
{
    /// <summary>
    ///     Describes dependency between method input and output.
    /// </summary>
    /// <syntax>
    ///     <p>Function Definition Table syntax:</p>
    ///     <list>
    ///         <item>FDT      ::= FDTRow [;FDTRow]*</item>
    ///         <item>FDTRow   ::= Input =&gt; Output | Output &lt;= Input</item>
    ///         <item>Input    ::= ParameterName: Value [, Input]*</item>
    ///         <item>Output   ::= [ParameterName: Value]* {halt|stop|void|nothing|Value}</item>
    ///         <item>Value    ::= true | false | null | notnull | canbenull</item>
    ///     </list>
    ///     If method has single input parameter, it's name could be omitted.<br />
    ///     Using <c>halt</c> (or <c>void</c>/<c>nothing</c>, which is the same) for method output
    ///     means that the methos doesn't return normally (throws or terminates the process).<br />
    ///     Value <c>canbenull</c> is only applicable for output parameters.<br />
    ///     You can use multiple <c>[ContractAnnotation]</c> for each FDT row, or use single attribute
    ///     with rows separated by semicolon. There is no notion of order rows, all rows are checked
    ///     for applicability and applied per each program state tracked by R# analysis.<br />
    /// </syntax>
    /// <examples>
    ///     <list>
    ///         <item>
    ///             <code>
    /// [ContractAnnotation("=&gt; halt")]
    /// public void TerminationMethod()
    /// </code>
    ///         </item>
    ///         <item>
    ///             <code>
    /// [ContractAnnotation("halt &lt;= condition: false")]
    /// public void Assert(bool condition, string text) // regular assertion method
    /// </code>
    ///         </item>
    ///         <item>
    ///             <code>
    /// [ContractAnnotation("s:null =&gt; true")]
    /// public bool IsNullOrEmpty(string s) // string.IsNullOrEmpty()
    /// </code>
    ///         </item>
    ///         <item>
    ///             <code>
    /// // A method that returns null if the parameter is null,
    /// // and not null if the parameter is not null
    /// [ContractAnnotation("null =&gt; null; notnull =&gt; notnull")]
    /// public object Transform(object data) 
    /// </code>
    ///         </item>
    ///         <item>
    ///             <code>
    /// [ContractAnnotation("=&gt; true, result: notnull; =&gt; false, result: null")]
    /// public bool TryParse(string s, out Person result)
    /// </code>
    ///         </item>
    ///     </list>
    /// </examples>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    [Conditional("JETBRAINS_ANNOTATIONS")]
    internal sealed class ContractAnnotationAttribute : Attribute
    {
        public ContractAnnotationAttribute([NotNull] string contract)
            : this(contract, false)
        {
        }

        public ContractAnnotationAttribute([NotNull] string contract, bool forceFullStates)
        {
            Contract = contract;
            ForceFullStates = forceFullStates;
        }

        [NotNull] public string Contract { get; }

        public bool ForceFullStates { get; }
    }
}