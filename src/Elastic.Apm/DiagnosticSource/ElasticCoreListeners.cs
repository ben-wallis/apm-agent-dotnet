﻿using System.Collections.Generic;
using Elastic.Apm.DiagnosticListeners;

namespace Elastic.Apm.DiagnosticSource
{
    /// <summary>
    /// Manages all listeners that are generated by Types which are part of .netstandard 2.0
    /// </summary>
    public class ElasticCoreListeners
    {
        /// <summary>
        /// Start listening for diagnosticsource events. Only listens for sources that are part of the Agent.Core package.
        /// </summary>
        public void Start()
        {
            System.Diagnostics.DiagnosticListener
            .AllListeners
                  .Subscribe(new DiagnosticInitializer(new List<IDiagnosticListener> {new HttpDiagnosticListener()}));
        }
    }
}