using LibraryAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;


namespace LibraryAPI.Models
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
   
        public DateTime? ReturnDate { get; set; }

      

        // Navigation properties
     
        public Fine? Fine { get; set; }
    }
}
