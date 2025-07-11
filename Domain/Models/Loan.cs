using System.ComponentModel.DataAnnotations.Schema;


namespace LibraryAPI.Domain.Models
{
    public class Loan
    {
        //Navigation propeerties
        // is a property on an entity that allows you to navigate from one entity to another related entity , meaning you can retrive information in entity books and Member

        public int Id { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        [ForeignKey("Member")]
        public int MemberId { get; set; }
        public Member Member { get; set; }

        public DateTime IssueDate { get; set; } = DateTime.Now;
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public decimal FineAmount { get; set; }
    }
}