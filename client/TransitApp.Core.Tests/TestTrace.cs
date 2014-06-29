﻿// --------------------------------------------------------------------------------------------------------------------
// <summary>
//    Defines the TestTrace type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace TransitApp.Core.Tests
{
    using System;
    using System.Diagnostics;
    using Cirrious.CrossCore.Platform;

    /// <summary>
    /// Defines the TestTrace type.
    /// </summary>
    public class TestTrace : IMvxTrace
    {
        /// <summary>
        /// Traces the specified level.
        /// </summary>
        /// <param name="level">The level.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="message">The message.</param>
        public void Trace(
            MvxTraceLevel level,
            string tag,
            Func<string> message)
        {
            Debug.WriteLine(tag + ":" + level + ":" + message());
        }

        /// <summary>
        /// Traces the specified level.
        /// </summary>
        /// <param name="level">The level.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="message">The message.</param>
        public void Trace(
            MvxTraceLevel level,
            string tag,
            string message)
        {
            Debug.WriteLine(tag + ": " + level + ": " + message);
        }

        /// <summary>
        /// Traces the specified level.
        /// </summary>
        /// <param name="level">The level.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="message">The message.</param>
        /// <param name="args">The args.</param>
        public void Trace(
            MvxTraceLevel level,
            string tag,
            string message,
            params object[] args)
        {
            Debug.WriteLine(tag + ": " + level + ": " + message, args);
        }
    }
}
