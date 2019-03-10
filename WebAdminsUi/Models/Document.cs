using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAdminsUi.Models
{
    public class Document
    {
        public int DocumentId { get; set; }
        
        [DisplayName("Document Name")]
        public string DocumentName { get; set; }

        [AllowHtml]
        public string Description { get; set; }

        [DisplayName("Completed by an Analyst")]
        [DefaultValue(false)]
        public bool CompletedByAnalyst { get; set; }

        [DisplayName("Completed by an Architect")]
        [DefaultValue(false)]
        public bool CompletedByArchitect { get; set; }

        [DisplayName("Completed by a Programmer")]
        [DefaultValue(false)]
        public bool CompletedByProgrammer { get; set; }

        [DisplayName("Completed by a Tester")]
        [DefaultValue(false)]
        public bool CompletedByTester { get; set; }
    }
}