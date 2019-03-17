namespace Voting.Web.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Event
    {
        public int Id { get; set; }

        /*  event vote name, e.g. Do you agree with a new pool for the ITM? or;
            Student representative for 2019 */
        public string Name { get; set; }

        //A detailed explanation of the event
        public string Description { get; set; }

        //Date and time at which you can start voting.
        [Display(Name= "Star Date")]
        public DateTime StarDate { get; set; }

        //Date and time at which the vote is closed.
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
    }
}
