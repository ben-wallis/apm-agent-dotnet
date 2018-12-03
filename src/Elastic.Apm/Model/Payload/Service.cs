﻿using System;

namespace Elastic.Apm.Model.Payload
{
    public class Service
    {
        public Apm.Model.Payload.Agent Agent { get; set; }
        public String Name { get; set; }
        public Framework Framework { get; set; }
        public Language Language { get; set; }
    }

    public class Framework
    {
        public String Name { get; set; }
        public String Version { get; set; }
    }

    public class Language
    {
        public String Name { get; set; }
    }
}
