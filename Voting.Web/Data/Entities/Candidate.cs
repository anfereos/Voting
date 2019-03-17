namespace Voting.Web.Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class Candidate
    {
        /*  candidate or option name, e.g. Yes / No (for the case of the pool) or Cristina López, Martin Rios,
            Luis Cardona, Blank (for the case of Student representative). */
        public string Name { get; set; }

        /*  A brief description of the proposal of the candidate or of what
            implies the option of the query in question */
        public string Proposal { get; set; }
        
        [Display(Name= "Image")]
        public string ImageUrl { get; set; }
    }
}
