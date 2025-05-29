namespace LibraryAPI.Model
{
    public class Loan
    {
        //Navigation propeerties
        // is a property on an entity that allows you to navigate from one entity to another related entity , meaning you can retrive information in entity books and Member
       
            public int Id { get; set; }


           public int UserId { get; set; }
           //public ApplicationUser User { get; set; }
            public int BookId { get; set; }
            //public Book Book { get; set; }
            
            public DateTime IssueDate { get; set; }
            public DateTime DueDate { get; set; }
        public DateTime? ReturnedDate { get; set; }

        public decimal FineAmount { get; set; }

        public bool IsReturned => ReturnedDate.HasValue;
    }
}
