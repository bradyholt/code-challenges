using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public abstract class MediaQuestion : Question
    {
        public abstract string MediaUri { get; }
        public string PromptText { get; set; }
    }
