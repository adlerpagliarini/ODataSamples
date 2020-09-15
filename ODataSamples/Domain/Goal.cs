using System;

namespace ODataSamples.Domain
{
    public class Goal : Identity<Goal>
    {
        public string Title { get; set; }
        public int UserId { get; set; }
    }
}
